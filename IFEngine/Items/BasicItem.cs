using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class BasicItem : IFItem
	{
		public BasicItem() 
		{
			tags.Add("key");
		}

		public override void DoAction(IFManipulations manipulation, IFCharacter character, IFRoom room, string word = "")
		{
			switch (manipulation)
			{
				case IFManipulations.EXAMINE:
					DoExamine();
					break;
				case IFManipulations.GET:
					DoGet(character, room);
					break;
				case IFManipulations.DROP:
					DoDrop(character, room);
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

		
	}
}
