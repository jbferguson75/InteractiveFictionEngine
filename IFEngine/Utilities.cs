using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	internal class Utilities
	{
		internal static void EpicWriteLine(String text, ConsoleColor color = ConsoleColor.White)
		{
			String[] words = text.Split(' ');
			StringBuilder buffer = new StringBuilder();

			Console.ForegroundColor = color;

			foreach (String word in words)
			{
				buffer.Append(word);

				if (buffer.Length >= 80)
				{
					String line = buffer.ToString().Substring(0, buffer.Length - word.Length);
					Console.WriteLine(line);
					buffer.Clear();
					buffer.Append(word);
				}

				buffer.Append(" ");

			}
			
			Console.WriteLine(buffer.ToString());
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
