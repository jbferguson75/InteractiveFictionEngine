using Catalyst;
using Catalyst.Models;
using P = Catalyst.PatternUnitPrototype;
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
					else if (command.directObject != string.Empty)
					{
						command.wordString = command.directObject;
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

		private enum SearchPart
		{
			Verb,
			DirectObject,
			Preposition,
			PrepositionObject,
			Complete
		}

		private IFCommand FindCommand(List<SentenceParts> parts)
		{
			IFCommand command = new IFCommand();
			SearchPart currentSearchPart = SearchPart.Verb;

			if (parts.Count == 0)
			{
				return new IFCommand() { commandType = IFCommandType.Unknown };
			}

			int i = 0;

			if (parts.Count == 1)
			{
				command.commandString = parts[0].word;
				i = parts.Count;
			}
			else if (parts.FindAll(o => o.POS == "VERB").Count == 0)
			{
				command.commandString = parts[0].word;
				i = 1;
			}

			for (; i < parts.Count; i++)
			{
				var word = parts[i];

				if (word.POS == "VERB" && currentSearchPart == SearchPart.Verb)
				{
					command.commandString = word.word;
					continue;
				}

				if ((currentSearchPart == SearchPart.Verb || currentSearchPart == SearchPart.DirectObject) && (word.POS == "ADJ" || word.POS == "NOUN"))
				{
					currentSearchPart = SearchPart.DirectObject;
					command.directObject += word.word + " ";
					continue;
				}

				if (currentSearchPart == SearchPart.DirectObject && word.POS != "ADJ" && word.POS != "NOUN")
				{
					currentSearchPart = SearchPart.Preposition;
				}

				if (currentSearchPart == SearchPart.Preposition && word.POS == "ADP")
				{
					command.preposition = word.word;
					continue;
				}

				if ((currentSearchPart == SearchPart.Preposition || currentSearchPart == SearchPart.PrepositionObject) && (word.POS == "ADJ" || word.POS == "NOUN"))
				{
					currentSearchPart = SearchPart.PrepositionObject;
					command.directObject += word.word + " ";
					continue;
				}

				if (currentSearchPart == SearchPart.PrepositionObject && word.POS != "ADJ" && word.POS != "NOUN")
				{
					currentSearchPart = SearchPart.Complete;
				}
			}

			command.directObject = command.directObject.Trim();
			command.prepObject = command.prepObject.Trim();

			var command_list = commands.FindAll(o => command.commandString.Equals(o.commandString.ToLower()));

			if (command_list.Count > 0)
			{
				command.commandType = command_list[0].commandType;
				return command;
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
