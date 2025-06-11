using TPRandomizer;

namespace LogicFunctionsNS
{
    class ERLogicFunctions
    {
        public static bool HasReachedRoom(string room)
        {
            // This ensures that the key (room name) must exist in the dictionary.
            if (Randomizer.Rooms.RoomDict.TryGetValue(room, out var RoomData))
            {
                return RoomData.ReachedByPlaythrough;
            }

            // If it does not, then print a warning to the console and return false.
            // If this occurs, there is a bug, and it needs to be fixed.
            System.Console.WriteLine(
                $"Warning: Room '{room}' not found in the dictionary. [`HasReachedRoom` ERLogicFunctions]"
            );
            return false;
        }

        public static bool HasReachedCTGoronShop()
        {
            return HasReachedRoom("Castle Town Goron House");
        }

        public static bool HasReachedBarnesBombs()
        {
            return HasReachedRoom("Kakariko Barnes Bomb Shop Lower");
        }

        public static bool HasReachedEFBombfishGrotto()
        {
            return HasReachedRoom("Eldin Field Water Bomb Fish Grotto");
        }

        public static bool HasReachedKakMaloMart()
        {
            return HasReachedRoom("Kakariko Malo Mart");
        }

        public static bool HasReachedLakeHylia()
        {
            return HasReachedRoom("Lake Hylia");
        }

        public static bool HasReachedLowerKakVillage()
        {
            return HasReachedRoom("Lower Kakariko Village");
        }

        public static bool HasReachedNFaronWoods()
        {
            return HasReachedRoom("North Faron Woods");
        }

        public static bool HasReachedSCastleTown()
        {
            return HasReachedRoom("Castle Town South");
        }

        public static bool HasReachedSFaronWoods()
        {
            return HasReachedRoom("South Faron Woods");
        }

        public static bool HasReachedZorasThroneRoom()
        {
            return HasReachedRoom("Zoras Domain Throne Room");
        }
    }
}
