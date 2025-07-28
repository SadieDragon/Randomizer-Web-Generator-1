using System.Collections.Generic;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class CanCompleteTwilight
    {
        private static bool CanCompleteTwilightUtil(List<string> roomsInTwilight)
        {
            return ERLogicFunctions.HasReachedAllRooms(roomsInTwilight)
                // CanSurviveBonkDamage
                && (
                    !SettingUtils.BonksDamageEnabled()
                    || (
                        SettingUtils.BonksDamageEnabled()
                        && (!SettingUtils.IsOHKO() || BottleUtils.CanUseBottledFairies())
                    )
                );
        }

        /// <summary>
        /// Can complete Faron twilight
        /// </summary>
        public static bool CanCompleteFaronTwilight()
        {
            return SettingUtils.HasSkippedFaronTwilight()
                || (
                    CanDoStoryStuff.CanCompletePrologue()
                    && CanCompleteTwilightUtil(RoomFunctions.faronTwilightRooms)
                );
        }

        /// <summary>
        /// Can complete Eldin twilight
        /// </summary>
        public static bool CanCompleteEldinTwilight()
        {
            return SettingUtils.HasSkippedEldinTwilight()
                || CanCompleteTwilightUtil(RoomFunctions.eldinTwilightRooms);
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return SettingUtils.HasSkippedLanayruTwilight()
                || (
                    CanCompleteTwilightUtil(RoomFunctions.lanayruTwilightRooms)
                    && (
                        ERLogicFunctions.HasReachedRoom("North Eldin Field")
                        || CanUseUtils.CanUse(Item.Shadow_Crystal)
                    )
                );
        }

        public static bool CanCompleteAllTwilight()
        {
            return CanCompleteFaronTwilight()
                && CanCompleteEldinTwilight()
                && CanCompleteLanayruTwilight();
        }

        #region Glitched
        public static bool CanCompleteEldinTwilightGlitched()
        {
            return SettingUtils.HasSkippedEldinTwilight()
                || CanDoStoryStuff.CanClearForestGlitched();
        }
        #endregion
    }
}
