using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveFictionEngine.IFParser;

namespace InteractiveFictionEngine.Items
{
	internal class SayTransport : IFItem
	{
		public int TranportToRoomId { get; set; } = -1;
		public string word { get; set; } = string.Empty;
		public string TransportationText { get; set; } = string.Empty;

		public override void DoAction(IFManipulations manipulation, IFCharacter character, IFRoom room, string word = "")
		{
			if (manipulation == IFManipulations.SAY)
			{
				DoSay(word, character);
			}
		}

		internal override void DoSay(string w, IFCharacter? character)
		{
			if (TranportToRoomId == -1 || character == null)
			{
				return;
			}

			if (word.ToLower().Equals(w.ToLower()))
			{
				Utilities.EpicWriteLine(TransportationText);
				character.currentLocation = TranportToRoomId;
			}
			else
			{
				Console.WriteLine();
				Utilities.EpicWriteLine("Nothing happens.");
			}

		}
	}
}
