using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class Door : IFItem
	{
		public IFExit exit { get; set; }
		public int keyid { get; set; }
		public Door() 
		{
			tags.Add("door");
		}
		public override void DoAction(IFManipulations manipulation, ref IFCharacter character, IFRoom room)
		{
			switch (manipulation)
			{
				case IFManipulations.Examine:
					DoExamine();
					break;
				case IFManipulations.Search:
					DoSearch();
					break;
				case IFManipulations.Unlock:
					DoUnlock(character);
					break;
				case IFManipulations.Lock:
					DoLock(character);
					break;
				default:
					DoOther();
					break;
			}
		}

		private void DoUnlock(IFCharacter character)
		{
			if (exit == null)
			{
				return;
			}

			if (character.inventory.FindAll(o => o.itemId == keyid).Count > 0)
			{
				exit.isLocked = false;
				Console.WriteLine();
				Utilities.EpicWriteLine("You unlocked the door.");
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("You do not have the key to unlock this door.");
			}

		}

		private void DoLock(IFCharacter character)
		{
			if (exit == null)
			{
				return;
			}

			if (character.inventory.FindAll(o => o.itemId == keyid).Count > 0)
			{
				exit.isLocked = true;
				Console.WriteLine();
				Utilities.EpicWriteLine("You locked the door.");
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("You do not have the key to lock this door.");
			}

		}
	}
}
