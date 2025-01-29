using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public enum IFDirection
	{
		[Description("north")]
		North,
		[Description("south")]
		South,
		[Description("east")]
		East,
		[Description("west")]
		West,
		[Description("northeast")]
		NorthEast,
		[Description("southeast")]
		SouthEast,
		[Description("northwest")]
		NorthWest,
		[Description("southwest")]
		SouthWest,
		[Description("up")]
		Up,
		[Description("down")]
		Down,
		[Description("custom")]
		Custom
	}
}
