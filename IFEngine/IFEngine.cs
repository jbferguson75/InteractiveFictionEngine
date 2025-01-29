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
			string userString = string.Empty;
			IFCommand command = new IFCommand();

			Utilities.EpicWriteLine(game.InstructionText);

			while (command.commandType != IFCommandType.Quit)
			{
				IFRoom room = game.Rooms[character.currentLocation];

				Console.WriteLine();
				Utilities.EpicWriteLine(room.Description);
				Console.Write("(Obvious Exits: ");
				for (int i=0; i<room.Exits.Count; i++)
				{
					var exit = room.Exits[i];
					Console.Write(exit.direction.ToString());
					if (i != room.Exits.Count - 1)
						Console.Write(", ");
				}
				Console.Write(")");
				Console.WriteLine();
				userString = Console.ReadLine();

				if (game.Aliases.ContainsKey(userString))
				{
					userString = game.Aliases[userString];
				}
			
				if (parser.ParseCommand(userString, out command))
				{
					switch (command.commandType)
					{
						case IFCommandType.Help:
							Console.WriteLine(game.HelpText);
							break;
						case IFCommandType.Info: 
							Console.WriteLine(game.InfoText); 
							break;
						case IFCommandType.Movement:
							ExecuteMovement(command);
							break;
					}
				}
				else
				{
					Console.WriteLine("Unknown Command.");
				}
			}
		}

		private void ExecuteMovement(IFCommand command)
		{
			List<IFExit> roomExits = game.Rooms[character.currentLocation].Exits.FindAll(o => o.direction != null && o.direction.Value.ToString() == command.commandString);
			
			if (roomExits.Count > 0)
			{
				character.currentLocation = roomExits[0].roomId;
			}
		}
	}
}
