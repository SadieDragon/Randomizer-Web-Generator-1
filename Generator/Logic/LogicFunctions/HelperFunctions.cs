using System;
using System.Collections.Generic;
using TPRandomizer;
using BOU = LogicFunctionsNS.BottleUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;

namespace LogicFunctionsNS
{
    public class HelperFunctions
    {
        public static bool HasDamagingItem()
        {
            return HasSwordLevel.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || BombUtils.HasBombs()
                || CUU.CanUse(Item.Shadow_Crystal)
                || CUU.CanUse(Item.Spinner);
        }

        public static Item ConvertStrToItem(string item) => Enum.Parse<Item>(item);

        /// <summary>
        /// Checks for the ability to survive damage done by bonks in OHKO mode.
        /// </summary>
        /// /// <returns>`true` if so, else `false`.</returns>
        public static bool CanSurviveBonkDamage()
        {
            return !SettingUtils.BonksDamageEnabled()
                || (
                    SettingUtils.BonksDamageEnabled()
                    && (!SettingUtils.IsOHKO() || BOU.CanUseBottledFairies())
                );
        }

        public static int GetPlayerHealth()
        {
            double playerHealth = 3.0; // start at 3 since we have 3 hearts.

            //Pieces of heart are 1/5 of a heart.
            playerHealth += CUU.GetItemCount(Item.Piece_of_Heart) * 0.2;
            playerHealth += CUU.GetItemCount(Item.Heart_Container);

            return (int)playerHealth;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanChangeTime()
        {
            return CUU.CanUse(Item.Shadow_Crystal)
                || ERLF.HasReachedAnyRooms(RoomFunctions.timeFlowStages);
        }

        public static bool CanWarp()
        {
            return CUU.CanUse(Item.Shadow_Crystal)
                && ERLF.HasReachedAnyRooms(RoomFunctions.WarpableStages);
        }

        // TODO: Do i even need CSBD? can it be defined in here?
        // TODO: Room funcs dir/helper util file?
        public static bool CanCompleteTwilight(List<string> roomsInTwilight)
        {
            return CanSurviveBonkDamage() && ERLF.HasReachedAllRooms(roomsInTwilight);
        }
    }
}
