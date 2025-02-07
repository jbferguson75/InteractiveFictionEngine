﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine.Items
{
	internal class SayDoor : IFItem
	{
		public IFExit? exit { get; set; }
		public string word { get; set; } = string.Empty;
		public string ExitOpenText { get; set; } = string.Empty;
		public SayDoor() 
		{
			IsVisible = false;
			IsListed = false;
		}
		public override void DoAction(IFManipulations manipulation, IFCharacter character, IFRoom room, string word = "")
		{
			if (manipulation == IFManipulations.SAY)
			{
				DoSay(word);
			}
		}

		internal override void DoSay(string w, IFCharacter? character = null)
		{
			if (exit == null)
			{
				return;
			}

			if (word.ToLower().Equals(w.ToLower()))
			{
				if (exit.isVisible)
				{
					Utilities.EpicWriteLine("You've already said that here.");
				}
				else
				{
					exit.isVisible = true;
					Utilities.EpicWriteLine(ExitOpenText);
				}
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("Nothing happens.");
			}

		}
	}
}
