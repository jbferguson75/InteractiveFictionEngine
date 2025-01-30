using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public abstract class IFItem
	{
		public int itemId { get; set; } = 0;
		public string name { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public bool IsVisible { get; set; } = true;

		public List<string> tags { get; set; } = new List<string>();

		public abstract void DoAction(IFManipulations manipulation, ref IFCharacter character, IFRoom room);

		internal virtual void DoSearch()
		{
			Utilities.EpicWriteLine("You find nothing.");
		}

		internal virtual void DoExamine()
		{
			Utilities.EpicWriteLine(description);
		}

		internal virtual void DoOther()
		{
			Utilities.EpicWriteLine("I can't seem to do that.");
		}
	}
}
