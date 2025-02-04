using Catalyst;
using Mosaik.Core;
using System.Text.Json;

namespace InteractiveFictionEngine
{
	public class IFParser
	{
		public List<IFCommand> commands = new List<IFCommand>();
		private Pipeline nlp;

		public IFParser() 
		{ 
			LoadOtherCommands();
			LoadMovementCommands();
			LoadManipulationCommands();

			Catalyst.Models.English.Register();

			Storage.Current = new DiskStorage("catalyst-models");
			nlp = Pipeline.For(Language.English);
		}

		private void LoadOtherCommands()
		{
			commands.Add(new IFCommand() { commandString = "quit", commandType = IFCommandType.Quit});
			commands.Add(new IFCommand() { commandString = "info", commandType = IFCommandType.Info });
			commands.Add(new IFCommand() { commandString = "help", commandType = IFCommandType.Help });
			commands.Add(new IFCommand() { commandString = "inventory", commandType = IFCommandType.Inventory });
		}

		private void LoadMovementCommands()
		{
			foreach (var value in Enum.GetValues(typeof(IFDirection)).Cast<IFDirection>())
			{
				commands.Add(new IFCommand() { commandString = value.ToString(), commandType = IFCommandType.Movement });
			}
		}

		private void LoadManipulationCommands()
		{
			foreach (var value in Enum.GetValues(typeof(IFManipulations)).Cast<IFManipulations>())
			{
				commands.Add(new IFCommand() { commandString = value.ToString(), commandType = IFCommandType.Manipulation });
			}
		}

		public bool ParseCommand(string commandStr, out IFCommand command)
		{
			command = new IFCommand() { commandType = IFCommandType.Unknown };

			if (commandStr.Length > 0)
			{

				var doc = new Document(commandStr, Language.English);
				nlp.ProcessSingle(doc);

				using var jDoc = JsonDocument.Parse(doc.ToJson());

				Symbol? s = JsonSerializer.Deserialize<Symbol>(doc.ToJson());

				if (s == null)
				{
					return false;
				}

				List<SentenceParts> parts = BuildSymbolList(doc.ToJson(), commandStr);

				command = FindCommand(parts);

				if (command.commandString.ToLower() == "say")
				{
					int firstPos = commandStr.IndexOf('"', 0);
					int lastPos = commandStr.IndexOf("\"", firstPos + 1);

					if (firstPos != -1)
					{
						command.wordString = commandStr.Substring(firstPos + 1, lastPos - firstPos - 1);
					}
					else if (command.objectString != string.Empty)
					{
						command.wordString = command.objectString;
					}
				}

				if (command != null && command.commandType != IFCommandType.Unknown)
				{
					return true;
				}
			}
			return false;
		}

		private static List<SentenceParts> BuildSymbolList(string json, string original)
		{
			List<SentenceParts> result = new List<SentenceParts>();
			Symbol? s = JsonSerializer.Deserialize<Symbol>(json);

			if (s == null || s.TokensData == null)	
			{ 
				return result; 
			}

			foreach (var l1 in s.TokensData)
			{
				foreach (var l2 in l1)
				{
					if (l2.Bounds != null && l2.Bounds.Count >= 2)
					{
						string word = original.Substring(l2.Bounds[0], l2.Bounds[1] - l2.Bounds[0] + 1);
						string pos = l2.Tag;

						result.Add(new SentenceParts() { word = word, POS = pos });
					}
				}
			}

			return result;
		}

		private IFCommand FindCommand(List<SentenceParts> parts)
		{
			IFCommand command;

			if (parts.Count == 1)
			{
				var command_list = commands.FindAll(o => parts[0].word.Equals(o.commandString.ToLower()));
				if (command_list.Count == 1)
					return command_list[0];
			}
			else if (parts.Count > 1)
			{
				string verb = string.Empty;

				int i = 0;

				foreach (var word in parts)
				{
					i++;
					if (word.POS == "VERB")
					{
						verb = word.word;
						break;
					}
				}

				if (verb ==  string.Empty)
				{
					verb = parts[0].word;
					i = 1;
				}

				var command_list = commands.FindAll(o => verb.Equals(o.commandString.ToLower()));

				if (command_list.Count == 1)
				{
					command = new IFCommand(command_list[0]);
					

					for (; i < parts.Count; i++)
					{
						bool found = false;

						while (i < parts.Count && (parts[i].POS == "ADJ" || parts[i].POS == "NOUN"))
						{
							command.objectString += parts[i].word + " ";
							i++;
							found = true;
						}

						if (found)
						{
							command.objectString = command.objectString.Substring(0, command.objectString.Length - 1);
							break;
						}
					}

					if (command.commandString != string.Empty)
						return command;
				}
			}

			return new IFCommand() { commandType = IFCommandType.Unknown };
		}

		public class Symbol
		{
			public string Language { get; set; } = string.Empty;
			public int Length { get; set; }
			public string Value { get; set; } = string.Empty;
			public List<List<Word>>? TokensData { get; set; }
		}

		public class Word
		{
			public List<int>? Bounds { get; set; }
			public string Tag { get; set; } = string.Empty;
		}

		public class SentenceParts
		{
			public string word { get; set; } = String.Empty;

			public string Lemma { get; set; } = String.Empty;
			public string POS { get; set; } = String.Empty;

		}
	}
}
