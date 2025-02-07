using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class LockDoor : IFItem
	{
		public IFExit? exit { get; set; }
		public int keyid { get; set; }
		public LockDoor() 
		{
			tags.Add("door");
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
				case IFManipulations.UNLOCK:
					DoUnlock(character);
					break;
				case IFManipulations.LOCK:
					DoLock(character);
					break;
				case IFManipulations.SAY:
					DoSay(word);
					break;
				default:
					DoOther();
					break;
			}
		}

		internal void DoUnlock(IFCharacter character)
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

		internal void DoLock(IFCharacter character)
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

		internal override void DoExamine()
		{
			base.DoExamine();
			if (this.exit != null &&  !this.exit.isLocked)
			{
				Utilities.EpicWriteLine("The door is unlocked.");
			}
		}
	}
}
