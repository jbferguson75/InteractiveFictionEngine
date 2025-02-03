using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class ContainerItem : IFItem
	{
		public int ContainedItemId { get; set; } = -1;

		public ContainerItem() 
		{
			tags.Add("bookshelf");
			tags.Add("bookshelves");
			tags.Add("shelf");
			tags.Add("shelves");
		}
		public override void DoAction(IFManipulations manipulation, ref IFCharacter character, IFRoom room)
		{
			switch (manipulation)
			{
				case IFManipulations.EXAMINE:
					DoExamine();
					break;
				case IFManipulations.SEARCH:
					DoSearch(character, room);
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

			Utilities.EpicWriteLine("You search the " + name + " until you find a " + item.name);
			item.IsVisible = true;
			item.IsListed = true;
		}
	}
}
