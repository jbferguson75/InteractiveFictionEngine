using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public class IFParser
	{
		public List<IFCommand> commands = new List<IFCommand>();

		public IFParser() 
		{ 
			LoadOtherCommands();
			LoadMovementCommands();
			LoadManipulationCommands();
		}

		private void LoadOtherCommands()
		{
			commands.Add(new IFCommand() { commandString = "quit", commandType = IFCommandType.Quit});
			commands.Add(new IFCommand() { commandString = "info", commandType = IFCommandType.Info });
			commands.Add(new IFCommand() { commandString = "help", commandType = IFCommandType.Help });
			commands.Add(new IFCommand() { commandString = "inventory", commandType = IFCommandType.Inventory });
		}

		private void LoadMovementCommands()
		{
			foreach (var value in Enum.GetValues(typeof(IFDirection)).Cast<IFDirection>())
			{
				commands.Add(new IFCommand() { commandString = value.ToString(), commandType = IFCommandType.Movement });
			}
		}

		private void LoadManipulationCommands()
		{
			foreach (var value in Enum.GetValues(typeof(IFManipulations)).Cast<IFManipulations>())
			{
				commands.Add(new IFCommand() { commandString = value.ToString(), commandType = IFCommandType.Manipulation });
			}
		}

		public bool ParseCommand(string commandStr, out IFCommand command)
		{
			string[] word_list = commandStr.Split(' ');

			if (word_list.Length > 0)
			{
				var command_list = commands.FindAll(o => word_list[0].Equals(o.commandString.ToLower()));

				if (command_list.Count == 1)
				{
					command = command_list[0];
					command.objectString = string.Empty;

					if (word_list.Length > 1)
					{
						for (int i=1; i<word_list.Length; i++)
						{
							command.objectString += word_list[i];
							if (i < word_list.Length - 1)
								command.objectString += " ";
						}
					}
					return true;
				}
			}

			command = new IFCommand() { commandType = IFCommandType.Unknown };

			return false;
		}
	}
}
