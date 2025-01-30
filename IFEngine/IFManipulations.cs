using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public enum IFManipulations
	{
		[Description("examine")]
		Examine,
		[Description("search")]
		Search,
		[Description("get")]
		Get,
		[Description("unlock")]
		Unlock,
		[Description("lock")]
		Lock,
		[Description("drop")]
		Drop
	}
}
