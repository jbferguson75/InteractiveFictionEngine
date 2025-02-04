using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public class IFExit
	{
		public IFDirection? direction { get; set; } = null;
		public string customDirection { get; set; } = string.Empty;
		public string LockedText { get; set; } = "The door seems to be locked.";
		public string InvisibleText {  get; set; } = "You can't seem to go that way.";
		public int roomId { get; set; } = 0;
		public bool isVisible { get; set; } = true;
		public bool isLocked { get; set; } = false;
	}
}
