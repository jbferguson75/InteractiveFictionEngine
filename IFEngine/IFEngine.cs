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
			character.currentLocation = game.startRoomId;
			string userString = string.Empty;
			IFCommand command = new IFCommand();

			Console.WriteLine(game.InstructionText);
			Console.WriteLine();

			while (command.commandType != IFCommandType.Quit)
			{
				Console.WriteLine(game.Rooms[character.currentLocation].Description);
				Console.WriteLine();
				userString = Console.ReadLine();
			
				if (parser.ParseCommand(userString, out command))
				{
					//handle command here
				}
				else
				{
					Console.WriteLine("Unknown Command.");
				}
			}
		}
	}
}
