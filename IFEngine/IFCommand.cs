using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public class IFCommand
	{
		public string commandString { get; set; } = string.Empty;
		public string objectString { get; set; } = string.Empty;
		public IFCommandType commandType { get; set; } = IFCommandType.Other;
		public string wordString {  get; set; } = string.Empty;

		public IFCommand()
		{
			commandString = string.Empty;
			objectString = string.Empty;
			commandType = IFCommandType.Unknown;
		}

		public IFCommand(IFCommand c) 
		{
			commandString = c.commandString;
			objectString = c.objectString;
			commandType = c.commandType;
		}
	}
}
