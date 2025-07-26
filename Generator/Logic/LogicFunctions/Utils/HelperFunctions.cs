using System;
using System.Collections.Generic;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class HelperFunctions
    {
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
                    && (!SettingUtils.IsOHKO() || BottleUtils.CanUseBottledFairies())
                );
        }

        public static int GetPlayerHealth()
        {
            double playerHealth = 3.0; // start at 3 since we have 3 hearts.

            //Pieces of heart are 1/5 of a heart.
            playerHealth += CanUseUtils.GetItemCount(Item.Piece_of_Heart) * 0.2;
            playerHealth += CanUseUtils.GetItemCount(Item.Heart_Container);

            return (int)playerHealth;
        }

        // TODO: Room funcs dir/helper util file?
        public static bool CanCompleteTwilight(List<string> roomsInTwilight)
        {
            return CanSurviveBonkDamage() && ERLogicFunctions.HasReachedAllRooms(roomsInTwilight);
        }
    }
}
