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
		IFCharacter? character;
		readonly IFParser parser = new();

		public void Start()
		{
			game.GenerateSampleContent();
			game.GenerateAliasList();
			character = game.Character;
			character.currentLocation = game.startRoomId;
			string? userString = string.Empty;
			IFCommand command = new IFCommand();

			Utilities.EpicWriteLine(game.InstructionText);

			while (command.commandType != IFCommandType.Quit)
			{
				IFRoom room = game.Rooms[character.currentLocation];

				Console.WriteLine();
				Utilities.EpicWriteLine(room.Description, ConsoleColor.Cyan);
				
				DisplayItems(room);

				DisplayExits(room);

				userString = Console.ReadLine();

				userString = ReplaceWithAliases(userString);
			
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
					Console.WriteLine(game.UnknownCommandText);
				}
			}
		}

		private void DisplayItems(IFRoom room)
		{
			if (room.Items.Count > 0) { Console.WriteLine(); }
			foreach (IFItem item in room.Items.FindAll(o => o.IsListed))
			{
				Utilities.EpicWriteLine(item.name, ConsoleColor.Yellow);
			}
		}

		private void DisplayExits(IFRoom room)
		{
			if (room.Exits.Count > 0) { Console.WriteLine(); }
			string exitString = "Obvious Exits: ";

			foreach (var exit in room.Exits.FindAll(o => o.isVisible))
			{
				exitString += exit.direction.ToString() + ", ";
			}
			exitString = exitString.Substring(0, exitString.Length - 2);
			Utilities.EpicWriteLine(exitString, ConsoleColor.Magenta);
		}

		private string? ReplaceWithAliases(string? userString)
		{
			if (userString == null)
				return userString;

			var wordList = userString.Split(' ');

			for (int i=0; i < wordList.Count(); i++)
			{
				if (game.Aliases.ContainsKey(wordList[i]))
				{
					wordList[i] = game.Aliases[wordList[i]];
				}
			}

			userString = string.Empty;
			foreach (var word in wordList)
			{
				userString += word + " ";
			}
			userString = userString.Trim();

			return userString;
		}

		private void ExecuteInventory()
		{
			Console.WriteLine();
			if (character == null || character.inventory.Count == 0)
			{
				Utilities.EpicWriteLine("You have nothing in your pockets.");
				return;
			}

			Utilities.EpicWriteLine("You go through your bag and pockets and you find: ");

			foreach(var item in character.inventory)
			{
				Utilities.EpicWriteLine(item.name, ConsoleColor.Yellow);
			}
		}

		private void ExecuteManipulation(IFCommand command)
		{
			if (character == null)
				return;
			//Let's build an inventory of all the available items in the room and character inventory that match the command object

			List<IFItem> items = game.Rooms[character.currentLocation].Items.FindAll(o => o.tags.Contains(command.objectString) && o.IsActionable);
			items.AddRange(character.inventory.FindAll(o => o.tags.Contains(command.objectString) && o.IsVisible));

			if (items.Count == 1)
			{
				Console.WriteLine();
				items[0].DoAction(Enum.Parse<IFManipulations>(command.commandString.ToUpper()), character, game.Rooms[character.currentLocation], command.wordString);
			}
			else if (items.Count > 1) 
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("Which " + command.objectString + " do you mean?");
			}
			else if (command.wordString != string.Empty)
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("You say \"" + command.wordString + "\"");
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("You find no " + command.objectString + " here.");
			}

		}

		private void ExecuteMovement(IFCommand command)
		{
			if (character == null)
				return;

			List<IFExit> roomExits = game.Rooms[character.currentLocation].Exits.FindAll(o => o.direction != null && o.direction.Value.ToString() == command.commandString);
			
			if (roomExits.Count > 0)
			{
				if (roomExits[0].isLocked)
				{
					Console.WriteLine();
					Utilities.EpicWriteLine(roomExits[0].LockedText);
				}
				else if (!roomExits[0].isVisible)
				{
					Console.WriteLine();
					Utilities.EpicWriteLine(roomExits[0].InvisibleText);
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
