﻿using System;
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
		public IFCommandType commandType { get; set; } = IFCommandType.Other;
	}
}
