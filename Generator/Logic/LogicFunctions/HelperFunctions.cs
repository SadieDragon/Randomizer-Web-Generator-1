using System.Collections.Generic;
using System.Reflection;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using BOU = LogicFunctionsNS.BottleUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using ERLF = LogicFunctionsNS.ERLogicFunctions;

namespace LogicFunctionsNS
{
    class HelperFunctions
    {
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool EvaluateSetting(string setting, string value)
        {
            PropertyInfo[] settingProperties = Randomizer.SSettings.GetType().GetProperties();
            setting = setting.Replace("Setting.", "");

            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(Randomizer.SSettings, null);
                if ((property.Name == setting) && (value == settingValue.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static SharedSettings SharedSettings = Randomizer.SSettings;

        /// <summary>
        /// Checks for the ability to survive damage done by bonks in OHKO mode.
        /// </summary>
        /// /// <returns>`true` if so, else `false`.</returns>
        public static bool CanSurviveBonkDamage()
        {
            // Check the setting "bonksDoDamage"
            bool BonksDamageEnabled = SharedSettings.bonksDoDamage;

            // Check the setting "damageMagnification"
            bool IsOHKO = SharedSettings.damageMagnification == DamageMagnification.OHKO;

            return !BonksDamageEnabled
                || (BonksDamageEnabled && (!IsOHKO || BOU.CanUseBottledFairies()));
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
