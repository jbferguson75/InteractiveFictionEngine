using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class Key : IFItem
	{
		public Key() 
		{
			tags.Add("key");
		}

		public override void DoAction(IFManipulations manipulation, ref IFCharacter character, IFRoom room)
		{
			switch (manipulation)
			{
				case IFManipulations.Examine:
					DoExamine();
					break;
				case IFManipulations.Get:
					DoGet(character, room);
					break;
				case IFManipulations.Drop:
					DoDrop(character, room);
					break;
				case IFManipulations.Search:
					DoSearch();
					break;
				default:
					DoOther();
					break;
			}
		}

		private void DoGet(IFCharacter character, IFRoom room)
		{
			room.Items.Remove(this);
			character.inventory.Add(this);
			Utilities.EpicWriteLine("You pick up " + this.name + " and place it in your pocket.");
		}

		private void DoDrop(IFCharacter character, IFRoom room)
		{
			character.inventory.Remove(this);
			room.Items.Add(this);
			Utilities.EpicWriteLine("You dropped " + this.name + ".");
		}
	}
}
