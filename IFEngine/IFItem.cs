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
		public bool IsListed { get; set; } = false;
		public bool IsGettable { get; set; } = false;
		public bool IsActionable { get; set; } = true;

		public List<string> tags { get; set; } = new List<string>();

		public abstract void DoAction(IFManipulations manipulation, ref IFCharacter character, IFRoom room, string word="");

		internal virtual void DoSearch(IFCharacter character, IFRoom room)
		{
			Utilities.EpicWriteLine("You find nothing.");
		}

		internal virtual void DoExamine()
		{
			Utilities.EpicWriteLine(description);
		}

		internal virtual void DoDrop(IFCharacter character, IFRoom room)
		{
			character.inventory.Remove(this);
			room.Items.Add(this);
			Utilities.EpicWriteLine("You dropped " + this.name + ".");
		}

		internal virtual void DoGet(IFCharacter character, IFRoom room)
		{
			if (IsGettable)
			{
				room.Items.Remove(this);
				character.inventory.Add(this);
				Utilities.EpicWriteLine("You pick up " + this.name + " and place it in your pocket.");
			}
			else
			{
				Utilities.EpicWriteLine("You can't seem to do that.");
			}
		}

		internal virtual void DoSay(string w)
		{
			Utilities.EpicWriteLine("Nothing happens.");
		}

		internal virtual void DoOther()
		{
			Utilities.EpicWriteLine("You can't seem to do that.");
		}
	}
}
