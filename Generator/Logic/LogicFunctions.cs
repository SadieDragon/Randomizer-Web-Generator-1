using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TPRandomizer.SSettings.Enums;

/// TODO:
///   - Re-order the CanDefeat things to be alphabet
///   - Standardize comments
///   - Standardize variable names
///   - Clean up comments
///   - All glitched logic things should be in their own functions.
///   - Frankly, should Niche stuff also be their own functions?

namespace TPRandomizer
{
    /// <summary>
    /// The collection of logic functions.
    /// Evaluate the tokenized settings to their respective values that are set by the settings string.
    /// </summary>
    public class LogicFunctions
    {
        // class WrapperFunctions

        /// <summary>
        /// A quick helper function to check if any values within a list are true.
        /// </summary>
        /// <param name="ListToCheck">The list of booleans to check.</param>
        /// <returns>`true` if any are true, else `false`.</returns>
        public static bool AnyTrue(List<bool> ListToCheck)
        {
            return ListToCheck.Any(x => true);
        }

        // End of WrapperFunctions

        // TODO: Figure out what this does.
        /// <summary>
        /// Need who wrote this to fill this out.
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EvaluateSetting(string setting, string value)
        {
            // Grab the setting properties.
            PropertyInfo[] settingProperties = Randomizer.SSettings.GetType().GetProperties();

            // Remove the prefix from the setting.
            setting = setting.Replace("Setting.", "");

            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(Randomizer.SSettings, null);
                if ((property.Name == setting) && (value == settingValue.ToString()))
                {
                    // Break early.
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifies the quantity of an item.
        /// </summary>
        /// <param name="itemToBeCounted">The item that is to be counted.</param>
        /// <param name="quantity">The minimum quantity expected.</param>
        /// <returns>`true` if at least `quantity` of `itemToBeCounted` exists, else `false`.</returns>
        public static bool verifyItemQuantity(string itemToBeCounted, int quantity)
        {
            // Shorthand for the `heldItems`.
            List<Item> heldItems = Randomizer.Items.heldItems;

            // Convert heldItems to string to check against.
            List<string> heldStringItems = heldItems.ConvertAll(static item => item.ToString());

            // Count how many of the desired item there are.
            int itemQuantity = heldStringItems.Count(item => item == itemToBeCounted);

            // Return if the quantity found is more than the desired quantity.
            return itemQuantity >= quantity;
        }

        // class HasItem

        /// <summary>
        /// A shorthand for `Randomizer.Items.heldItems`
        /// </summary>
        private static List<Item> heldItems = Randomizer.Items.heldItems;

        /// <summary>
        /// Checks for if an item has been obtained.
        /// </summary>
        /// <param name="item">This function uses the Item class.</param>
        /// <returns>`true` if item can be found in the list of items, otherwise `false`.</returns>
        public static bool CanUse(Item item)
        {
            return heldItems.Contains(item);
        }

        /// <summary>
        /// Checks for if an item has been obtained.
        /// </summary>
        /// <param name="item">This function uses the string class.</param>
        /// <returns>`true` if item can be found in the list of items, otherwise `false`.</returns>
        public static bool CanUse(string item)
        {
            // Convert heldItems to string to check against.
            List<string> heldStringItems = heldItems.ConvertAll(static item => item.ToString());

            // Check if the desired item is available.
            return heldStringItems.Contains(item);
        }

        /// <summary>
        /// Count the number of a given item available.
        /// </summary>
        /// <param name="itemToBeCounted">(Item) Item to be counted.</param>
        /// <returns>Returns the amount available.</returns>
        public static int getItemCount(Item itemToBeCounted)
        {
            return heldItems.Count(item => item == itemToBeCounted);
        }

        /// <summary>
        /// Counts the items on the Item Wheel.
        /// </summary>
        /// <returns>Returns the amount of items on the Item Wheel.</returns>
        public static int GetItemWheelSlotCount()
        {
            int count = 0;

            foreach (Item item in Randomizer.Items.ItemWheelItems)
            {
                if (CanUse(item))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Count how much health the player has by totaling the value of
        /// how many heart pieces and containers they have obtained.
        /// </summary>
        /// <returns>The total health of the player.</returns>
        public static int GetPlayerHealth()
        {
            double playerHealth = 3.0; // start at 3 since we have 3 hearts.

            playerHealth = playerHealth + (getItemCount(Item.Piece_of_Heart) * 0.2); //Pieces of heart are 1/5 of a heart.
            playerHealth = playerHealth + getItemCount(Item.Heart_Container);

            return (int)playerHealth;
        }

        /// <summary>
        /// Checks for access to Lost Woods, the ability to buy arrows from Malo Mart, or the ability to buy arrows from the Goron shop in Castle Town.
        /// </summary>
        /// <returns>`true` if any of the above conditions are met, else `false`.</returns>
        public static bool CanGetArrows()
        {
            return HasReachedRoom("Lost Woods")
                || (canCompleteGoronMines() && HasReachedRoom("Kakariko Malo Mart"))
                || CanShopFromRoom("Castle Town Goron House Balcony");
        }

        /// <summary>
        /// Checks for Ball and Chain, Slingshot, Bow and the ability to refill the quiver,
        /// Clawshot, or Boomerang.
        /// </summary>
        /// <returns>`true` if any of the above conditions are met, else `false`.</returns>
        public static bool hasRangedItem()
        {
            return CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Slingshot)
                || HasBowAndArrows
                || CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Boomerang);
        }

        /// <summary>
        /// Checks if any bugs are available.
        /// </summary>
        /// <returns>`true` if any of the above conditions are met, else `false`.</returns>
        public static bool HasBug()
        {
            // TODO: Check if this is actually correct.
            return Randomizer.Items.goldenBugs.Any(CanUse);
        }

        // subclass Bombs
        // Might wanna rename this but hey - Lupa

        /// <summary>
        /// Checks for access to the water bomb fish grotto in Eldin Field, and the fishing rod.
        /// </summary>
        private static bool CanFishForWaterBombs =
            HasReachedRoom("Eldin Field Water Bomb Fish Grotto")
            && CanUse(Item.Progressive_Fishing_Rod);

        private static bool CanUseBombBag = CanUse(Item.Filled_Bomb_Bag);

        /// <summary>
        /// Checks for a bomb bag and (either the ability to buy bombs from barnes, fish for water bombs, or buy bombs in City in the Sky)
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool hasBombs()
        {
            return CanUseBombBag
                && (
                    HasReachedBarnesBombsLower
                    || CanFishForWaterBombs
                    || HasReachedRoom("City in The Sky Entrance")
                );
        }

        /// <summary>
        /// Checks for a bomb bag, and (The ability to reach Barnes' Bomb Shop, the ability to fish for water bombs,
        /// or the ability to buy bombs from Castle Town Malo Mart).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanUseWaterBombs()
        {
            return CanUseBombBag
                && (
                    HasReachedBarnesBombsLower
                    || CanFishForWaterBombs
                    || (HasReachedBarnesBombsLower && HasReachedRoom("Castle Town Malo Mart"))
                );
        }

        /// <summary>
        /// Checks for Bombs and (Boomerang or Bow).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool canLaunchBombs()
        {
            return hasBombs() && (CanUse(Item.Boomerang) || CanUse(Item.Progressive_Bow));
        }

        // End of Bombs

        // subclass Bottles
        // Might wanna rename this but hey -Lupa

        /// <summary>
        /// Counts how many bottles are available.
        /// </summary>
        /// <returns>A count of how many bottles are available.</returns>
        public static int AvailableBottles()
        {
            // A list representing if the bottle has been obtained.
            List<bool> BottlesObtained = new()
            {
                CanUse(Item.Empty_Bottle),
                CanUse(Item.Sera_Bottle),
                CanUse(Item.Jovani_Bottle),
                CanUse(Item.Coro_Bottle),
            };

            // Count how many are true.
            return BottlesObtained.Count(x => true);
        }

        /// <summary>
        /// Check if at least 1 bottle and the Lantern is available.
        /// </summary>
        /// <returns>`true` if at least 1 bottle and the Lantern are available, else `false`.</returns>
        public static bool HasBottle()
        {
            return (AvailableBottles() >= 1) && CanUse(Item.Lantern);
        }

        /// <summary>
        /// Checks if more than 1 bottle and the Lantern are available.
        /// </summary>
        /// <returns>`true` if more than 1 bottle and the Lantern are available, else `false`.</returns>
        public static bool HasBottles()
        {
            return (AvailableBottles() > 1) && CanUse(Item.Lantern);
        }

        /// <summary>
        /// Checks for a Bottle and access to Lake Hylia.
        /// </summary>
        /// <returns>`true` if a Bottle is available and there is access to Lake Hylia.</returns>
        public static bool CanUseBottledFairy()
        {
            return HasBottle() && HasReachedLakeHylia;
        }

        /// <summary>
        /// Checks for multiple Bottles and access to Lake Hylia.
        /// </summary>
        /// <returns>`true` if multiple Bottles are available and there is access to Lake Hylia.</returns>
        public static bool CanUseBottledFairies()
        {
            return HasBottles() && HasReachedLakeHylia;
        }

        /// <summary>
        /// Checks for Lantern and the Bottle of Oil (Coro's).
        /// </summary>
        /// <returns>`true` if both are available, else `false`.</returns>
        public static bool CanUseOilBottle()
        {
            return CanUse(Item.Lantern) && CanUse(Item.Coro_Bottle);
        }

        /// <summary>
        /// Checks for a Bottle AND (Access to Lower Kakariko Village OR
        // (Access to Death Mountain Elevator Lower with the ability to defeat Gorons)).
        /// </summary>
        /// <returns>`true` if the above are met, else `false`.</returns>
        public static bool canGetHotSpringWater()
        {
            return HasBottle()
                && (
                    HasReachedRoom("Lower Kakariko Village")
                    || (HasReachedRoom("Death Mountain Elevator Lower") && CanDefeatGoron())
                );
        }

        // End of Bottles

        /// <summary>
        /// Checks for a Hylian Shield, the ability to shop from Kakariko Malo Mart, the ability to shop from the Goron Shop in Castle Town for
        // a Hylian Shield, or access to the Death Mountain shop.
        /// </summary>
        /// <returns></returns>
        public static bool hasShield()
        {
            return CanUse(Item.Hylian_Shield)
                || CanShopFromRoom("Kakariko Malo Mart")
                || CanShopFromRoom("Castle Town Goron House")
                || HasReachedRoom("Death Mountain Hot Spring");
        }

        /// <summary>
        /// Whether or not a Sword has been obtained.
        /// </summary>
        /// <returns>`true` if there is at least one sword, else `false`.</returns>
        public static bool HasSword()
        {
            return CanUse(Item.Progressive_Sword);
        }

        /// <summary>
        /// Whether or not a Bow has been obtained and arrows can be restocked.
        /// </summary>
        private static bool HasBowAndArrows = CanUse(Item.Progressive_Bow) && CanGetArrows();

        /// <summary>
        /// Checks for the ability to obtain or own a shield, as well as if at least 2 hidden skills have been obtained.
        /// </summary>
        private static bool HasShieldAttack =
            hasShield() && (getItemCount(Item.Progressive_Hidden_Skill) >= 2);

        /// <summary>
        /// Checks for at least 3 hidden skills.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool HasBackslice()
        {
            return getItemCount(Item.Progressive_Hidden_Skill) >= 3;
        }

        /// <summary>
        /// Checks for at least 6 hidden skills.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool HasJumpStrike()
        {
            return getItemCount(Item.Progressive_Hidden_Skill) >= 6;
        }

        // subclass CanDo

        /// <summary>
        /// Checks for if Midna's Desperate Hour can be completed, and if all twilights can be completed.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanMidnaCharge()
        {
            return CanCompleteMDH() && CanCompleteAllTwilight();
        }

        /// <summary>
        /// Checks for any damaging item (excluding backslice), Clawshot,
        /// or (ShieldAttack with the ability to do Niche things.)
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canBreakMonkeyCage()
        {
            return HasAnyDamagingItem(["Backslice"])
                || CanUse(Item.Progressive_Clawshot)
                || (CanDoNicheStuff() && HasShieldAttack);
        }

        /// <summary>
        /// Checks for Shadow Crystal, Sword, (bombs or ball and chain),
        /// or the ability to use backslice as a sword.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canBreakWoodenDoor()
        {
            return CanUse(Item.Shadow_Crystal)
                || HasSword()
                || canSmash()
                || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// Checks for Lantern, Bombs, or Ball and Chain.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canBurnWebs()
        {
            return CanUse(Item.Lantern) || canSmash();
        }

        /// <summary>
        /// Checks for Clawshot, Bow and the ability to refill the quiver,
        /// Boomerang, or Ball and Chain.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canCutHangingWeb()
        {
            return CanUse(Item.Progressive_Clawshot)
                || HasBowAndArrows
                || CanUse(Item.Boomerang)
                || CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// Checks for 6 expressions:
        /// <para>- The ability to break monkey cages.</para>
        /// <para>- Lantern or (Keysy and (Bombs or Boots)).</para>
        /// <para>- The ability to burn webs.</para>
        /// <para>- Boomerang.</para>
        /// <para>- The ability to defeat Bokoblins.</para>
        /// <para>- All 4 keys or Keysy.</para>
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canFreeAllMonkeys()
        {
            bool IsKeysy = Randomizer.SSettings.smallKeySettings == SmallKeySettings.Keysy;

            return canBreakMonkeyCage()
                && (CanUse(Item.Lantern) || (IsKeysy && (hasBombs() || CanUse(Item.Iron_Boots))))
                && canBurnWebs()
                && CanUse(Item.Boomerang)
                && CanDefeatBokoblin()
                && ((getItemCount(Item.Forest_Temple_Small_Key) >= 4) || IsKeysy);
        }

        /// <summary>
        /// Checks for Bow or
        /// (the ability to do niche things AND (bombs or (Sword and 6 hidden skills))).
        /// Also checks for the glitched requirements: Sword,
        /// the ability to do moonboots, or the ability to do Backslice Moon Boots.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canKnockDownHCPainting()
        {
            return CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && (hasBombs() || (HasSword() && HasJumpStrike())))
                || (IsGlitchedLogic && ((HasSword() && CanDoMoonBoots()) || CanDoBSMoonBoots()));
        }

        /// <summary>
        /// Checks for Iron Boots or (The ability to do niche stuff and the Ball and Chain).
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canPressMinesSwitch()
        {
            return CanUse(Item.Iron_Boots) || (CanDoNicheStuff() && CanUse(Item.Ball_and_Chain));
        }

        /// <summary>
        /// Checks for Ball and Chain or Bombs.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool canSmash()
        {
            return CanUse(Item.Ball_and_Chain) || hasBombs();
        }

        /// <summary>
        /// Checks if the acquired sword level matches the setting requirements.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanStrikePedestal()
        {
            return getItemCount(Item.Progressive_Sword) >= (int)Randomizer.SSettings.totEntrance;
        }

        // end of CanDo

        // subclass HasAnyDamagingItem
        // NOTE: Of all the things, I am least proud of this chunk.
        //  No matter what I do, I am not satisifed with my solutions.
        // - Lupa

        /// <summary>
        /// Checks for if either the Ball and Chain or a Sword is available.
        /// </summary>
        private static bool HasSwordOrBallAndChain = HasSword() || CanUse(Item.Ball_and_Chain);

        /// <summary>
        /// Checks for one of a list of damaging items. Allows for one or more of that list to not be excluded from the check.
        /// List of damaging items: Sword, Ball and Chain, Bombs, Boots, Bow, Shadow Crystal, Spinner, Backslice (if can be used).
        /// List of expected item names: "Bombs", "Boots", "Bow", "Shadow_Crystal", "Spinner", "Backslice".
        /// </summary>
        /// <param name="exclusions">Optional (defaults to null for no exclusions). Pass a list of item names to not check for them.</param>
        /// <returns>`true` if any of the items are available, else `false`.</returns>
        public static bool HasAnyDamagingItem(List<string> exclusions = null)
        {
            // This checks for null and creates an empty list.
            exclusions ??= new List<string>();

            return HasSwordOrBallAndChain
                || (!exclusions.Contains("Backslice") && CanUseBacksliceAsSword())
                || (!exclusions.Contains("Bombs") && hasBombs())
                || (!exclusions.Contains("Boots") && CanFightWithBoots)
                || (!exclusions.Contains("Bow") && HasBowAndArrows)
                || (!exclusions.Contains("Shadow_Crystal") && CanUse(Item.Shadow_Crystal))
                || (!exclusions.Contains("Spinner") && CanUse(Item.Spinner));
        }

        // End of HasAnyDamagingItem

        // End of HasItem

        // class EntranceRandomizerLogic[Functions]

        /// <summary>
        /// A function for this file to use. Checks if the provided room has been reached by the playthrough.
        /// </summary>
        /// <param name="room">Name of the room to check.</param>
        /// <returns>`true` if the room has been reached, else `false`.</returns>
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
                $"Warning: Room '{room}' not found in the dictionary. [`HasReachedRoom` of LogicFunctions.cs]"
            );
            return false;
        }

        /// <summary>
        /// Checks each room to see if it has been reached.
        /// </summary>
        /// <param name="ListOfRooms">The list of rooms to check.</param>
        /// <returns>A list of booleans representing whether the rooms have been reached.</returns>
        /// <remarks>Could probably have a dict for clarity, but the keys seem never needed.</remarks>
        public static List<bool> CheckReachedRooms(List<string> ListOfRooms)
        {
            List<bool> hasReached = [];
            foreach (string mapRoom in ListOfRooms)
            {
                hasReached.Add(HasReachedRoom(mapRoom));
            }

            return hasReached;
        }

        /// <summary>
        /// Checks if all of the maps within a given list of rooms have been reached.
        /// </summary>
        /// <param name="ListOfRooms">The list of rooms to check.</param>
        /// <returns> `true` if all rooms have been reached, else `false`. </returns>
        public static bool HasReachedAllRooms(List<string> ListOfRooms)
        {
            return CheckReachedRooms(ListOfRooms).All(reached => true);
        }

        /// <summary>
        /// Checks if any of the maps within a given list of rooms have been reached.
        /// </summary>
        /// <param name="ListOfRooms">The list of rooms to check.</param>
        /// <returns>`true` if any rooms have been reached, else `false`.</returns>
        public static bool HasReachedAnyRooms(List<string> ListOfRooms)
        {
            return AnyTrue(CheckReachedRooms(ListOfRooms));
        }

        /// <summary>
        /// Checks for if it is not shop sanity, and if the room can be accessed.
        /// </summary>
        /// <param name="room">Name of the room to check.</param>
        /// <returns>`true` if the shop room can be accessed and not shopsanity, else `false`.</returns>
        public static bool CanShopFromRoom(string room)
        {
            return HasReachedRoom(room) && !Randomizer.SSettings.shuffleShopItems;
        }

        /// <summary>
        /// Checks for if "Kakariko Barnes Bomb Shop Lower" has been reached.
        /// </summary>
        private static bool HasReachedBarnesBombsLower = HasReachedRoom(
            "Kakariko Barnes Bomb Shop Lower"
        );

        /// <summary>
        /// Checks for if "Lake Hylia" has been reached.
        /// </summary>
        private static bool HasReachedLakeHylia = HasReachedRoom("Lake Hylia");

        // subclass CanUnlockMap

        /// <summary>
        /// Cycles through the list of rooms requested to check if all the rooms on that map have been reached.
        /// </summary>
        /// <param name="rooms_on_map" >The list of maps to check.</param>
        /// <returns>`true` if open map or all rooms reached, else `false`.<returns>
        public static bool CanUnlockRegionalMap(List<string> rooms_on_map)
        {
            // If openMap is true, then the map is already open.
            // Otherwise, we need to check if any rooms on the map have been accessed.
            return Randomizer.SSettings.openMap || HasReachedAnyRooms(rooms_on_map);
        }

        /// <summary>
        /// Checks if any maps in the Ordona province have been reached.
        /// </summary>
        /// <returns>`true` if so, else `false`.</returns>
        public static bool CanUnlockOrdonaMap()
        {
            return CanUnlockRegionalMap(RoomFunctions.OrdonaMapRooms);
        }

        /// <summary>
        /// Checks if any maps in the Faron province have been reached.
        /// </summary>
        /// <returns>`true` if so, else `false`.</returns>
        public static bool CanUnlockFaronMap()
        {
            return CanUnlockRegionalMap(RoomFunctions.FaronMapRooms);
        }

        /// <summary>
        /// Checks if any maps in the Eldin province have been reached.
        /// </summary>
        /// <returns>`true` if so, else `false`.</returns>
        public static bool CanUnlockEldinMap()
        {
            return CanUnlockRegionalMap(RoomFunctions.EldinMapRooms);
        }

        /// <summary>
        /// Checks if any maps in the Lanayru province have been reached.
        /// </summary>
        /// <returns>`true` if so, else `false`.</returns>
        public static bool CanUnlockLanayruMap()
        {
            return CanUnlockRegionalMap(RoomFunctions.LanayruMapRooms);
        }

        /// <summary>
        /// Checks if any maps in the Snowpeak province have been reached
        /// if Snowpeak Entrance is not skipped.
        /// </summary>
        /// <returns>`true` if so, else `false`.</returns>
        public static bool CanUnlockSnowpeakMap()
        {
            return Randomizer.SSettings.skipSnowpeakEntrance
                || CanUnlockRegionalMap(RoomFunctions.SnowpeakMapRooms);
        }

        /// <summary>
        /// Checks if any maps in the Gerudo province have been reached.
        /// </summary>
        /// <returns>`true` if so, else `false`.</returns>
        public static bool CanUnlockGerudoMap()
        {
            return CanUnlockRegionalMap(RoomFunctions.GerudoMapRooms);
        }

        // End of CanUnlockMap

        // End of EntranceRandomizerLogic[Functions]

        // class NicheAndDifficult

        private static bool IsGlitchedLogic =
            Randomizer.SSettings.logicRules == LogicRules.Glitched;

        /// <sumamry>
        /// Checks the setting for niche stuff. Niche stuff includes things that may not be obvious to most players, such as damaging enemies with boots, lantern on Gorons, drained Magic Armor for heavy mod, etc.
        /// </summary>
        /// <returns>`true` if the setting is, else `false`.</returns>
        public static bool CanDoNicheStuff()
        {
            // TODO: Change to use setting once it's made
            return IsGlitchedLogic;
        }

        /// <summary>
        /// Checks the setting for difficult combat. Difficult combat includes: difficult, annoying, or time consuming combat
        /// </summary>
        /// <returns>`false` until the setting is made.</returns>
        public static bool CanDoDifficultCombat()
        {
            // TODO: Change to use setting once it's made
            return false;
        }

        /// <summary>
        /// Checks if allowed to do niche things and if backslice has been obtained.
        /// </summary>
        /// <returns>`true` if Niche Combat is enabled and at least 3 hidden skills have been obtained, else `false`.</returns>
        public static bool CanUseBacksliceAsSword()
        {
            return CanDoNicheStuff() && HasBackslice();
        }

        /// <summary>
        /// Checks if Iron Boots can be used in Niche Combat.
        /// </summary>
        private static bool CanFightWithBoots = CanDoNicheStuff() && CanUse(Item.Iron_Boots);

        /// <summary>
        /// Checks for Iron Boots or the ability to use Magic Armor as Iron Boots.
        /// </summary>
        private static bool HasEitherBootsOrMagicArmor =
            CanUse(Item.Iron_Boots) || (CanDoNicheStuff() && CanUse(Item.Magic_Armor));

        /// <summary>
        /// Checks if Backslice can be used as a sword in difficult combat.
        /// </summary>
        private static bool CanUseBacksliceAsSwordInDifficultCombat =
            CanDoDifficultCombat() && CanUseBacksliceAsSword();

        /// <summary>
        /// Checks for Iron Boots or Spinner if Difficult Combat is possible.
        /// </summary>
        private static bool CanUseIBOrSpinnerInDifficultCombat =
            CanDoDifficultCombat() && (CanUse(Item.Iron_Boots) || CanUse(Item.Spinner));

        /// <summary>
        /// Checks for Iron Boots, Spinner, or Bombs if Difficult Combat is possible.
        /// </summary>
        private static bool CanUseIBSpinnerOrBombsInDifficultCombat =
            CanUseIBOrSpinnerInDifficultCombat || (CanDoDifficultCombat() && hasBombs());

        // TODO: If option to not have bug models replaced becomes a thing, this function can be useful
        public static bool CanGetBugWithLantern()
        {
            return false;
        }

        // End of NicheAndDifficult

        /// <summary>
        /// Checks for the ability to survive damage done by bonks in OHKO mode.
        /// </summary>
        public static bool CanSurviveBonkDamage()
        {
            // Check the setting "bonksDoDamage"
            bool BonksDamageEnabled = Randomizer.SSettings.bonksDoDamage;

            // Check if OHKO is enabled.
            bool OneHitKnockOutEnabled = !Randomizer.SSettings.damageMagnification.Equals(
                DamageMagnification.OHKO
            );

            // If bonks do damage, check for the ability to use fairies.
            return !BonksDamageEnabled
                || (BonksDamageEnabled && (OneHitKnockOutEnabled || CanUseBottledFairies()));
        }

        // class NavigationalAccess
        // This is a weird one to name. I'm not sure if this is correct.

        /// <summary>
        /// Checks if the Shadow Crystal has been obtained, or if any of the rooms with time flow have been reached.
        /// </summary>
        /// <returns>`true` if Shadow Crystal has been obtained OR any of the rooms with time flow have been reached, else `false`.</returns>
        public static bool CanChangeTime()
        {
            return CanUse(Item.Shadow_Crystal) || HasReachedAnyRooms(RoomFunctions.timeFlowStages);
        }

        /// <summary>
        /// Checks if the Shadow Crystal has been obtained, and any of the stages that can be warped to have been reached.
        /// </summary>
        /// <returns>`true` if Shadow Crystal has been obtained and any of the warpable stages have been reached, else `false`.</returns>
        public static bool CanWarp()
        {
            return CanUse(Item.Shadow_Crystal) && HasReachedAnyRooms(RoomFunctions.WarpableStages);
        }

        // End of NavigationFunctions

        // class CanDefeat

        /// <summary>
        /// Checks for Clawshot AND (Sword, Ball and Chain, Shadow Crystal, or Iron Boots Combat).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatAeralfos()
        {
            return CanUse(Item.Progressive_Clawshot)
                && (HasSwordOrBallAndChain || CanUse(Item.Shadow_Crystal) || CanFightWithBoots);
        }

        /// <summary>
        /// Checks for any damaging item, or a Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatArmos()
        {
            return HasAnyDamagingItem() || CanUse(Item.Progressive_Clawshot);
        }

        // subclass DekuBaba

        /// <summary>
        /// Checks for any of the damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBabaSerpent()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canKnockDownHangingBaba()
        {
            return CanUse(Item.Progressive_Bow)
                || CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Boomerang)
                || CanUse(Item.Slingshot);
        }

        /// <summary>
        /// Checks for any damaging items AND (the Boomerang or Bow)
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        /// <remarks>Should this use `canKnockDownHangingBaba`?- Lupa</remarks>
        public static bool CanDefeatHangingBabaSerpent()
        {
            return CanDefeatBabaSerpent() && (CanUse(Item.Boomerang) || HasBowAndArrows);
        }

        /// <summary>
        /// Checks for any damaging item.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBigBaba()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging item (excluding Shadow Crystal), the ability to Shield Attack, the Slingshot, or a Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDekuBaba()
        {
            return HasAnyDamagingItem(["Shadow_Crystal"])
                || HasShieldAttack
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for any damaging item (excluding Shadow Crystal), the ability to Shield Attack, the Slingshot, or a Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowDekuBaba()
        {
            return CanDefeatDekuBaba();
        }

        /// <summary>
        /// Checks for bombs.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDekuLike()
        {
            return hasBombs();
        }

        // End of DekuBaba

        // subclass Gohmas

        /// <summary>
        /// Checks for any damaging item (excluding Shadow Crystal), the Slingshot, or a Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBabyGohma()
        {
            return HasAnyDamagingItem(["Shadow_Crystal"])
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for any damaging item (excluding the ability to fight with Backslice).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatYoungGohma()
        {
            return HasAnyDamagingItem(["Backslice"]);
        }

        // End of Gohmas

        /// <summary>
        /// Checks for Water Bombs or Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBari()
        {
            return CanUseWaterBombs() || CanUse(Item.Progressive_Clawshot);
        }

        // subclass Bokoblins

        /// <summary>
        /// Checks for a damaging item or Slingshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBokoblin()
        {
            return HasAnyDamagingItem() || CanUse(Item.Slingshot);
        }

        /// <summary>
        /// Checks for Sword, Ball and Chain, Large Quiver and Arrows, Shadow Crystal, Bombs,
        /// the ability to fight with Backslice, or the ability to do difficult combat AND (the Iron Boots or Spinner).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBokoblinRed()
        {
            return HasSwordOrBallAndChain
                || ((getItemCount(Item.Progressive_Bow) >= 3) && CanGetArrows())
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
                || CanUseIBOrSpinnerInDifficultCombat;
        }

        // End of Bokoblins

        // subclass BombEnemies

        /// <summary>
        /// Checks for (Iron Boots or the ability to use Magic Armor as Iron Boots) AND (Sword, Clawshot, or Shield Attack).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBombfish()
        {
            return (CanUse(Item.Iron_Boots) || (IsGlitchedLogic && CanUse(Item.Magic_Armor)))
                && (HasSword() || CanUse(Item.Progressive_Clawshot) || HasShieldAttack);
        }

        /// <summary>
        /// Checks for any damaging item (excluding backslice and bombs) or Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBombling()
        {
            return HasAnyDamagingItem(["Backslice", "Bombs"]) || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for any damaging item.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBomskit()
        {
            return HasAnyDamagingItem();
        }

        // End of BombEnemies

        // subclass Bubbles

        /// <summary>
        /// Checks for any damaging item (excluding bombs).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBubble()
        {
            return HasAnyDamagingItem(["Bombs"]);
        }

        /// <summary>
        /// Checks for any damaging item (excluding bombs).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatFireBubble()
        {
            return CanDefeatBubble();
        }

        /// <summary>
        /// Checks for any damaging item (excluding bombs).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatIceBubble()
        {
            return CanDefeatBubble();
        }

        // End of Bubbles

        // subclass Bulblins

        /// <summary>
        /// Checks for any damaging item.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBulblin()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging item.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowBulblin()
        {
            return CanDefeatBulblin();
        }

        // End of Bulblins

        /// <summary>
        /// Checks for any damaging item (excluding Bow).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatChilfos()
        {
            return HasAnyDamagingItem(["Bow"]);
        }

        /// <summary>
        /// Checks for a damaging item or Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatChu()
        {
            return HasAnyDamagingItem() || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for any damaging item (excluding bombs) AND (bombs or Clawshot).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatChuWorm()
        {
            return HasAnyDamagingItem(["Bombs"])
                && (hasBombs() || CanUse(Item.Progressive_Clawshot));
        }

        /// <summary>
        /// Checks for Sword OR (The ability to do difficult combat AND (bombs or ball and chain)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDarknut()
        {
            return HasSword() || (CanDoDifficultCombat() && canSmash());
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDodongo()
        {
            return HasAnyDamagingItem();
        }

        // subclass LizalfosEnemies

        /// <summary>
        /// Check for Sword, Ball and Chain, or Shadow Crystal.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDinalfos()
        {
            return HasSwordOrBallAndChain || CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Check for any damaging item (excluding spinner).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatLizalfos()
        {
            return HasAnyDamagingItem(["Spinner"]);
        }

        // End of LizalfosEnemies

        // subclass Keese

        /// <summary>
        /// Checks for any damaging item (excluding bombs), slingshot, or clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatKeese()
        {
            return HasAnyDamagingItem(["Bombs"])
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for any damaging item (excluding bombs), slingshot, or clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatFireKeese()
        {
            return CanDefeatKeese();
        }

        /// <summary>
        /// Checks for any damaging item (excluding bombs), slingshot, or clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatIceKeese()
        {
            return CanDefeatKeese();
        }

        /// <summary>
        /// Checks for any damaging item (excluding bombs), slingshot, or clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowKeese()
        {
            return CanDefeatKeese();
        }

        // End of Keese

        // subclass Toadpoli

        /// <summary>
        /// Checks for sword, ball and chain, bow, shield attack, or (the ability to do difficult combat and the shadow crystal).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        /// <remarks>Not an actual enemy but used to make changing logic easier.</remarks>
        public static bool CanDefeatToadpoli()
        {
            return HasSwordOrBallAndChain
                || HasBowAndArrows
                || HasShieldAttack
                || (CanDoDifficultCombat() && CanUse(Item.Shadow_Crystal));
        }

        /// <summary>
        /// Checks for sword, ball and chain, bow, shield attack, or (the ability to do difficult combat and the shadow crystal).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatFireToadpoli()
        {
            return CanDefeatToadpoli();
        }

        /// <summary>
        /// Checks for sword, ball and chain, bow, shield attack, or (the ability to do difficult combat and the shadow crystal).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatWaterToadpoli()
        {
            return CanDefeatToadpoli();
        }

        // End of Toadpoli

        /// <summary>
        /// Checks for Ball and Chain.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatFreezard()
        {
            return CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// Checks for one of any damaging item (excluding Shadow Crystal), the ability to Shield attack, the Slingshot,
        /// the ability to use Lantern in Difficult Combat, or a Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatGoron()
        {
            return HasAnyDamagingItem(["Shadow_Crystal"])
                || HasShieldAttack
                || CanUse(Item.Slingshot)
                || (CanDoDifficultCombat() && CanUse(Item.Lantern))
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for Shadow Crystal.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatGhoulRat()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Checks for any damaging items (excluding Backslice, Bombs, and Spinner), (the ability to do difficult combat and the spinner),
        /// or the slingshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatGuay()
        {
            return HasAnyDamagingItem(["Backslice", "Bombs", "Spinner"])
                || (CanDoDifficultCombat() && CanUse(Item.Spinner))
                || CanUse(Item.Slingshot);
        }

        // subclass Helmasaur

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatHelmasaur()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatHelmasaurus()
        {
            return CanDefeatHelmasaur();
        }

        // End of Helmasaur

        /// <summary>
        /// Checks for Shadow Crystal.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatPoe()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        // subclass Kargarok

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatKargarok()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowKargarok()
        {
            return CanDefeatKargarok();
        }

        // End of Kargarok

        /// <summary>
        /// Checks for damaging items (excluding Backslice).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatLeever()
        {
            return HasAnyDamagingItem(["Backslice"]);
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatMiniFreezard()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging items (excluding Backslice).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatMoldorm()
        {
            return HasAnyDamagingItem(["Backslice"]);
        }

        /// <summary>
        /// Checks for any damaging item (excluding Backslice, bombs, or boots) or lantern.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatPoisonMite()
        {
            return HasAnyDamagingItem(["Backslice", "Bombs", "Boots"]) || CanUse(Item.Lantern);
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatPuppet()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging item or the slingshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatRat()
        {
            return HasAnyDamagingItem() || CanUse(Item.Slingshot);
        }

        /// <summary>
        /// Checks for any damaging item (excluding spinner).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatRedeadKnight()
        {
            return HasAnyDamagingItem(["Spinner"]);
        }

        /// <summary>
        /// Checks for a sword or the ability to midna charge.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowBeast()
        {
            return HasSword() || (CanUse(Item.Shadow_Crystal) && CanMidnaCharge());
        }

        /// <summary>
        /// Checks for Shadow Crystal.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowInsect()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShadowVermin()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for water bombs, or (Sword and (Boots or (Niche and Magic Armor))).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatShellBlade()
        {
            return CanUseWaterBombs() || (HasSword() && HasEitherBootsOrMagicArmor);
        }

        /// <summary>
        /// Checks for any damaging items (excluding backslice and bombs).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatSkullfish()
        {
            return HasAnyDamagingItem(["Backslice", "Bombs"]);
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatSkulltula()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for Ball and Chain or Bombs.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatStalfos()
        {
            return canSmash();
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatStalhound()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatStalchild()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatTektite()
        {
            return HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for Boomerang and any damaging items.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatTileWorm()
        {
            return CanUse(Item.Boomerang) && HasAnyDamagingItem();
        }

        /// <summary>
        /// Checks for any damaging items (excluding Backslice, Bombs, and Boots).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatToado()
        {
            return HasAnyDamagingItem(["Backslice", "Bombs", "Boots"]);
        }

        /// <summary>
        /// Checks for any damaging items (excluding Backslice, Boots, and Spinner).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatTorchSlug()
        {
            return HasAnyDamagingItem(["Backslice", "Boots", "Spinner"]);
        }

        /// <summary>
        /// Checks for Ball and Chain, Slingshot, Bow, Boomerang, or Clawshot.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatWalltula()
        {
            return CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Slingshot)
                || HasBowAndArrows
                || CanUse(Item.Boomerang)
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// Checks for any damaging items (excluding Backslice).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatWhiteWolfos()
        {
            return HasAnyDamagingItem(["Backslice"]);
        }

        /// <summary>
        /// Checks for Shadow Crystal, Sword, or the ability to use Backslice as a Sword.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatZantHead()
        {
            return CanUse(Item.Shadow_Crystal) || HasSword() || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// Checks for any damaging items (excluding spinner).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatOok()
        {
            return HasAnyDamagingItem(["Spinner"]);
        }

        /// <summary>
        /// Checks for Iron Boots and (Sword, Shadow Crystal,
        /// (Can use Ball and Chain in Niche), or (has Bow and Bombs)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDangoro()
        {
            return CanUse(Item.Iron_Boots)
                && (
                    HasSword()
                    || CanUse(Item.Shadow_Crystal)
                    || (CanDoNicheStuff() && CanUse(Item.Ball_and_Chain))
                    || (CanUse(Item.Progressive_Bow) && hasBombs())
                );
        }

        /// <summary>
        /// Checks for Shadow Crystal.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatCarrierKargarok()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Checks for Shadow Crystal.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatTwilitBloat()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Checks for any damaging items (excluding Spinner).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDekuToad()
        {
            return HasAnyDamagingItem(["Spinner"]);
        }

        /// <summary>
        /// Checks for a Bow.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatSkullKid()
        {
            return CanUse(Item.Progressive_Bow);
        }

        // subclass KingBulblin

        /// <summary>
        /// Checks for a Bow.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatKingBulblinBridge()
        {
            return CanUse(Item.Progressive_Bow);
        }

        /// <summary>
        /// Checks for Sword, Ball and Chain, Shadow Crystal, Large Quiver, the ability to use Backslice as a sword,
        /// or (The ability to do difficult combat AND (Spinner, Iron Boots, Bombs, or at least Medium Quiver)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatKingBulblinDesert()
        {
            return HasSwordOrBallAndChain
                || CanUse(Item.Shadow_Crystal)
                || (getItemCount(Item.Progressive_Bow) > 2)
                || CanUseBacksliceAsSword()
                || CanUseIBSpinnerOrBombsInDifficultCombat
                || (CanDoDifficultCombat() && (getItemCount(Item.Progressive_Bow) >= 2));
        }

        /// <summary>
        /// Checks for Sword, Ball and Chain, Shadow Crystal, Medium Quiver, or
        /// (The ability to difficult combat and (Spinner, Iron Boots, Bombs, or the ability to use Backslice as a sword)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatKingBulblinCastle()
        {
            return HasSwordOrBallAndChain
                || CanUse(Item.Shadow_Crystal)
                || (getItemCount(Item.Progressive_Bow) > 2)
                || CanUseBacksliceAsSwordInDifficultCombat
                || CanUseIBSpinnerOrBombsInDifficultCombat;
        }

        // End of KingBulblin

        /// <summary>
        /// Checks for Sword, (Boomerang, Bow, or Clawshot), and Shadow Crystal
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDeathSword()
        {
            return HasSword()
                && (CanUse(Item.Boomerang) || HasBowAndArrows || CanUse(Item.Progressive_Clawshot))
                && CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Checks for damaging items (excluding Backslice and Spinner) or
        /// (the ability to do difficult combat and use backslice  as a sword).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDarkhammer()
        {
            return HasAnyDamagingItem(["Backslice", "Spinner"])
                || CanUseBacksliceAsSwordInDifficultCombat;
        }

        /// <summary>
        /// Checks for Shadow Crystal or Sword.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatPhantomZant()
        {
            return CanUse(Item.Shadow_Crystal) || HasSword();
        }

        /// <summary>
        /// Check for the ability to use ranged bombs, or (Boomerang and (Sword, Ball and Chain, Iron Boots,
        /// Shadow Crystal, or (The ability to do difficult combat and use backslice as a sword))).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatDiababa()
        {
            return canLaunchBombs()
                || (
                    CanUse(Item.Boomerang)
                    && (
                        HasSwordOrBallAndChain
                        || CanFightWithBoots
                        || CanUse(Item.Shadow_Crystal)
                        || CanUseBacksliceAsSwordInDifficultCombat
                    )
                );
        }

        /// <summary>
        /// Checks for Bow, Iron Boots, and (a Sword or (the ability to use backslice as a sword in difficult combat)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatFyrus()
        {
            return CanUse(Item.Progressive_Bow)
                && CanUse(Item.Iron_Boots)
                && (HasSword() || CanUseBacksliceAsSwordInDifficultCombat);
        }

        /// <summary>
        /// Checks for (Zora Armor, Iron Boots, Sword, and Clawshot).
        /// Alternatively if Glitched Logic, checks for (Clawshot, the ability to refill your air, and Sword).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatMorpheel()
        {
            // Glitchless Morpheel
            return (
                    CanUse(Item.Zora_Armor)
                    && CanUse(Item.Iron_Boots)
                    && HasSword()
                    && CanUse(Item.Progressive_Clawshot)
                )
                // Glitched Morpheel
                || (
                    CanDoNicheStuff()
                    && CanUse(Item.Progressive_Clawshot)
                    && CanDoAirRefill()
                    && HasSword()
                );
        }

        /// <summary>
        /// Checks for Spinner and (Sword or the ability to do difficult combat).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatStallord()
        {
            return CanUse(Item.Spinner) && (HasSword() || CanDoDifficultCombat());
        }

        /// <summary>
        /// Checks for the Ball and Chain.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatBlizzeta()
        {
            return CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// Checks for Bow and Dominion Rod.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatArmogohma()
        {
            return CanUse(Item.Progressive_Bow) && CanUse(Item.Progressive_Dominion_Rod);
        }

        /// <summary>
        /// Checks for Double Clawshot, at least Ordon Sword, and Iron Boots (or the ability to use Magic Armor as boots).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatArgorok()
        {
            return (getItemCount(Item.Progressive_Clawshot) >= 2)
                && (getItemCount(Item.Progressive_Sword) >= 2)
                && HasEitherBootsOrMagicArmor;
        }

        /// <summary>
        /// Checks for at least Master Sword, Boomerang, Clawshot, Ball and Chain,
        /// Iron Boots (or the ability to use Magic Armor as Boots),
        /// and (Zora Armor or the ability to refill air in glitched logic.)
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDefeatZant()
        {
            return (getItemCount(Item.Progressive_Sword) >= 3)
                && CanUse(Item.Boomerang)
                && CanUse(Item.Progressive_Clawshot)
                && CanUse(Item.Ball_and_Chain)
                && HasEitherBootsOrMagicArmor
                && (CanUse(Item.Zora_Armor) || (IsGlitchedLogic && CanDoAirRefill()));
        }

        /// <summary>
        /// Checks for Shadow Crystal, at least the Master Sword, and Ending Blow.
        /// </summary>
        /// <returns></returns>
        public static bool CanDefeatGanondorf()
        {
            return CanUse(Item.Shadow_Crystal)
                && (getItemCount(Item.Progressive_Sword) >= 3)
                && CanUse(Item.Progressive_Hidden_Skill);
        }

        // End of CanDefeat

        // class CanComplete

        /// <summary>
        /// Checks if the setting to be cleared. If not:
        /// Need to have reached North Faron Woods and be able to defeat Bokoblins.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool canCompletePrologue()
        {
            return Randomizer.SSettings.skipPrologue
                || (HasReachedRoom("North Faron Woods") && CanDefeatBokoblin());
        }

        /// <summary>
        /// Checks if Ordon Ranch has been reached or if Prologue can be completed.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteGoats1()
        {
            return HasReachedRoom("Ordon Ranch") || canCompletePrologue();
        }

        /// <summary>
        /// Checks if Prologue and Faron Twilight can be completed, as well as checking if
        /// (Forest Temple can be completed or the setting for Open Forest is true.)
        /// </summary>
        /// <returns></returns>
        public static bool canClearForest()
        {
            return canCompletePrologue()
                && CanCompleteFaronTwilight()
                && (
                    canCompleteForestTemple()
                    || (Randomizer.SSettings.faronWoodsLogic == FaronWoodsLogic.Open)
                );
        }

        // subclass Twilights

        /// <summary>
        /// Checks for the setting to be cleared. If not:
        // Need to complete Prologue, have reached all rooms, and survive bonk damage.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteFaronTwilight()
        {
            // The list of rooms required to clear Faron Twilight
            List<string> FaronTwilightRooms =
            [
                "South Faron Woods",
                "Faron Woods Coros House Lower",
                "Mist Area Near Faron Woods Cave",
                "North Faron Woods",
                "Ordon Spring",
            ];

            // If Faron Twilight is not cleared:
            // Need to complete Prologue, have reached all rooms, and survive bonk damage.
            return Randomizer.SSettings.faronTwilightCleared
                || (
                    canCompletePrologue()
                    && HasReachedAllRooms(FaronTwilightRooms)
                    && CanSurviveBonkDamage()
                );
        }

        /// <summary>
        /// Checks for the setting to be cleared. If not:
        // Need to reach all the rooms and be able to survive bonk damage.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteEldinTwilight()
        {
            // The list of rooms required to clear Eldin Twilight
            List<string> EldinTwilightRooms =
            [
                "Faron Field",
                "Lower Kakariko Village",
                "Kakariko Graveyard",
                "Kakariko Malo Mart",
                "Kakariko Barnes Bomb Shop Upper",
                "Kakariko Renados Sanctuary Basement",
                "Kakariko Elde Inn",
                "Kakariko Bug House",
                "Upper Kakariko Village",
                "Kakariko Watchtower",
                "Death Mountain Volcano",
            ];

            // If Eldin Twilight is not cleared:
            // Need to reach all the rooms and be able to survive bonk damage.
            return Randomizer.SSettings.eldinTwilightCleared
                || (HasReachedAllRooms(EldinTwilightRooms) && CanSurviveBonkDamage());
        }

        /// <summary>
        /// Checks for the setting to be cleared. If not:
        // Need to be able to access North Eldin field or have the Shadow Crystal,
        // and need to reach all the rooms and be able to survive bonk damage.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteLanayruTwilight()
        {
            // The list of rooms required to clear Lanayru Twilight
            List<string> LanayruTwilightRooms =
            [
                "Zoras Domain",
                "Zoras Domain Throne Room",
                "Upper Zoras River",
                "Lake Hylia",
                "Lake Hylia Lanayru Spring",
                "Castle Town South",
            ];

            // If Lanayru Twilight is not cleared:
            // Need to be able to access North Eldin field or have the Shadow Crystal,
            // and need to reach all the rooms and be able to survive bonk damage.
            return Randomizer.SSettings.lanayruTwilightCleared
                || (
                    (HasReachedRoom("North Eldin Field") || CanUse(Item.Shadow_Crystal))
                    && HasReachedAllRooms(LanayruTwilightRooms)
                    && CanSurviveBonkDamage()
                );
        }

        /// <summary>
        /// Checks if Faron, Eldin, and Lanayru Twilights can be cleared.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteAllTwilight()
        {
            return CanCompleteFaronTwilight()
                && CanCompleteEldinTwilight()
                && CanCompleteLanayruTwilight();
        }

        // End of Twilights

        // subclass Dungeons

        /// <summary>
        /// Checks to see if Diababa has been defeated.
        /// </summary>
        /// <returns>`true` if Diababa has been defeated, else `false`.<returns>
        public static bool canCompleteForestTemple()
        {
            return CanUse(Item.Diababa_Defeated);
        }

        /// <summary>
        /// Checks to see if Fyrus has been defeated.
        /// </summary>
        /// <returns>`true` if Fyrus has been defeated, else `false`.<returns>
        public static bool canCompleteGoronMines()
        {
            return CanUse(Item.Fyrus_Defeated);
        }

        /// <summary>
        /// Checks to see if Morpheel has been defeated.
        /// </summary>
        /// <returns>`true` if Morpheel has been defeated, else `false`.<returns>
        public static bool canCompleteLakebedTemple()
        {
            return CanUse(Item.Morpheel_Defeated);
        }

        /// <summary>
        /// Checks to see if Stallord has been defeated.
        /// </summary>
        /// <returns>`true` if Stallord has been defeated, else `false`.<returns>
        public static bool canCompleteArbitersGrounds()
        {
            return CanUse(Item.Stallord_Defeated);
        }

        /// <summary>
        /// Checks to see if Blizzeta has been defeated.
        /// </summary>
        /// <returns>`true` if Blizzeta has been defeated, else `false`.<returns>
        public static bool canCompleteSnowpeakRuins()
        {
            return CanUse(Item.Blizzeta_Defeated);
        }

        /// <summary>
        /// Checks to see if Armogohma has been defeated.
        /// </summary>
        /// <returns>`true` if Armogohma has been defeated, else `false`.<returns>
        public static bool canCompleteTempleofTime()
        {
            return CanUse(Item.Armogohma_Defeated);
        }

        /// <summary>
        /// Checks to see if Argorok has been defeated.
        /// </summary>
        /// <returns>`true` if Argorok has been defeated, else `false`.<returns>
        public static bool canCompleteCityinTheSky()
        {
            return CanUse(Item.Argorok_Defeated);
        }

        /// <summary>
        /// Checks to see if Zant has been defeated.
        /// </summary>
        /// <returns>`true` if Zant has been defeated, else `false`.<returns>
        public static bool canCompletePalaceofTwilight()
        {
            return CanUse(Item.Zant_Defeated);
        }

        /// <summary>
        /// Checks if all of the dungeons can be completed.
        /// </summary>
        /// <returns>`true` if they can, else `false`.</returns>
        public static bool canCompleteAllDungeons()
        {
            return canCompleteForestTemple()
                && canCompleteGoronMines()
                && canCompleteLakebedTemple()
                && canCompleteArbitersGrounds()
                && canCompleteSnowpeakRuins()
                && canCompleteTempleofTime()
                && canCompleteCityinTheSky()
                && canCompletePalaceofTwilight();
        }

        // End of Dungeons

        /// <summary>
        /// Checks to see if the setting to skip Midna's Desperate Hour is enabled, or if
        /// (Lakebed Temple is completed and Castle Town South has been reached.)
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteMDH()
        {
            return (Randomizer.SSettings.skipMdh == true)
                || (canCompleteLakebedTemple() && HasReachedRoom("Castle Town South"));
        }

        // End of CanComplete

        // subclass Glitches

        // subclass BootsWrappers

        /// <summary>
        /// Checks for Iron Boots and at least 3 items on the item wheel.
        /// Having 3 items ensures you can equip something over the boots.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool HaveBootsAndCanEquipOver()
        {
            return CanUse(Item.Iron_Boots) && (GetItemWheelSlotCount() >= 3);
        }

        /// <summary>
        /// Checks for Magic Armor or (Iron Boots with the ability to equip over them).
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanEquipOverBootsOrHaveMagicArmor()
        {
            return CanUse(Item.Magic_Armor) || HaveBootsAndCanEquipOver();
        }

        /// <summary>
        /// Checks for Iron Boots or Magic Armor.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool HasHeavyMod()
        {
            return CanUse(Item.Iron_Boots) || CanUse(Item.Magic_Armor);
        }

        // End of BootsWrappers

        // subclass MoonBootsVariants

        /// <summary>
        /// Checks for Sword AND (Magic Armor or
        // (Iron Boots with the ability to equip over them)).
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanDoMoonBoots()
        {
            return HasSword() && CanEquipOverBootsOrHaveMagicArmor();
        }

        /// <summary>
        /// Checks for if you can do Ending Blow, have 2 swords, and can do Moon Boots.
        /// </summary>
        /// <returns></returns>
        public static bool CanDoEBMoonBoots()
        {
            return CanDoMoonBoots()
                && getItemCount(Item.Progressive_Hidden_Skill) >= 1
                && getItemCount(Item.Progressive_Sword) >= 2;
        }

        /// <summary>
        /// Check for if you can do Back Slice and have Magic Armor.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanDoBSMoonBoots()
        {
            return HasBackslice() && CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Checks if you can do Moon Boots, Have Helm Splitter, a sword, and shield.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanDoHSMoonBoots()
        {
            return CanDoMoonBoots()
                && getItemCount(Item.Progressive_Hidden_Skill) >= 4
                && HasSword()
                && hasShield();
        }

        /// <summary>
        /// Checks for the ability to do Moon Boots and if at least Jump Strike has been obtained.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanDoJSMoonBoots()
        {
            return CanDoMoonBoots() && HasJumpStrike();
        }

        // End of MoonBootsVariants

        // subclass LJA
        // TODO: name better

        /// <summary>
        /// Checks for Sword and Boomerang to do LJAs.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanDoLJA()
        {
            return HasSword() && CanUse(Item.Boomerang);
        }

        /// <summary>
        /// Checks for Sword, Rang, and at least 6 hidden skills.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        public static bool CanDoJSLJA()
        {
            return CanDoLJA() && HasJumpStrike();
        }

        // End of LJA

        // subclass MapGlitchStuff

        /// <summary>
        /// Checks for Shadow Crystal and if Kakariko Gorge has been reached.
        /// </summary>
        /// <returns></returns>
        public static bool CanDoMapGlitch()
        {
            return CanUse(Item.Shadow_Crystal) && HasReachedRoom("Kakariko Gorge");
        }

        /// <summary>
        /// Checks for a one handed item and the ability to do map glitch.
        /// <para>This glitch is also known as Reverse Door Adventure.</para>
        /// </summary>
        /// <returns></returns>
        public static bool CanDoStorage()
        {
            return CanDoMapGlitch() && HasOneHandedItem();
        }

        // End of MapGlitchStuff

        /// <summary>
        /// Checks for an item with a cutscene, which is useful for
        /// cutscene dropping a bomb in a specific spot.
        /// </summary>
        /// <returns>`true` if the above is true, else `false`.</returns>
        /// <remarks>Should this not also include Memo or Sketch? - Lupa</remarks>
        public static bool HasCutsceneItem()
        {
            return CanUse(Item.Progressive_Sky_Book) || HasBottle() || CanUse(Item.Horse_Call);
        }

        /// <summary>
        /// Checks for a sword, a bottle, Boomerang, Clawshot, Lantern,
        /// Bow, Slingshot, or Dominion Rod.
        /// </summary>
        /// <returns></returns>
        public static bool HasOneHandedItem()
        {
            return HasSword()
                || HasBottle()
                || CanUse(Item.Boomerang)
                || CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Lantern)
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Dominion_Rod);
        }

        /// <summary>
        /// Checks for a sword or at least 3 hidden skills.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool HasSwordOrBS()
        {
            return CanUse(Item.Progressive_Sword) || HasBackslice();
        }

        /// <summary>
        /// Check for if you can swim with Water Bombs.
        /// Requires Water Bombs and (Magic Armor or (Iron Boots and at least 3 items on the Item Wheel)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDoAirRefill()
        {
            return CanUseWaterBombs() && CanEquipOverBootsOrHaveMagicArmor();
        }

        /// <summary>
        /// Checks for if you have a fishing rod and some way to be heavy.
        /// <para>Check for if you can do The Amazing Fly Glitch™</para>
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDoFlyGlitch()
        {
            return CanUse(Item.Progressive_Fishing_Rod) && HasHeavyMod();
        }

        // End of Glitches

        // class GlitchedLogic

        /// <summary>
        /// Checks for the ability to complete prologue, and either Faron set to Open or
        /// (the ability to complete forest temple, the ability to LJA, or the ability to do map glitch).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool canClearForestGlitched()
        {
            return canCompletePrologue()
                && (
                    (Randomizer.SSettings.faronWoodsLogic == FaronWoodsLogic.Open)
                    || canCompleteForestTemple()
                    || CanDoLJA()
                    || CanDoMapGlitch()
                );
        }

        /// <summary>
        /// Checks for bombs, the ability to do backslice moon boots,
        /// or the ability to do jumpstrike moonboots.
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDoFTWindlessBridgeRoom()
        {
            return hasBombs() || CanDoBSMoonBoots() || CanDoJSMoonBoots();
        }

        /// <summary>
        /// If Eldin Twilight is not already cleared, check if Forest can be completed (glitched).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanCompleteEldinTwilightGlitched()
        {
            return Randomizer.SSettings.eldinTwilightCleared || canClearForestGlitched();
        }

        /// <summary>
        /// If not keysy, checks for backslice, the ability to do backslice moonboots,
        /// the ability to do jumpstrike moonboots, the ability to do LJAs, or
        /// (bombs and (some way to be heavy and jump strike)).
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanSkipKeyToDekuToad()
        {
            return Randomizer.SSettings.smallKeySettings == SmallKeySettings.Keysy
                || HasBackslice()
                || CanDoBSMoonBoots()
                || CanDoJSMoonBoots()
                || CanDoLJA()
                || (hasBombs() && (HasHeavyMod() || HasJumpStrike()));
        }

        /// <summary>
        /// Checks for 3 expressions:
        /// <para>- Have a bow.</para>
        /// <para>- Have the Ball and Chain.</para>
        /// <para>- Have slingshot and (Shadow Crystal, Sword, Bombs, Boots, or Spinner).</para>
        /// </summary>
        /// <returns>`true` if the above is satisfied, else `false`.</returns>
        public static bool CanDoHiddenVillageGlitched()
        {
            return CanUse(Item.Progressive_Bow)
                || CanUse(Item.Ball_and_Chain)
                || (
                    CanUse(Item.Slingshot)
                    && (
                        CanUse(Item.Shadow_Crystal)
                        || HasSword()
                        || hasBombs()
                        || CanUse(Item.Iron_Boots)
                        || CanUse(Item.Spinner)
                    )
                );
        }

        // End of GlitchedLogic
    }
}
