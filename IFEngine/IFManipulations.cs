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
		EXAMINE,
		[Description("search")]
		SEARCH,
		[Description("get")]
		GET,
		[Description("unlock")]
		UNLOCK,
		[Description("lock")]
		LOCK,
		[Description("drop")]
		DROP
	}
}
