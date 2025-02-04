﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class ContainerItem : IFItem
	{
		public int ContainedItemId { get; set; } = -1;
		public string SearchText { get; set; } = string.Empty;

		public ContainerItem() 
		{
			tags.Add("bookshelf");
			tags.Add("bookshelves");
			tags.Add("shelf");
			tags.Add("shelves");
		}
		public override void DoAction(IFManipulations manipulation, IFCharacter character, IFRoom room, string word = "")
		{
			switch (manipulation)
			{
				case IFManipulations.EXAMINE:
					DoExamine();
					break;
				case IFManipulations.SEARCH:
					DoSearch(character, room);
					break;
				case IFManipulations.SAY:
					DoSay(word);
					break;
				default:
					DoOther();
					break;
			}
		}

		internal override void DoSearch(IFCharacter character, IFRoom room)
		{
			IFItem? item = room.Items.Find(o => o.itemId == ContainedItemId);

			if (item == null || ContainedItemId == -1)
			{
				base.DoSearch(character, room);
				return;
			}

			if (SearchText == string.Empty)
			{
				Utilities.EpicWriteLine("You search the " + name + " until you find a " + item.name);
			}
			else
			{
				Utilities.EpicWriteLine(SearchText);
			}

			item.IsVisible = true;
			item.IsListed = true;
			item.IsGettable = true;
			item.IsActionable = true;
		}
	}
}
