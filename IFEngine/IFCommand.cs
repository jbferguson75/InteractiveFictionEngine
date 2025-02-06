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
		public string directObject { get; set; } = string.Empty;
		public string preposition {  get; set; } = string.Empty;
		public string prepObject {  get; set; } = string.Empty; 
		public IFCommandType commandType { get; set; } = IFCommandType.Other;
		public string wordString {  get; set; } = string.Empty;

		public IFCommand()
		{
			commandString = string.Empty;
			directObject = string.Empty;
			preposition = string.Empty;
			prepObject = string.Empty;
			commandType = IFCommandType.Unknown;
		}

		public IFCommand(IFCommand c) 
		{
			commandString = c.commandString;
			directObject = c.directObject;
			preposition = c.preposition;
			prepObject = c.prepObject;
			commandType = c.commandType;
		}
	}
}
