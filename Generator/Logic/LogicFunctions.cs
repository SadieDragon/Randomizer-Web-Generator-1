using System.Collections.Generic;
using System.Reflection;
using TPRandomizer.SSettings.Enums;
using System;

namespace TPRandomizer
{
    /// <summary>
    /// summary text.
    /// </summary>
    public class LogicFunctions
    {
        //Evaluate the tokenized settings to their respective values that are set by the settings string.

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool EvaluateSetting(string setting, string value)
        {
            PropertyInfo[] settingProperties = Randomizer.SSettings.GetType().GetProperties();
            setting = setting.Replace("Setting.", "");
            bool isEqual = false;
            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(Randomizer.SSettings, null);
                if ((property.Name == setting) && (value == settingValue.ToString()))
                {
                    isEqual = true;
                }
            }
            return isEqual;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUse(Item item)
        {
            bool canUseItem = false;
            if (Randomizer.Items.heldItems.Contains(item))
            {
                canUseItem = true;
            }
            return canUseItem;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUse(string item)
        {
            bool canUseItem = false;
            foreach (var listItem in Randomizer.Items.heldItems)
            {
                if (listItem.ToString() == item)
                {
                    canUseItem = true;
                    break;
                }
            }
            return canUseItem;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanChangeTime()
        {
            if (CanUse(Item.Shadow_Crystal))
            {
                // Can change time on any stage with shadow crystal
                return true;
            }
            else
            {
                foreach (string timeStage in RoomFunctions.timeFlowStages)
                {
                    if (Randomizer.Rooms.RoomDict[timeStage].ReachedByPlaythrough)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CanWarp()
        {
            if (CanUse(Item.Shadow_Crystal))
            {
                foreach (string warpStage in RoomFunctions.WarpableStages)
                {
                    if (Randomizer.Rooms.RoomDict[warpStage].ReachedByPlaythrough)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canGetHotSpringWater()
        {
            return (
                    Randomizer.Rooms.RoomDict["Lower Kakariko Village"].ReachedByPlaythrough
                    || (
                        Randomizer.Rooms.RoomDict[
                            "Death Mountain Elevator Lower"
                        ].ReachedByPlaythrough && CanDefeatGoron()
                    )
                ) && HasBottle();
        }

        /// <summary>
        /// Checks for one of a list of damaging items. Allows for one or more of that list to not be excluded from the check.
        /// List of damaging items: Sword, Ball and Chain, Bombs, Boots, Bow, Shadow Crystal, Spinner.
        /// List of expected item names: "Bombs", "Boots", "Bow", "Shadow_Crystal", "Spinner".
        /// </summary>
        /// <param name="exclusions">Optional (defaults to null for no exclusions). Pass a list of item names to not check for them.</param>
        /// <returns></returns>
        /// TODO: If this works, then I should also add backslice to this rather than having it as a sep. helper fn.
        public static bool HasDamagingItem(List<string> exclusions = null)
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || (!exclusions.Contains("Bombs") && hasBombs())
                || (!exclusions.Contains("Boots") && CanFightWithBoots())
                || (!exclusions.Contains("Bow") && HasBowAndArrows())
                || (!exclusions.Contains("Shadow_Crystal") && CanUse(Item.Shadow_Crystal))
                || (!exclusions.Contains("Spinner") && CanUse(Item.Spinner));
        }
        // NOTE: You could probably add variables with the different possible exclusions and exclusion combinations.
        //  This would be a bit less repetitive. I didn't implement it because I don't know how that would affect memory usage,
        //  or if memory usage is a problem to consider.
        // - Lupa (SadieDragon)


        // /// <summary>
        // /// summary text.
        // /// </summary>
        // public static bool HasDamagingItem()
        // {
        //     return HasSword()
        //         || CanUse(Item.Ball_and_Chain)
        //         || HasBowAndArrows()
        //         || hasBombs()
        //         || CanFightWithBoots()
        //         || CanUse(Item.Shadow_Crystal)
        //         || CanUse(Item.Spinner);
        // }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasSword()
        {
            return CanUse(Item.Progressive_Sword);
        }

        /// <summary>
        /// Determines if the bow is obtained and arrows can be refilled.
        /// </summary>
        public static bool HasBowAndArrows()
        {
            return (CanUse(Item.Progressive_Bow) && CanGetArrows());
        }

        //TODO: There's a lot of "Has items" where not all the things are the same.
        //  (BS in some, but not others; Bombs are missing but the rest there; Spinner missing but the rest there; ...)
        //TODO: ShieldBash - has shield + 2 hidden skills
        //TODO: Niche + MA

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatAeralfos()
        {
            return (
                CanUse(Item.Progressive_Clawshot)
                && (
                    HasSword()
                    || CanUse(Item.Ball_and_Chain)
                    || CanUse(Item.Shadow_Crystal)
                    || CanFightWithBoots()
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmos()
        {
            return CanStandardOrBacksliceCombat()
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent()
        {
            return CanStandardOrBacksliceCombat();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return (
                    CanUse(Item.Boomerang)
                    || HasBowAndArrows()
                ) && LogicFunctions.CanDefeatBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma()
        {
            return HasDamagingItem(new List<string>() { "Shadow_Crystal" })
            // return HasSword()
            //     || CanUse(Item.Ball_and_Chain)
            //     || HasBowAndArrows()
            //     || CanFightWithBoots()
            //     || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot)
            //     || hasBombs()
                || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBari()
        {
            return CanUseWaterBombs() || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBeamos()
        {
            return CanUse(Item.Ball_and_Chain)
                || HasBowAndArrows()
                || hasBombs();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu()
        {
            return (
                CanStandardOrBacksliceCombat()
                || CanUse(Item.Progressive_Clawshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin()
        {
            return (
                CanStandardOrBacksliceCombat()
                || CanUse(Item.Slingshot)
            );
        }

        public static bool CanDefeatBokoblinRed()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || ((getItemCount(Item.Progressive_Bow) >= 3) && CanGetArrows())
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
                || (CanDoDifficultCombat() && (CanUse(Item.Iron_Boots) || CanUse(Item.Spinner)))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombfish()
        {
            return (
                (
                    CanUse(Item.Iron_Boots)
                    || Randomizer.SSettings.logicRules == LogicRules.Glitched
                        && CanUse(Item.Magic_Armor)
                )
                && (
                    HasSword()
                    || CanUse(Item.Progressive_Clawshot)
                    || (hasShield() && getItemCount(Item.Progressive_Hidden_Skill) >= 2)
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Progressive_Clawshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBubble()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos()
        {
            return (
                HasDamagingItem(new List<string>() { "Bow" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || CanFightWithBoots()
                // || CanUse(Item.Shadow_Crystal)
                // || CanUse(Item.Spinner)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChuWorm()
        {
            return (
                (
                    HasDamagingItem(new List<string>() { "Bombs" })
                    // HasSword()
                    // || CanUse(Item.Ball_and_Chain)
                    // || HasBowAndArrows()
                    // || CanFightWithBoots()
                    // || CanUse(Item.Spinner)
                    // || CanUse(Item.Shadow_Crystal)
                    || CanUseBacksliceAsSword()
                ) && (hasBombs() || CanUse(Item.Progressive_Clawshot))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarknut()
        {
            return HasSword()
                || (CanDoDifficultCombat() && (hasBombs() || CanUse(Item.Ball_and_Chain)));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuBaba()
        {
            return (
                HasDamagingItem(new List<string>() { "Shadow_Crystal" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || (hasShield() && getItemCount(Item.Progressive_Hidden_Skill) >= 2)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuLike()
        {
            return (hasBombs());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDodongo()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDinalfos()
        {
            return (HasSword() || CanUse(Item.Ball_and_Chain) || CanUse(Item.Shadow_Crystal));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireBubble()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireKeese()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireToadpoli()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || HasBowAndArrows()
                || (CanUse(Item.Hylian_Shield) && getItemCount(Item.Progressive_Hidden_Skill) >= 2)
                || (CanDoDifficultCombat() && CanUse(Item.Shadow_Crystal))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFreezard()
        {
            return CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGoron()
        {
            return (
                HasDamagingItem(new List<string> {"Shadow_Crystal", "Spinner"})
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || (hasShield() && (getItemCount(Item.Progressive_Hidden_Skill) >= 2))
                || CanUse(Item.Slingshot)
                || (CanDoDifficultCombat() && CanUse(Item.Lantern))
                || CanUse(Item.Progressive_Clawshot)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGhoulRat()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGuay()
        {
            return (
                HasDamagingItem(new List<string> {"Bombs", "Spinner"})
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                || (CanDoDifficultCombat() && CanUse(Item.Spinner))
                // || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Slingshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceBubble()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceKeese()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoe()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKargarok()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKeese()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos()
        {
            return (
                HasDamagingItem(new List<string>() { "Spinner" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Shadow_Crystal)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite()
        {
            return (
                HasDamagingItem(new List<string> {"Bombs", "Boots"})
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                || CanUse(Item.Lantern)
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat()
        {
            return (
                CanStandardOrBacksliceCombat()
                || CanUse(Item.Slingshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight()
        {
            return (
                HasDamagingItem(new List<string>() { "Spinner" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Shadow_Crystal)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBeast()
        {
            return HasSword() || (CanUse(Item.Shadow_Crystal) && CanMidnaCharge());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBulblin()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return (
                HasDamagingItem(new List<string>() { "Shadow_Crystal" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || (hasShield() && getItemCount(Item.Progressive_Hidden_Skill) >= 2)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowInsect()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKargarok()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                // || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShellBlade()
        {
            return (
                CanUseWaterBombs()
                || (
                    HasSword()
                    && (CanUse(Item.Iron_Boots) || (CanDoNicheStuff() && CanUse(Item.Magic_Armor)))
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullfish()
        {
            return (
                HasDamagingItem(new List<string>() { "Bombs" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalfos()
        {
            return (canSmash());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalhound()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite()
        {
            return CanStandardOrBacksliceCombat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm()
        {
            return (CanStandardOrBacksliceCombat() && CanUse(Item.Boomerang));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado()
        {
            return (
                HasDamagingItem(new List<string> {"Bombs", "Boots"})
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanUse(Item.Spinner)
                // || CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWaterToadpoli()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || HasBowAndArrows()
                || (hasShield() && getItemCount(Item.Progressive_Hidden_Skill) >= 2)
                || CanDoDifficultCombat() && (CanUse(Item.Shadow_Crystal))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug()
        {
            return (
                HasDamagingItem(new List<string> {"Boots", "Spinner"})
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanUse(Item.Shadow_Crystal)
                // || hasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWalltula()
        {
            return (
                CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Slingshot)
                || HasBowAndArrows()
                || CanUse(Item.Boomerang)
                || CanUse(Item.Progressive_Clawshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZantHead()
        {
            return (CanUse(Item.Shadow_Crystal) || HasSword()) || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatOok()
        {
            return (
                HasDamagingItem(new List<string>() { "Spinner" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Shadow_Crystal)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDangoro()
        {
            return (
                (
                    HasSword()
                    || CanUse(Item.Shadow_Crystal)
                    || (
                        CanDoNicheStuff() && CanUse(Item.Ball_and_Chain)
                        || (CanUse(Item.Progressive_Bow) && hasBombs())
                    )
                ) && CanUse(Item.Iron_Boots)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatCarrierKargarok()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTwilitBloat()
        {
            return CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuToad()
        {
            return (
                HasDamagingItem(new List<string>() { "Spinner" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Shadow_Crystal)
                // || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullKid()
        {
            return CanUse(Item.Progressive_Bow);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinBridge()
        {
            return CanUse(Item.Progressive_Bow);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinDesert()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Shadow_Crystal)
                || getItemCount(Item.Progressive_Bow) > 2
                || CanUseBacksliceAsSword()
                || (
                    CanDoDifficultCombat()
                    && (
                        CanUse(Item.Spinner)
                        || CanUse(Item.Iron_Boots)
                        || hasBombs()
                        || getItemCount(Item.Progressive_Bow) >= 2
                    )
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinCastle()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Shadow_Crystal)
                || getItemCount(Item.Progressive_Bow) > 2
                || (
                    CanDoDifficultCombat()
                    && (
                        CanUse(Item.Spinner)
                        || CanUse(Item.Iron_Boots)
                        || hasBombs()
                        || CanUseBacksliceAsSword()
                    )
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDeathSword()
        {
            return (
                HasSword()
                && (
                    CanUse(Item.Boomerang)
                    || HasBowAndArrows()
                    || CanUse(Item.Progressive_Clawshot)
                )
                && CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarkhammer()
        {
            return (
                HasDamagingItem(new List<string>() { "Spinner" })
                // HasSword()
                // || CanUse(Item.Ball_and_Chain)
                // || HasBowAndArrows()
                // || CanFightWithBoots()
                // || CanUse(Item.Shadow_Crystal)
                // || hasBombs()
                || (CanDoDifficultCombat() && CanUseBacksliceAsSword())
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPhantomZant()
        {
            return (CanUse(Item.Shadow_Crystal) || HasSword());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDiababa()
        {
            return canLaunchBombs()
                || (
                    CanUse(Item.Boomerang)
                    && (
                        HasDamagingItem(new List<string>() { "Spinner" })
                        // HasSword()
                        // || CanUse(Item.Ball_and_Chain)
                        // || CanFightWithBoots()
                        // || CanUse(Item.Shadow_Crystal)
                        // || hasBombs()
                        || (CanDoDifficultCombat() && CanUseBacksliceAsSword())
                    )
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFyrus()
        {
            return (
                CanUse(Item.Progressive_Bow)
                && CanUse(Item.Iron_Boots)
                && (HasSword() || (CanDoDifficultCombat() && CanUseBacksliceAsSword()))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMorpheel()
        {
            return (
                (
                    CanUse(Item.Zora_Armor)
                    && CanUse(Item.Iron_Boots)
                    && HasSword()
                    && CanUse(Item.Progressive_Clawshot)
                )
                || (
                    CanDoNicheStuff()
                    && (
                        CanUse(Item.Progressive_Clawshot)
                        && CanDoAirRefill()
                        && HasSword()
                    )
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStallord()
        {
            return (
                (CanUse(Item.Spinner) && HasSword())
                || (CanDoDifficultCombat() && CanUse(Item.Spinner))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBlizzeta()
        {
            return CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmogohma()
        {
            return (
                CanUse(Item.Progressive_Bow)
                && CanUse(Item.Progressive_Dominion_Rod)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArgorok()
        {
            return (
                getItemCount(Item.Progressive_Clawshot) >= 2
                && getItemCount(Item.Progressive_Sword) >= 2
                && (CanUse(Item.Iron_Boots) || (CanDoNicheStuff() && CanUse(Item.Magic_Armor)))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZant()
        {
            return (
                (getItemCount(Item.Progressive_Sword) >= 3)
                && (
                    CanUse(Item.Boomerang)
                    && CanUse(Item.Progressive_Clawshot)
                    && CanUse(Item.Ball_and_Chain)
                    && (CanUse(Item.Iron_Boots) || (CanDoNicheStuff() && CanUse(Item.Magic_Armor)))
                    && (
                        CanUse(Item.Zora_Armor)
                        || (
                            Randomizer.SSettings.logicRules == LogicRules.Glitched
                            && CanDoAirRefill()
                        )
                    )
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGanondorf()
        {
            return CanUse(Item.Shadow_Crystal)
                && (getItemCount(Item.Progressive_Sword) >= 3)
                && CanUse(Item.Progressive_Hidden_Skill);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canSmash()
        {
            return (CanUse(Item.Ball_and_Chain) || hasBombs());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBurnWebs()
        {
            return CanUse(Item.Lantern) || hasBombs() || CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasRangedItem()
        {
            return (
                CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Slingshot)
                || HasBowAndArrows()
                || CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Boomerang)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasShield()
        {
            return (
                CanUse(Item.Hylian_Shield)
                || (
                    Randomizer.Rooms.RoomDict["Kakariko Malo Mart"].ReachedByPlaythrough
                    && !Randomizer.SSettings.shuffleShopItems
                )
                || (
                    Randomizer.Rooms.RoomDict["Castle Town Goron House"].ReachedByPlaythrough
                    && !Randomizer.SSettings.shuffleShopItems
                )
                || Randomizer.Rooms.RoomDict["Death Mountain Hot Spring"].ReachedByPlaythrough
            );
        }

        public static bool CanUseBottledFairy()
        {
            return HasBottle() && Randomizer.Rooms.RoomDict["Lake Hylia"].ReachedByPlaythrough;
        }

        public static bool CanUseBottledFairies()
        {
            return HasBottles() && Randomizer.Rooms.RoomDict["Lake Hylia"].ReachedByPlaythrough;
        }

        public static bool CanUseOilBottle()
        {
            return CanUse(Item.Lantern) && CanUse(Item.Coro_Bottle);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canLaunchBombs()
        {
            return (
                (
                    CanUse(Item.Boomerang)
                    || HasBowAndArrows()
                ) && hasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCutHangingWeb()
        {
            return (
                CanUse(Item.Progressive_Clawshot)
                || HasBowAndArrows()
                || CanUse(Item.Boomerang)
                || CanUse(Item.Ball_and_Chain)
            );
        }

        public static int GetPlayerHealth()
        {
            double playerHealth = 3.0; // start at 3 since we have 3 hearts.

            playerHealth = playerHealth + (getItemCount(Item.Piece_of_Heart) * 0.2); //Pieces of heart are 1/5 of a heart.
            playerHealth = playerHealth + getItemCount(Item.Heart_Container);

            return (int)playerHealth;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canKnockDownHCPainting()
        {
            return (
                getItemCount(Item.Progressive_Bow) >= 1
                || (
                    CanDoNicheStuff()
                    && (
                        hasBombs()
                        || (HasSword() && getItemCount(Item.Progressive_Hidden_Skill) >= 6)
                    )
                )
                || (
                    Randomizer.SSettings.logicRules == LogicRules.Glitched
                    && ((HasSword() && CanDoMoonBoots()) || CanDoBSMoonBoots())
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBreakMonkeyCage()
        {
            return (
                HasSword()
                || CanUse(Item.Iron_Boots)
                || CanUse(Item.Spinner)
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || HasBowAndArrows()
                || CanUse(Item.Progressive_Clawshot)
                || (
                    CanDoNicheStuff()
                    && hasShield()
                    && getItemCount(Item.Progressive_Hidden_Skill) >= 2
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canPressMinesSwitch()
        {
            return CanUse(Item.Iron_Boots) || (CanDoNicheStuff() && CanUse(Item.Ball_and_Chain));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canFreeAllMonkeys()
        {
            return (
                canBreakMonkeyCage()
                && (
                    CanUse(Item.Lantern)
                    || (
                        (Randomizer.SSettings.smallKeySettings == SmallKeySettings.Keysy)
                        && (hasBombs() || CanUse(Item.Iron_Boots))
                    )
                )
                && canBurnWebs()
                && CanUse(Item.Boomerang)
                && CanDefeatBokoblin()
                && (
                    (getItemCount(Item.Forest_Temple_Small_Key) >= 4)
                    || (Randomizer.SSettings.smallKeySettings == SmallKeySettings.Keysy)
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canKnockDownHangingBaba()
        {
            return (
                CanUse(Item.Progressive_Bow)
                || CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Boomerang)
                || CanUse(Item.Slingshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBreakWoodenDoor()
        {
            return (
                CanUse(Item.Shadow_Crystal) || HasSword() || canSmash() || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasBombs()
        {
            return (
                CanUse(Item.Filled_Bomb_Bag)
                && (
                    Randomizer.Rooms.RoomDict[
                        "Kakariko Barnes Bomb Shop Lower"
                    ].ReachedByPlaythrough
                    || (
                        Randomizer.Rooms.RoomDict[
                            "Eldin Field Water Bomb Fish Grotto"
                        ].ReachedByPlaythrough && CanUse(Item.Progressive_Fishing_Rod)
                    )
                    || Randomizer.Rooms.RoomDict["City in The Sky Entrance"].ReachedByPlaythrough
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUseWaterBombs()
        {
            return (
                CanUse(Item.Filled_Bomb_Bag)
                && (
                    Randomizer.Rooms.RoomDict[
                        "Kakariko Barnes Bomb Shop Lower"
                    ].ReachedByPlaythrough
                    || (
                        Randomizer.Rooms.RoomDict[
                            "Eldin Field Water Bomb Fish Grotto"
                        ].ReachedByPlaythrough && CanUse(Item.Progressive_Fishing_Rod)
                    )
                    || (
                        Randomizer.Rooms.RoomDict[
                            "Kakariko Barnes Bomb Shop Lower"
                        ].ReachedByPlaythrough
                        && Randomizer.Rooms.RoomDict["Castle Town Malo Mart"].ReachedByPlaythrough
                    )
                )
            );
        }

        /// <summary>
        /// This is a temporary function that ensures arrows can be refilled for bow usage in Faron Woods/FT.
        /// </summary>
        public static bool CanGetArrows()
        {
            return (
                Randomizer.Rooms.RoomDict["Lost Woods"].ReachedByPlaythrough
                || (
                    canCompleteGoronMines()
                    && Randomizer.Rooms.RoomDict["Kakariko Malo Mart"].ReachedByPlaythrough
                )
                || (
                    Randomizer.Rooms.RoomDict[
                        "Castle Town Goron House Balcony"
                    ].ReachedByPlaythrough && !Randomizer.SSettings.shuffleShopItems
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompletePrologue()
        {
            return (
                (
                    Randomizer.Rooms.RoomDict["North Faron Woods"].ReachedByPlaythrough
                    && CanDefeatBokoblin()
                ) || (Randomizer.SSettings.skipPrologue == true)
            );
        }

        public static bool CanCompleteGoats1()
        {
            return (
                Randomizer.Rooms.RoomDict["Ordon Ranch"].ReachedByPlaythrough
                || canCompletePrologue()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanCompleteMDH()
        {
            return (
                (Randomizer.SSettings.skipMdh == true)
                || (
                    canCompleteLakebedTemple()
                    && Randomizer.Rooms.RoomDict["Castle Town South"].ReachedByPlaythrough
                )
            );
            //return (canCompleteLakebedTemple() || (Randomizer.SSettings.skipMdh == true));
        }

        public static bool CanMidnaCharge()
        {
            return CanCompleteMDH() && CanCompleteAllTwilight();
        }

        public static bool CanStrikePedestal()
        {
            return getItemCount(Item.Progressive_Sword) >= (int)Randomizer.SSettings.totEntrance;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canClearForest()
        {
            return (
                (
                    canCompleteForestTemple()
                    || (Randomizer.SSettings.faronWoodsLogic == FaronWoodsLogic.Open)
                )
                && canCompletePrologue()
                && CanCompleteFaronTwilight()
            );
        }

        /// <summary>
        /// Can complete Faron twilight
        /// </summary>
        public static bool CanCompleteFaronTwilight()
        {
            return Randomizer.SSettings.faronTwilightCleared
                || (
                    canCompletePrologue()
                    && Randomizer.Rooms.RoomDict["South Faron Woods"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict[
                        "Faron Woods Coros House Lower"
                    ].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict[
                        "Mist Area Near Faron Woods Cave"
                    ].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["North Faron Woods"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Ordon Spring"].ReachedByPlaythrough
                    && (
                        !Randomizer.SSettings.bonksDoDamage
                        || (
                            Randomizer.SSettings.bonksDoDamage
                            && (
                                (
                                    Randomizer.SSettings.damageMagnification
                                    != DamageMagnification.OHKO
                                ) || CanUseBottledFairies()
                            )
                        )
                    )
                );
        }

        /// <summary>
        /// Can complete Eldin twilight
        /// </summary>
        public static bool CanCompleteEldinTwilight()
        {
            return Randomizer.SSettings.eldinTwilightCleared
                || (
                    Randomizer.Rooms.RoomDict["Faron Field"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Lower Kakariko Village"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Kakariko Graveyard"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Kakariko Malo Mart"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict[
                        "Kakariko Barnes Bomb Shop Upper"
                    ].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict[
                        "Kakariko Renados Sanctuary Basement"
                    ].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Kakariko Elde Inn"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Kakariko Bug House"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Upper Kakariko Village"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Kakariko Watchtower"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Death Mountain Volcano"].ReachedByPlaythrough
                    && (
                        !Randomizer.SSettings.bonksDoDamage
                        || (
                            Randomizer.SSettings.bonksDoDamage
                            && (
                                (
                                    Randomizer.SSettings.damageMagnification
                                    != DamageMagnification.OHKO
                                ) || CanUseBottledFairies()
                            )
                        )
                    )
                );
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return Randomizer.SSettings.lanayruTwilightCleared
                || (
                    (
                        Randomizer.Rooms.RoomDict["North Eldin Field"].ReachedByPlaythrough
                        || CanUse(Item.Shadow_Crystal)
                    )
                    && Randomizer.Rooms.RoomDict["Zoras Domain"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Zoras Domain Throne Room"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Upper Zoras River"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Lake Hylia"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Lake Hylia Lanayru Spring"].ReachedByPlaythrough
                    && Randomizer.Rooms.RoomDict["Castle Town South"].ReachedByPlaythrough
                    && (
                        !Randomizer.SSettings.bonksDoDamage
                        || (
                            Randomizer.SSettings.bonksDoDamage
                            && (
                                (
                                    Randomizer.SSettings.damageMagnification
                                    != DamageMagnification.OHKO
                                ) || CanUseBottledFairies()
                            )
                        )
                    )
                );
        }

        public static bool CanCompleteAllTwilight()
        {
            return (
                CanCompleteFaronTwilight()
                && CanCompleteEldinTwilight()
                && CanCompleteLanayruTwilight()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteForestTemple()
        {
            return CanUse(Item.Diababa_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteGoronMines()
        {
            return CanUse(Item.Fyrus_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteLakebedTemple()
        {
            return CanUse(Item.Morpheel_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteArbitersGrounds()
        {
            return CanUse(Item.Stallord_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteSnowpeakRuins()
        {
            return CanUse(Item.Blizzeta_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteTempleofTime()
        {
            return CanUse(Item.Armogohma_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteCityinTheSky()
        {
            return CanUse(Item.Argorok_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompletePalaceofTwilight()
        {
            return CanUse(Item.Zant_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteAllDungeons()
        {
            return (
                canCompleteForestTemple()
                && canCompleteGoronMines()
                && canCompleteLakebedTemple()
                && canCompleteArbitersGrounds()
                && canCompleteSnowpeakRuins()
                && canCompleteTempleofTime()
                && canCompleteCityinTheSky()
                && canCompletePalaceofTwilight()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasBug()
        {
            foreach (Item bug in Randomizer.Items.goldenBugs)
            {
                if (CanUse(bug))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanUnlockOrdonaMap()
        {
            if (Randomizer.SSettings.openMap)
            {
                return true;
            }
            foreach (string mapRoom in RoomFunctions.OrdonaMapRooms)
            {
                if (Randomizer.Rooms.RoomDict[mapRoom].ReachedByPlaythrough)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanUnlockFaronMap()
        {
            if (Randomizer.SSettings.openMap)
            {
                return true;
            }
            foreach (string mapRoom in RoomFunctions.FaronMapRooms)
            {
                if (Randomizer.Rooms.RoomDict[mapRoom].ReachedByPlaythrough)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanUnlockEldinMap()
        {
            if (Randomizer.SSettings.openMap)
            {
                return true;
            }
            foreach (string mapRoom in RoomFunctions.EldinMapRooms)
            {
                if (Randomizer.Rooms.RoomDict[mapRoom].ReachedByPlaythrough)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanUnlockLanayruMap()
        {
            if (Randomizer.SSettings.openMap)
            {
                return true;
            }
            foreach (string mapRoom in RoomFunctions.LanayruMapRooms)
            {
                if (Randomizer.Rooms.RoomDict[mapRoom].ReachedByPlaythrough)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanUnlockSnowpeakMap()
        {
            if (Randomizer.SSettings.openMap || Randomizer.SSettings.skipSnowpeakEntrance)
            {
                return true;
            }
            foreach (string mapRoom in RoomFunctions.SnowpeakMapRooms)
            {
                if (Randomizer.Rooms.RoomDict[mapRoom].ReachedByPlaythrough)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanUnlockGerudoMap()
        {
            if (Randomizer.SSettings.openMap)
            {
                return true;
            }
            foreach (string mapRoom in RoomFunctions.GerudoMapRooms)
            {
                if (Randomizer.Rooms.RoomDict[mapRoom].ReachedByPlaythrough)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks the setting for difficult combat. Difficult combat includes: difficult, annoying, or time consuming combat
        /// </summary>
        public static bool CanDoDifficultCombat()
        {
            // TODO: Change to use setting once it's made
            return false;
        }

        /// <sumamry>
        /// Checks the setting for niche stuff. Niche stuff includes things that may not be obvious to most players, such as damaging enemies with boots, lantern on Gorons, drained Magic Armor for heavy mod, etc.
        /// </summary>
        public static bool CanDoNicheStuff()
        {
            // TODO: Change to use setting once it's made
            return Randomizer.SSettings.logicRules == LogicRules.Glitched;
        }

        /// <summary>
        /// Checks if the iron boots can be used for combat.
        /// </summary>
        public static bool CanFightWithBoots()
        {
            return (CanDoNicheStuff() && CanUse(Item.Iron_Boots));
        }

        public static bool CanUseBacksliceAsSword()
        {
            return CanDoNicheStuff() && getItemCount(Item.Progressive_Hidden_Skill) >= 3;
        }

        /// <summary>
        /// Checks for any damaging items or ability to use backslice.
        /// </summary>
        /// TODO: Name better? Naming this was a struggle. - Lupa
        public static bool CanStandardOrBacksliceCombat()
        {
            return (
                HasDamagingItem()
                || CanUseBacksliceAsSword()
            );
        }

        public static bool CanGetBugWithLantern()
        {
            // TODO: If option to not have bug models replaced becomes a thing, this function can be useful
            return false;
        }

        // START OF GLITCHED LOGIC

        /// <summary>
        /// Check for sword or Back Slice (aka fake sword)
        /// </summary>
        public static bool HasSwordOrBS()
        {
            return getItemCount(Item.Progressive_Sword) >= 1
                || getItemCount(Item.Progressive_Hidden_Skill) >= 3;
        }

        /// <summary>
        /// Check for a usable bottle (requires lantern to avoid issues with lantern oil in all bottles)
        /// </summary>
        public static bool HasBottle()
        {
            return (
                    CanUse(Item.Empty_Bottle)
                    || CanUse(Item.Sera_Bottle)
                    || CanUse(Item.Jovani_Bottle)
                    || CanUse(Item.Coro_Bottle)
                ) && CanUse(Item.Lantern);
        }

        public static bool HasBottles()
        {
            int n = 0;
            if (CanUse(Item.Lantern))
            {
                if (CanUse(Item.Empty_Bottle))
                {
                    n++;
                }
                if (CanUse(Item.Sera_Bottle))
                {
                    n++;
                }
                if (CanUse(Item.Jovani_Bottle))
                {
                    n++;
                }
                if (CanUse(Item.Coro_Bottle))
                {
                    n++;
                }

                if (n > 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check for heavy mod (boots or MA)
        /// </summary>
        public static bool HasHeavyMod()
        {
            return CanUse(Item.Iron_Boots) || CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for cutscene item (useful for cutscene dropping a bomb in specific spot)
        /// </summary>
        public static bool HasCutsceneItem()
        {
            return getItemCount(Item.Progressive_Sky_Book) >= 1
                || HasBottle()
                || CanUse(Item.Horse_Call);
        }

        /// <summary>
        /// Check for if you can do LJAs
        /// </summary>
        public static bool CanDoLJA()
        {
            return HasSword() && CanUse(Item.Boomerang);
        }

        /// <summary>
        /// Check for if you can do Jump Strike LJAs
        /// </summary>
        public static bool CanDoJSLJA()
        {
            return HasSword()
                && CanUse(Item.Boomerang)
                && getItemCount(Item.Progressive_Hidden_Skill) >= 6;
        }

        /// <summary>
        /// Check for if you can do Map Glitch
        /// </summary>
        public static bool CanDoMapGlitch()
        {
            return CanUse(Item.Shadow_Crystal)
                && Randomizer.Rooms.RoomDict["Kakariko Gorge"].ReachedByPlaythrough;
        }

        /// <summary>
        /// Check for if you can do storage (aka Reverse Door Adventure (RDA)). Note: Needs a one-handed item
        /// </summary>
        public static bool CanDoStorage()
        {
            return CanDoMapGlitch() && HasOneHandedItem();
        }

        /// <summary>
        /// Check for if you have any one-handed item
        /// </summary>
        public static bool HasOneHandedItem()
        {
            return HasSword()
                || HasBottle()
                || CanUse(Item.Boomerang)
                || getItemCount(Item.Progressive_Clawshot) >= 1
                || CanUse(Item.Lantern)
                || getItemCount(Item.Progressive_Bow) >= 1
                || CanUse(Item.Slingshot)
                || getItemCount(Item.Progressive_Dominion_Rod) >= 1;
        }

        /// <summary>
        /// Check for if you can do Moon Boots
        /// </summary>
        public static bool CanDoMoonBoots()
        {
            return HasSword()
                && (
                    CanUse(Item.Magic_Armor)
                    || CanUse(Item.Iron_Boots) && GetItemWheelSlotCount() >= 3
                ); // Ensure you can equip something over boots
        }

        /// <summary>
        /// Check for if you can do Jump Strike Moon Boots
        /// </summary>
        public static bool CanDoJSMoonBoots()
        {
            return CanDoMoonBoots() && getItemCount(Item.Progressive_Hidden_Skill) >= 6;
        }

        /// <summary>
        /// Check for if you can do Back Slice Moon Boots
        /// </summary>
        public static bool CanDoBSMoonBoots()
        {
            return getItemCount(Item.Progressive_Hidden_Skill) >= 3 && CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for if you can do Ending Blow Moon Boots
        /// </summary>
        public static bool CanDoEBMoonBoots()
        {
            return CanDoMoonBoots()
                && getItemCount(Item.Progressive_Hidden_Skill) >= 1
                && getItemCount(Item.Progressive_Sword) >= 2;
        }

        /// <summary>
        /// Check for if you can do Helm Splitter Moon Boots
        /// </summary>
        public static bool CanDoHSMoonBoots()
        {
            return CanDoMoonBoots()
                && getItemCount(Item.Progressive_Hidden_Skill) >= 4
                && HasSword()
                && hasShield();
        }

        /// <summary>
        /// Check for if you can do The Amazing Fly Glitch™
        /// </summary>
        public static bool CanDoFlyGlitch()
        {
            return getItemCount(Item.Progressive_Fishing_Rod) >= 1 && HasHeavyMod();
        }

        /// <summary>
        /// Check for if you can swim with Water Bombs
        /// </summary>
        public static bool CanDoAirRefill()
        {
            return CanUseWaterBombs()
                && (
                    CanUse(Item.Magic_Armor)
                    || (CanUse(Item.Iron_Boots) && (GetItemWheelSlotCount() >= 3))
                ); // Ensure you can equip something over boots
        }

        /// <summary>
        /// Check for if you can do Hidden Village (glitched)
        /// </summary>
        public static bool CanDoHiddenVillageGlitched()
        {
            return getItemCount(Item.Progressive_Bow) >= 1
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

        /// <summary>
        /// Check for if you can get passed FT windless bridge room (glitched)
        /// </summary>
        public static bool CanDoFTWindlessBridgeRoom()
        {
            return hasBombs() || CanDoBSMoonBoots() || CanDoJSMoonBoots();
        }

        public static bool canClearForestGlitched()
        {
            return (
                canCompletePrologue()
                && (
                    (Randomizer.SSettings.faronWoodsLogic == FaronWoodsLogic.Open)
                    || (canCompleteForestTemple() || CanDoLJA() || CanDoMapGlitch())
                )
            );
        }

        /// <summary>
        /// Check for if Eldin twilight can be completed (glitched). Check this for if map warp can be obtained
        /// </summary>
        public static bool CanCompleteEldinTwilightGlitched()
        {
            return Randomizer.SSettings.eldinTwilightCleared || canClearForestGlitched();
        }

        /// <summary>
        /// Check for if you need the key for getting to Lakebed Deku Toad
        ///
        public static bool CanSkipKeyToDekuToad()
        {
            return Randomizer.SSettings.smallKeySettings == SmallKeySettings.Keysy
                || getItemCount(Item.Progressive_Hidden_Skill) >= 3
                || CanDoBSMoonBoots()
                || CanDoJSMoonBoots()
                || CanDoLJA()
                || (
                    hasBombs()
                    && (HasHeavyMod() || getItemCount(Item.Progressive_Hidden_Skill) >= 6)
                );
        }

        // END OF GLITCHED LOGIC

        public static int getItemCount(Item itemToBeCounted)
        {
            List<Item> itemList = Randomizer.Items.heldItems;
            int itemQuantity = 0;
            foreach (var item in itemList)
            {
                if (item == itemToBeCounted)
                {
                    itemQuantity++;
                }
            }
            return itemQuantity;
        }

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
        /// summary text.
        /// </summary>
        public static bool verifyItemQuantity(string itemToBeCounted, int quantity)
        {
            List<Item> itemList = Randomizer.Items.heldItems;
            int itemQuantity = 0;
            bool isQuantity = false;

            foreach (var item in itemList)
            {
                if (item.ToString() == itemToBeCounted)
                {
                    itemQuantity++;
                }
            }
            if (itemQuantity >= quantity)
            {
                isQuantity = true;
            }
            return isQuantity;
        }
    }
}
