using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class ContainerItem : IFItem
	{
		public List<IFItem> ContainedItems { get; set; } = new List<IFItem>();
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
			if (ContainedItems.Count == 0)
			{
				base.DoSearch(character, room);
				return;
			}

			IFItem item = ContainedItems[0];
			room.Items.Add(item);
			ContainedItems.Remove(item);

			if (SearchText == string.Empty)
			{
				Utilities.EpicWriteLine("You search the " + name + " until you find a " + item.name);
			}
			else
			{
				Utilities.EpicWriteLine(SearchText);
			}

			item.IsVisible = true;
		}
	}
}
