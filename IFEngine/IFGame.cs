namespace InteractiveFictionEngine
{
	public class IFGame
	{
		public string InstructionText { get; set; } = string.Empty;
		public string HelpText { get; set; } = string.Empty;
		public string InfoText { get; set; } = string.Empty;	
		public Dictionary<int,IFRoom> Rooms { get; set; } = new Dictionary<int, IFRoom>();
		public Dictionary<string, string> Aliases { get; set; } = new Dictionary<string, string>();
		public int startRoomId = 0;
		public void GenerateSampleContent()
		{
			InstructionText = "This is the sample content for the Interactive Fiction Game Engine.  This content is meant to test the abilities of the engine. ";
			InstructionText += "Direct me with commands of 1 or 2 words.  (Should you get stuck, type \"help\" or \"info\" for some hints).";

			IFRoom driveway = new IFRoom() { RoomId = 1, Description = "Driveway\r\n\r\n" };
			driveway.Description += "You are standing in the driveway of a regular blue and red brick house which stands to the east.  ";
			driveway.Description += "Around you is a typical suburban neighborhood at about the middle of a cul-de-sac.  ";

			IFRoom entry = new IFRoom() { RoomId = 2, Description = "House Entry\r\n\r\n" };
			entry.Description += "You are inside a regular blue and red brick house. You are standing in a small entry room.  ";
			entry.Description += "There is a small living room to the south or the entry coninues to the east.";

			IFRoom livingRoom = new IFRoom() { RoomId = 3, Description = "Living Room\r\n\r\n" };
			livingRoom.Description += "You are standing in a small living room.  Bookcases full of books lines the east wall.  There is a piano on the south wall ";
			livingRoom.Description += "and two chairs sitting along the west wall.  There are 2 windows overlooking the front yard to the west. ";
			livingRoom.Description += "This looks like a nice room to play music, read a book, or relax in the afternoon sun.";

			IFRoom upstairsBase = new IFRoom() { RoomId = 4, Description = "Base of the Stairs\r\n\r\n" };
			upstairsBase.Description += "You are standing at the base of the stairs.  The stairs go up to the south.  You can see a small entry to your west ";
			upstairsBase.Description += "and the family room to your east.";

			IFRoom upstairsLanding = new IFRoom() { RoomId = 5, Description = "Upstairs Landing\r\n\r\n" };
			upstairsLanding.Description += "You are at the top of a stairwell on the second floor.  This walkway leads to another room on the west.  ";
			upstairsLanding.Description += "There is a gallery of patriotic pictures on the west wall and a railing on the east that lets you see down into ";
			upstairsLanding.Description += "the great room down below.";

			IFRoom bonusRoom = new IFRoom() { RoomId = 6, Description = "Bonus Room\r\n\r\n" };
			bonusRoom.Description += "This is a large room that sits above the garage.  It is lined with tables along the walls where various equipment sits. ";
			bonusRoom.Description += "There is a large project table in the middle of the room.  The east wall has various shelves and drawers where supplies ";
			bonusRoom.Description += "seem to be kept.";

			IFRoom familyRoom = new IFRoom() { RoomId = 7, Description = "Family Room\r\n\r\n" };
			familyRoom.Description += "This feels like the center of the home.  There is a loveseat and couch on two sides with a fireplace on the east wall ";
			familyRoom.Description += "and a large television on the north wall. You can tell a lot of fun has happened within this room. To the west ";
			familyRoom.Description += "there is a stairwell that seems to lead to the basement.";

			IFRoom diningRoom = new IFRoom() { RoomId = 8, Description = "Dining Room\r\n\r\n" };
			diningRoom.Description += "This is where a family could sit and eat a meal.  The room (or more accurately the space between the family room and kitchen) ";
			diningRoom.Description += "is dominated by a white table and six chairs.  There is a computer desk and cabinets on the west wall. To the east is a ";
			diningRoom.Description += "doorway that leads to the garage and the kitchen lies to the south.";

			IFRoom kitchen = new IFRoom() { RoomId = 9, Description = "Kitchen\r\n\r\n" };
			kitchen.Description += "This room is on the southern most part of the house.  There are plenty of cupboards and drawers for the equipment and supplies ";
			kitchen.Description += "needed to prepare meals for the family.  All of the typical appliances are found here. There is a door to the west.";

			IFRoom pantry = new IFRoom() { RoomId = 10, Description = "Pantry\r\n\r\n" };
			pantry.Description += "This is a very small room.  It are where the family keeps there food.  There is various kinds of canned and dry foods here.";

			IFRoom garageEntry = new IFRoom() { RoomId = 11, Description = "Garage Entry\r\n\r\n" };
			garageEntry.Description += "This is a very small space.  There is really just a room to be able to take off your coat and move into the next room. ";
			garageEntry.Description += "On the south wall is a line of coat hooks with a shelf on top and a bench below.  A shelf for shoes are underneath. ";
			garageEntry.Description += "There are doors to the west and north here.";

			IFRoom laundryRoom = new IFRoom() { RoomId = 12, Description = "Laundry Room\r\n\r\n" };
			laundryRoom.Description += "This is a small room.  It's just wide enough to hold a washer and dryer side by side.  There are a couple of cupboards ";
			laundryRoom.Description += "above the washer and dryer where cleaning supplies are kept.";

			IFRoom garage = new IFRoom() { RoomId = 13, Description = "Garage\r\n\r\n" };
			garage.Description += "This is a very spacious garage where up to 4 cars could be kept.  There are currently 3 cars sitting in the bays with the ";
			garage.Description += "back bay being used for tools and working on projects.  There is a shiny red corvette sitting in the southern-most bay.";

			IFRoom upstairsHallway = new IFRoom() { RoomId = 14, Description = "Upstairs Hallway\r\n\r\n" };
			upstairsHallway.Description += "This is a narrow hallway leading between the family room and the back bedrooms of the house.";

			IFRoom upstairsBedroom1 = new IFRoom() { RoomId = 15, Description = "Bedroom 1\r\n\r\n" };
			upstairsBedroom1.Description += "This is a small bedroom on the west side of the house. Light flows in from the windows.  There is a small bed with ";
			upstairsBedroom1.Description += "a nightstand to the right.  On the left side of the bed is a medium sized artificial Christmas tree decorated with ";
			upstairsBedroom1.Description += "lights and decorations corresponding to the current month. ";

			IFRoom upstairsBedroom2 = new IFRoom() { RoomId = 16, Description = "Bedroom 2\r\n\r\n" };
			upstairsBedroom2.Description += "This is a small bedroom on the west side of the house.  Light flows in from the windows.  This room is decorated with ";
			upstairsBedroom2.Description += "various figurines and pictures depicting super heroes and book characters. There is a desk in the southwest corner.";

			IFRoom upstairsBathroom = new IFRoom() { RoomId = 17, Description = "Bathroom\r\n\r\n" };
			upstairsBathroom.Description += "This is a small bathroom with everything you'd expect to find in a bathroom including a bathtub with shower.";

			IFRoom masterBedroom = new IFRoom() { RoomId = 18, Description = "Master Bedroom\r\n\r\n" };
			masterBedroom.Description += "This bedroom is a bit larger than the other bedrooms on this level.  It is dominated by a queen-sized bed, dresser, ";
			masterBedroom.Description += "and a recliner.  Pictures of family decorate the walls.  There is a bathroom to the south connected to this bedroom.";

			IFRoom masterBathroom = new IFRoom() { RoomId = 19, Description = "Master Bathroom\r\n\r\n" };
			masterBathroom.Description += "This is a larger bathroom.  It has double sinks and a separate shower and tub.  The shower is surrounded with glass ";
			masterBathroom.Description += "and the tub is a soaker variety without jets.  There is a closet to the west.";

			IFRoom masterCloset = new IFRoom() { RoomId = 20, Description = "Master Closet\r\n\r\n" };
			masterCloset.Description += "This is a large closet filled with clothes and shoes of all kinds.  There is a shelf above that contains various items ";
			masterCloset.Description += "in storage.";

			IFRoom downstairBase = new IFRoom() { RoomId = 21, Description = "Bottom of Basement Stairs\r\n\r\n" };
			downstairBase.Description += "This is the bottom of the basement stairs.  There is a room to the west and an opening to a large room to the east.";

			IFRoom downstairFamilyRoom = new IFRoom() { RoomId = 22, Description = "Basement Family Room\r\n\r\n" };
			downstairFamilyRoom.Description += "This is a huge room.  There is a pool table closest to you and a high table with 8 chairs in the middle.  On the ";
			downstairFamilyRoom.Description += "west wall there is a kitchenette with a countertop and large sink. On the south side of the room is a large seating ";
			downstairFamilyRoom.Description += "area with 3 full-size couches and a large TV on the south wall. There is a hallway leading north of here.";

			IFRoom downstairHallway = new IFRoom() { RoomId = 23, Description = "Basement Hallway\r\n\r\n" };
			downstairHallway.Description += "This is a hallway leading to the back bedrooms in the basement.  There are doors on both sides of the hallway.";

			IFRoom downstairSinkRoom = new IFRoom() { RoomId = 24, Description = "Basement Wash Room\r\n\r\n" };
			downstairSinkRoom.Description += "This is a room that's part of the bathroom overall.  It contains a large cabinet and a double free-standing vanity. ";
			downstairSinkRoom.Description += "To the north there is a door that leads to one of the bedrooms and to the east is the rest of the bathroom.";

			IFRoom downstairBathRoom = new IFRoom() { RoomId = 25, Description = "Basement Bathroom\r\n\r\n" };
			downstairBathRoom.Description += "This is a small room off of the wash room where the shower and toilet are.  The shower has glass rolling bypass doors ";
			downstairBathRoom.Description += "and tile on the walls.";

			IFRoom downstairBedroom1 = new IFRoom() { RoomId = 26, Description = "Basement Bedroom 1\r\n\r\n" };
			downstairBedroom1.Description += "This is the smallest of the basement bedrooms.  There is no closet but there is a bed, desk, dresser, and wardrobe ";
			downstairBedroom1.Description += "where someone can hang their clothes.";

			IFRoom downstairBedroom2 = new IFRoom() { RoomId = 27, Description = "Basement Bedroom 2\r\n\r\n" };
			downstairBedroom2.Description += "This is a larger bedroom with a lot of space in it.  There is a small cube shelf on the south wall and the head of ";
			downstairBedroom2.Description += "the twin-sized bed is on the north wall.  There is a small nightstand to the left of the bed.";

			IFRoom downstairBedroom3 = new IFRoom() { RoomId = 28, Description = "Basement Bedroom 3\r\n\r\n" };
			downstairBedroom3.Description += "This is the largest of the basement bedrooms and probably the largest of the house.  It has a large king-sized bed ";
			downstairBedroom3.Description += "in the middle of the north wall.  It is flanked by two nightstands.  The nightstand on the left's base is in the ";
			downstairBedroom3.Description += "shape of an elephant.  There is a doorway leading to the washroom to the south.";

			IFRoom mechanicalRoom = new IFRoom() { RoomId = 29, Description = "Mechanical Room\r\n\r\n" };
			mechanicalRoom.Description += "This is a medium-sized unfinished room.  The walls and ceiling are studs and the floor is concrete.  There are various ";
			mechanicalRoom.Description += "mechanical items on the south side of the room including a furnace, water softener, and a hot water heater. There is a ";
			mechanicalRoom.Description += "door to the west.";

			IFRoom coldRoom = new IFRoom() { RoomId = 30, Description = "Cold Room\r\n\r\n" };
			coldRoom.Description += "This is a small room that sits under the front porch.  All of the walls are cement and the temperature is noticeably colder here. ";
			coldRoom.Description += "On one wall there are shelves with various long-term food and supply storage along with various suitcases and other storage items.";

			//Connect exits for driveway
			driveway.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = entry.RoomId });

			//Connect exits for entry
			entry.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = driveway.RoomId });
			entry.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = livingRoom.RoomId });
			entry.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = upstairsBase.RoomId });

			//Connect exits for livingRoom
			livingRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = entry.RoomId });

			//Connect exits for upstairBase
			upstairsBase.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = entry.RoomId });
			upstairsBase.Exits.Add(new IFExit() { direction = IFDirection.Up, roomId = upstairsLanding.RoomId });
			upstairsBase.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = familyRoom.RoomId });

			//Connect exits for upstairsLanding

			upstairsLanding.Exits.Add(new IFExit() { direction = IFDirection.Down, roomId = upstairsBase.RoomId });
			upstairsLanding.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = bonusRoom.RoomId });

			//Connect exits for bonusRoom

			bonusRoom.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = upstairsLanding.RoomId });

			//Connect exits for familyRoom

			familyRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = upstairsBase.RoomId });
			familyRoom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = diningRoom.RoomId });
			familyRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = upstairsHallway.RoomId });
			familyRoom.Exits.Add(new IFExit() { direction = IFDirection.Down, roomId = downstairBase.RoomId });

			//Connect exits for diningRoom

			diningRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = familyRoom.RoomId });
			diningRoom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = kitchen.RoomId});
			diningRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = garageEntry.RoomId });

			//Connect exits for kitchen

			kitchen.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = diningRoom.RoomId });
			kitchen.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = pantry.RoomId });

			//Connect exits for pantry

			pantry.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = kitchen.RoomId });

			//Connect exits for garageEntry

			garageEntry.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = diningRoom.RoomId });
			garageEntry.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = laundryRoom.RoomId });
			garageEntry.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = garage.RoomId });

			//Connect exits for laundryRoom

			laundryRoom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = garageEntry.RoomId });

			//Connect exits for garage

			garage.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = garageEntry.RoomId });

			//Connect exits for upstairsHallway

			upstairsHallway.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = familyRoom.RoomId });
			upstairsHallway.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = upstairsBedroom1.RoomId });
			upstairsHallway.Exits.Add(new IFExit() { direction = IFDirection.NorthWest, roomId = upstairsBedroom2.RoomId });
			upstairsHallway.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = upstairsBathroom.RoomId });
			upstairsHallway.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = masterBedroom.RoomId });

			//Connect exits for upstairsBedroom1

			upstairsBedroom1.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = upstairsHallway.RoomId });

			//Connect exits for upstairsBedroom2

			upstairsBedroom2.Exits.Add(new IFExit() { direction = IFDirection.SouthEast, roomId = upstairsHallway.RoomId });

			//Connect exits for upstairsBathroom

			upstairsBathroom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = upstairsHallway.RoomId });

			//Connect exits for masterBedroom

			masterBedroom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = upstairsHallway.RoomId });
			masterBedroom.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = masterBathroom.RoomId });

			//Connect exits for masterBathroom

			masterBathroom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = masterBedroom.RoomId});
			masterBathroom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = masterCloset.RoomId });

			//Connect exits for masterCloset

			masterCloset.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = masterBathroom.RoomId });

			//Connect exits for downstairBase

			downstairBase.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = mechanicalRoom.RoomId });
			downstairBase.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = downstairFamilyRoom.RoomId });
			downstairBase.Exits.Add(new IFExit() { direction = IFDirection.Up, roomId = familyRoom.RoomId });

			//Connect exits for downstairFamilyRoom

			downstairFamilyRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = downstairBase.RoomId });
			downstairFamilyRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = downstairHallway.RoomId });

			//Connect exits for downstairHallway

			downstairHallway.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = downstairFamilyRoom.RoomId });
			downstairHallway.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = downstairBedroom1.RoomId });
			downstairHallway.Exits.Add(new IFExit() { direction = IFDirection.NorthWest, roomId = downstairBedroom2.RoomId });
			downstairHallway.Exits.Add(new IFExit() { direction = IFDirection.NorthEast, roomId = downstairBedroom3.RoomId });
			downstairHallway.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = downstairSinkRoom.RoomId });

			//Connect exits for downstairSinkRoom

			downstairSinkRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = downstairHallway.RoomId });
			downstairSinkRoom.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = downstairBathRoom.RoomId });
			downstairSinkRoom.Exits.Add(new IFExit() { direction = IFDirection.North, roomId = downstairBedroom3.RoomId});

			//Connect exits for downstairBathRoom

			downstairBathRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = downstairSinkRoom.RoomId});

			//Connect exits for downstairBedroom1

			downstairBedroom1.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = downstairHallway.RoomId});

			//Connect exits for downstairBedroom2

			downstairBedroom2.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = downstairHallway.RoomId });

			//Connect exits for downstairBedroom3

			downstairBedroom3.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = downstairHallway.RoomId });
			downstairBedroom3.Exits.Add(new IFExit() { direction = IFDirection.South, roomId = downstairSinkRoom.RoomId });

			//Connect exits for mechanicalRoom

			mechanicalRoom.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = downstairBase.RoomId });
			mechanicalRoom.Exits.Add(new IFExit() { direction = IFDirection.West, roomId = coldRoom.RoomId });

			//Connect exits for coldRoom

			coldRoom.Exits.Add(new IFExit() { direction = IFDirection.East, roomId = mechanicalRoom.RoomId });

			//Add All rooms to the Game

			Rooms.Add(driveway.RoomId, driveway);
			Rooms.Add(entry.RoomId, entry);
			Rooms.Add(livingRoom.RoomId, livingRoom);
			Rooms.Add(upstairsBase.RoomId, upstairsBase);
			Rooms.Add(upstairsLanding.RoomId, upstairsLanding);
			Rooms.Add(bonusRoom.RoomId, bonusRoom);
			Rooms.Add(familyRoom.RoomId, familyRoom);
			Rooms.Add(diningRoom.RoomId, diningRoom);
			Rooms.Add(kitchen.RoomId, kitchen);
			Rooms.Add(pantry.RoomId, pantry);
			Rooms.Add(garageEntry.RoomId, garageEntry);
			Rooms.Add(laundryRoom.RoomId, laundryRoom);
			Rooms.Add(garage.RoomId, garage);
			Rooms.Add(upstairsHallway.RoomId, upstairsHallway);
			Rooms.Add(upstairsBedroom1.RoomId, upstairsBedroom1);
			Rooms.Add(upstairsBedroom2.RoomId, upstairsBedroom2);
			Rooms.Add(upstairsBathroom.RoomId, upstairsBathroom);
			Rooms.Add(masterBedroom.RoomId, masterBedroom);
			Rooms.Add(masterBathroom.RoomId, masterBathroom);
			Rooms.Add(masterCloset.RoomId, masterCloset);
			Rooms.Add(downstairBase.RoomId, downstairBase);
			Rooms.Add(downstairFamilyRoom.RoomId, downstairFamilyRoom);
			Rooms.Add(downstairHallway.RoomId, downstairHallway);
			Rooms.Add(downstairSinkRoom.RoomId, downstairSinkRoom);
			Rooms.Add(downstairBathRoom.RoomId, downstairBathRoom);
			Rooms.Add(downstairBedroom1.RoomId, downstairBedroom1);
			Rooms.Add(downstairBedroom2.RoomId, downstairBedroom2);
			Rooms.Add(downstairBedroom3.RoomId, downstairBedroom3);
			Rooms.Add(mechanicalRoom.RoomId, mechanicalRoom);
			Rooms.Add(coldRoom.RoomId, coldRoom);

			startRoomId = 1;
		}

		public void GenerateAliasList()
		{
			//Movement Aliases

			Aliases.Add("n", "north");
			Aliases.Add("s", "south");
			Aliases.Add("e", "east");
			Aliases.Add("w", "west");
			Aliases.Add("nw", "northwest");
			Aliases.Add("ne", "northeast");
			Aliases.Add("sw", "southwest");
			Aliases.Add("se", "southeast");
			Aliases.Add("u", "up");
			Aliases.Add("d", "down");
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