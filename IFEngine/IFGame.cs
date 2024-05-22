namespace IFEngine
{
	public class IFGame
	{
		public string Instructions { get; set; } = string.Empty;
		public Dictionary<int,IFRoom> Rooms { get; set; } = new Dictionary<int, IFRoom>();
		public IFCharacter Character { get; set; } = new IFCharacter();
		public void GenerateSampleContent()
		{
			Instructions = "Somewhere nearby is Colossal Cave, where others have found fortunes in treasure and gold, ";
			Instructions += "though it is rumored that some who enter are never seen again.  Magic is said to work in the cave.  ";
			Instructions += "I will be your eyes and hands.  Direct me with commands of 1 or 2 words.  I should warn you that I look at ";
			Instructions += "only the first five letters of each word, so you'll have to enter \"Northeast\" as \"ne\" to distinguish it ";
			Instructions += "from \"North.\"  (Should you get stuck, type \"help\" or \"info\" for some hints).";

			IFRoom startRoom = new IFRoom() { RoomId = 1 };
			startRoom.Description = "You are standing at the end of a road before a small brick building.  ARound you is a forest.  ";
			startRoom.Description += "A small stream flows out of the building and down a gully.";

			IFRoom hillRoom = new IFRoom() { RoomId = 2 };
			hillRoom.Description = "You have walked up a hill, still in the forest.  The road slopes back down the other side of the hill.  ";
			hillRoom.Description = "There is a building in the distance.";
			

			IFRoom forestRoom = new IFRoom() { RoomId = 3 };
			forestRoom.Description = "You are in open forest, with a deep valley to one side.";
			forestRoom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = forestRoom.RoomId });
			forestRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = forestRoom.RoomId });
			forestRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = startRoom.RoomId });

			hillRoom.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = startRoom.RoomId });
			hillRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = forestRoom.RoomId });
			hillRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = forestRoom.RoomId });
			hillRoom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = forestRoom.RoomId });

			startRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = hillRoom.RoomId });
			startRoom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = forestRoom.RoomId });
			startRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = hillRoom.RoomId });

			IFRoom buildingRoom = new IFRoom() { RoomId = 4 };
			buildingRoom.Description = "You are inside a building, a well house for a large spring.";
			buildingRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId=startRoom.RoomId });
			buildingRoom.Items.Add(new IFItem() { name = "keys", description = "There are some keys on the ground here.", itemId = 1 });
			buildingRoom.Items.Add(new IFItem() { name = "shiny brass lamp", description = "There is a shiny brass lamp nearby.", itemId = 2 });
			buildingRoom.Items.Add(new IFItem() { name = "tasty food", description = "There is tasty food here.", itemId = 3 });
			buildingRoom.Items.Add(new IFItem() { name = "bottle of water", description = "There is a bottle of water here.", itemId = 2 });
		}

		public void LoadGame(string file_name)
		{

		}

		public void SaveGame(string file_name)
		{

		}

		public void SaveState(string file_name)
		{

		}

		public void LoadState(string file_name)
		{

		}
	}
}