using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class ClimbableItem : IFItem
	{
		public IFRoom? climbToRoom;
		public override void DoAction(IFManipulations manipulation, IFCharacter character, IFRoom room, string word = "")
		{
			switch(manipulation)
			{
				case IFManipulations.CLIMB:
					DoClimb(character);
					break;
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
			if (manipulation == IFManipulations.CLIMB)
			{
				DoClimb(character);
			}
		}

		internal void DoClimb(IFCharacter character)
		{
			character.currentLocation = climbToRoom.RoomId;
		}
	}
}
