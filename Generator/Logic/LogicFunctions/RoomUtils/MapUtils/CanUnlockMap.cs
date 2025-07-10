using System.Collections.Generic;
using TPRandomizer;
using ERLF = LogicFunctionsNS.ERLogicFunctions;

namespace LogicFunctionsNS
{
    public class CanUnlockMap
    {
        public static bool CanUnlockMapUtil(List<string> roomsInMap)
        {
            return SettingUtils.IsOpenMap() || ERLF.HasReachedAnyRooms(roomsInMap);
        }

        public static bool CanUnlockOrdonaMap() => CanUnlockMapUtil(RoomFunctions.OrdonaMapRooms);

        public static bool CanUnlockFaronMap() => CanUnlockMapUtil(RoomFunctions.FaronMapRooms);

        public static bool CanUnlockEldinMap() => CanUnlockMapUtil(RoomFunctions.EldinMapRooms);

        public static bool CanUnlockLanayruMap() => CanUnlockMapUtil(RoomFunctions.LanayruMapRooms);

        public static bool CanUnlockSnowpeakMap()
        {
            return Randomizer.SSettings.skipSnowpeakEntrance
                || CanUnlockMapUtil(RoomFunctions.SnowpeakMapRooms);
        }

        public static bool CanUnlockGerudoMap() => CanUnlockMapUtil(RoomFunctions.GerudoMapRooms);
    }
}
