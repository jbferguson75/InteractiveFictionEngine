﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class ReadingItem : IFItem
	{
		public string readingContent {  get; set; } = string.Empty;

		public override void DoAction(IFManipulations manipulation, IFCharacter character, IFRoom room, string word="")
		{
			switch (manipulation)
			{
				case IFManipulations.EXAMINE:
					DoExamine();
					break;
				case IFManipulations.SEARCH:
					DoSearch(character, room);
					break;
				case IFManipulations.READ:
					DoRead(character);
					break;
				case IFManipulations.GET:
					DoGet(character, room);
					break;
				case IFManipulations.SAY:
					DoSay(word);
					break;
				default:
					DoOther();
					break;
			}
		}

		internal void DoRead(IFCharacter character)
		{
			if (character.inventory.FindAll(o => o.itemId == itemId).Count > 0)
			{
				Utilities.EpicWriteLine("You read the " + name + ".  It says: ");
				Utilities.EpicWriteLine(readingContent);
			}
			else
			{
				Utilities.EpicWriteLine("You must first get the book.");
			}
		}
	}
}
