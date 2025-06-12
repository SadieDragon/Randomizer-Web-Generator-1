using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

// Notes:
//   - Can I break this down?
//     - Hidden Skill counting
//     - General item counting (Sword, claws, active dr)

namespace LogicFunctionsNS
{
    class HelperFunctions
    {
        public static SharedSettings SharedSettings = Randomizer.SSettings;

        public static List<Item> ItemList = Randomizer.Items.heldItems;

        public static bool CanReplenishItem(Item item)
        {
            Dictionary<Item, bool> ItemRefills = new()
            {
                { Item.Lantern, LF.CanRefillOil() },
                { Item.Progressive_Bow, LF.CanGetArrows() },
            };

            if (ItemRefills.TryGetValue(item, out var check))
            {
                return check;
            }
            return true;
        }

        public static bool CanUse(Item item)
        {
            return ItemList.Contains(item) && CanReplenishItem(item);
        }

        /// <summary>
        /// Count the number of a given item available, including if the item can
        /// be replenished.
        /// </summary>
        /// <param name="ItemToBeCounted">(Item) Item to be counted.</param>
        /// <returns>Returns the amount available.</returns>
        public static int GetItemCount(Item ItemToBeCounted)
        {
            // Only count how many of the item there are if it can be replenished
            if (CanReplenishItem(ItemToBeCounted))
            {
                return ItemList.Count(item_ => item_ == ItemToBeCounted);
            }
            // Fallback of "0"
            return 0;
        }

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
                || (BonksDamageEnabled && (!IsOHKO || LF.CanUseBottledFairies()));
        }

        public static bool CanFishForWaterBombs()
        {
            return ERLF.HasReachedRoom("Eldin Field Water Bomb Fish Grotto")
                && CanUse(Item.Progressive_Fishing_Rod);
        }

        public static bool HasBombs()
        {
            return CanUse(Item.Filled_Bomb_Bag)
                && (
                    ERLF.HasReachedBarnesBombs()
                    || CanFishForWaterBombs()
                    || ERLF.HasReachedRoom("City in The Sky Entrance")
                );
        }

        public static bool HasShieldAttack()
        {
            return GetItemCount(Item.Progressive_Hidden_Skill) >= 2;
        }

        public static bool CanShieldAttack()
        {
            return LF.hasShield() && HasShieldAttack();
        }

        public static bool HasBackslice()
        {
            return GetItemCount(Item.Progressive_Hidden_Skill) >= 3;
        }

        public static bool HasJumpStrike()
        {
            return GetItemCount(Item.Progressive_Hidden_Skill) >= 6;
        }
    }
}
