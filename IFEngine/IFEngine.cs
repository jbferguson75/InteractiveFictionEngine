using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public class IFEngine
	{
		IFGame game = new IFGame();
		IFCharacter character = new IFCharacter();
		IFParser parser = new IFParser();

		public void Start()
		{
			game.GenerateSampleContent();
			game.GenerateAliasList();
			character.currentLocation = game.startRoomId;
			string? userString = string.Empty;
			IFCommand command = new IFCommand();

			Utilities.EpicWriteLine(game.InstructionText);

			while (command.commandType != IFCommandType.Quit)
			{
				IFRoom room = game.Rooms[character.currentLocation];

				Console.WriteLine();
				Utilities.EpicWriteLine(room.Description, ConsoleColor.Cyan);
				
				if (room.Items.Count > 0) { Console.WriteLine(); }
				foreach(IFItem item in room.Items.FindAll(o => o.IsListed))
				{
					Utilities.EpicWriteLine(item.name, ConsoleColor.Yellow);
				}

				if (room.Exits.Count > 0) { Console.WriteLine(); }
				string exitString = "Obvious Exits: ";

				for (int i=0; i<room.Exits.Count; i++)
				{
					var exit = room.Exits[i];
					exitString += exit.direction.ToString();
					if (i != room.Exits.Count - 1)
						exitString += ", ";
				}
				Utilities.EpicWriteLine(exitString, ConsoleColor.Magenta);

				userString = Console.ReadLine();

				if (userString != null && game.Aliases.ContainsKey(userString))
				{
					userString = game.Aliases[userString];
				}
			
				if (userString != null && parser.ParseCommand(userString, out command))
				{
					switch (command.commandType)
					{
						case IFCommandType.Help:
							Console.WriteLine(game.HelpText);
							break;
						case IFCommandType.Info: 
							Console.WriteLine(game.InfoText); 
							break;
						case IFCommandType.Inventory:
							ExecuteInventory();
							break;
						case IFCommandType.Movement:
							ExecuteMovement(command);
							break;
						case IFCommandType.Manipulation:
							ExecuteManipulation(command);
							break;

					}
				}
				else
				{
					Console.WriteLine("Unknown Command.");
				}
			}
		}

		private void ExecuteInventory()
		{
			Console.WriteLine();
			if (character.inventory.Count == 0)
			{
				Utilities.EpicWriteLine("You have nothing in your pockets.");
				return;
			}

			Utilities.EpicWriteLine("You go through your bag and pockets and you find: ");

			foreach(var item in character.inventory)
			{
				Utilities.EpicWriteLine(item.name);
			}
		}

		private void ExecuteManipulation(IFCommand command)
		{
			//Let's build an inventory of all the available items in the room and character inventory that match the command object

			List<IFItem> items = game.Rooms[character.currentLocation].Items.FindAll(o => o.tags.Contains(command.objectString) && o.IsVisible);
			items.AddRange(character.inventory.FindAll(o => o.tags.Contains(command.objectString) && o.IsVisible));

			if (items.Count == 1)
			{
				Console.WriteLine();
				items[0].DoAction(Enum.Parse<IFManipulations>(command.commandString.ToUpper()), ref character, game.Rooms[character.currentLocation]);
			}
			else if (items.Count > 1) 
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("Which " + command.objectString + " do you mean?");
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("You find no " + command.objectString + " here.");
			}

		}

		private void ExecuteMovement(IFCommand command)
		{
			List<IFExit> roomExits = game.Rooms[character.currentLocation].Exits.FindAll(o => o.direction != null && o.direction.Value.ToString() == command.commandString);
			
			if (roomExits.Count > 0)
			{
				if (roomExits[0].isLocked)
				{
					Console.WriteLine();
					Utilities.EpicWriteLine("The door seems to be locked.");
				}
				else
				{
					character.currentLocation = roomExits[0].roomId;
				}
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("You can't seem to go that way.");
			}
		}
	}
}
