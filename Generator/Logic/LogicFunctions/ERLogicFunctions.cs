using System.Collections.Generic;
using System.Linq;
using TPRandomizer;

namespace LogicFunctionsNS
{
    class ERLogicFunctions
    {
        public static SharedSettings SharedSettings = Randomizer.SSettings;

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

        /// <summary>
        /// Checks for if it is not shop sanity, and if the room can be accessed.
        /// </summary>
        /// <param name="Room">Name of the room to check.</param>
        /// <returns>`true` if the shop room can be accessed and not shopsanity, else `false`.</returns>
        public static bool CanShopFromRoom(string Room)
        {
            return HasReachedRoom(Room) && !SharedSettings.shuffleShopItems;
        }

        /// <summary>
        /// Checks each room to see if it has been reached.
        /// </summary>
        /// <param name="ListOfRooms">The list of rooms to check.</param>
        /// <returns>A list of booleans representing whether the rooms have been reached.</returns>
        /// <remarks>Could probably have a dict for clarity, but the keys seem never needed.</remarks>
        private static List<bool> CheckReachedRooms(List<string> ListOfRooms)
        {
            List<bool> HasReached = [];
            foreach (string MapRoom in ListOfRooms)
            {
                HasReached.Add(HasReachedRoom(MapRoom));
            }

            return HasReached;
        }

        /// <summary>
        /// Checks if any of the maps within a given list of rooms have been reached.
        /// </summary>
        /// <param name="ListOfRooms">The list of rooms to check.</param>
        /// <returns>`true` if any rooms have been reached, else `false`.</returns>
        public static bool HasReachedAnyRooms(List<string> ListOfRooms)
        {
            return CheckReachedRooms(ListOfRooms).Any(x => true);
        }

        /// <summary>
        /// Cycles through the list of rooms requested to check if all the rooms on that map have been reached.
        /// </summary>
        /// <param name="RoomsOnMap" >The list of maps to check.</param>
        /// <returns>`true` if open map or all rooms reached, else `false`.<returns>
        public static bool CanUnlockRegionalMap(List<string> RoomsOnMap)
        {
            // If openMap is true, then the map is already open.
            // Otherwise, we need to check if any rooms on the map have been accessed.
            return SharedSettings.openMap || HasReachedAnyRooms(RoomsOnMap);
        }

        public static bool HasReachedBarnesBombs()
        {
            return HasReachedRoom("Kakariko Barnes Bomb Shop Lower");
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
