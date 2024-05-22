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
			LoadCommands();
		}

		public void LoadCommands()
		{
			commands.Add(new IFCommand() { commandString = "quit"});
			commands.Add(new IFCommand() { commandString = "info" });
			commands.Add(new IFCommand() { commandString = "help" });
		}
		public bool ParseCommand(string commandStr, out IFCommand command)
		{
			var command_list = commands.FindAll(o => commandStr.Contains(o.commandString));

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
