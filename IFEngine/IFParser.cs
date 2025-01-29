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
		}

		private void LoadOtherCommands()
		{
			commands.Add(new IFCommand() { commandString = "quit", commandType = IFCommandType.Quit});
			commands.Add(new IFCommand() { commandString = "info", commandType = IFCommandType.Info });
			commands.Add(new IFCommand() { commandString = "help", commandType = IFCommandType.Help });
		}

		private void LoadMovementCommands()
		{
			foreach (var value in Enum.GetValues(typeof(IFDirection)).Cast<IFDirection>())
			{
				commands.Add(new IFCommand() { commandString = value.ToString(), commandType = IFCommandType.Movement });
			}
		}

		public bool ParseCommand(string commandStr, out IFCommand command)
		{
			var command_list = commands.FindAll(o => commandStr.Equals(o.commandString.ToLower()));

			if (command_list.Count == 1 )
			{
				command = command_list[0];
				return true;
			}

			command = new IFCommand() { commandType = IFCommandType.Unknown };

			return false;
		}
	}
}
