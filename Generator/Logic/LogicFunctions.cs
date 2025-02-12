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
            return Randomizer.Items.heldItems.Contains(item);
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
                    HasReachedLowerKakariko
                    || (
                        HasReachedRoom("Death Mountain Elevator Lower")
                        && CanDefeatGoron()
                    )
                ) && HasBottle();
        }

        /// <summary>
        /// Checks for one of a list of damaging items. Allows for one or more of that list to not be excluded from the check.
        /// List of damaging items: Sword, Ball and Chain, Bombs, Boots, Bow, Shadow Crystal, Spinner, Backslice (if can be used).
        /// List of expected item names: "Bombs", "Boots", "Bow", "Shadow_Crystal", "Spinner", "Backslice".
        /// </summary>
        /// <param name="exclusions">Optional (defaults to null for no exclusions). Pass a list of item names to not check for them.</param>
        /// <returns></returns>
        public static bool HasDamagingItem(List<string> exclusions = null)
        {
            // Prevents issues if exclusions is null. Safety net.
            if (exclusions == null)
            {
                exclusions = new List<string>();
            }

            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || (!exclusions.Contains("Bombs") && hasBombs())
                || (!exclusions.Contains("Boots") && CanFightWithBoots())
                || (!exclusions.Contains("Bow") && HasBowAndArrows())
                || (!exclusions.Contains("Shadow_Crystal") && CanUse(Item.Shadow_Crystal))
                || (!exclusions.Contains("Spinner") && CanUse(Item.Spinner))
                || (!exclusions.Contains("Backslice") && CanUseBacksliceAsSword());
        }
        // NOTE: You could probably add variables with the different possible exclusions and exclusion combinations.
        //  This would be a bit less repetitive. I didn't implement it because I don't know how that would affect memory usage,
        //  or if memory usage is a problem to consider.
        // - Lupa (SadieDragon)

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
            return CanUse(Item.Progressive_Bow) && CanGetArrows();
        }

        /// <summary>
        /// Determines if the user has a shield and at least 2 hidden skills.
        /// </summary>
        public static bool CanSheildAttack()
        {
            return hasShield() && (getItemCount(Item.Progressive_Hidden_Skill) >= 2);
        }

        //TODO: Helper functions for "has reached room?" to be more readable?
        //  (there are a lot of repeated rooms...)
        //TODO: Helper functions for frequent exclusions? (Need names)

        //TODO Go through and set variables within fns for repeated checks in those functions.

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
            return HasDamagingItem() || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent()
        {
            return HasDamagingItem();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return (CanUse(Item.Boomerang) || HasBowAndArrows())
                && CanDefeatBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma()
        {
            return HasDamagingItem(new List<string>() { "Shadow_Crystal" })
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot);
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
            return canSmash() || HasBowAndArrows();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu()
        {
            return HasDamagingItem() || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin()
        {
            return HasDamagingItem() || CanUse(Item.Slingshot);
        }

        public static bool CanDefeatBokoblinRed()
        {
            return (
                HasSword()
                || canSmash()
                || ((getItemCount(Item.Progressive_Bow) >= 3) && CanGetArrows())
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
                || (CanDoDifficultCombat() && (CanUse(Item.Iron_Boots) || CanUse(Item.Spinner)))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombfish()
        {
            return (CanUse(Item.Iron_Boots) || CanUseMagicArmorAsBoots())
                && (
                    HasSword()
                    || CanUse(Item.Progressive_Clawshot)
                    || CanSheildAttack()
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling()
        {
            return HasDamagingItem(new List<string>() { "Bombs", "Backslice" }) || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit()
        {
            return HasDamagingItem(new List<string>() { "Backslice" });
        }

        /// <summary>
        /// Checks if at least one item to defeat Bubble is available.
        /// [Valid Items: Sword, Ball and Chain, Boots, Bow, Shadow Crystal, Spinner, Backslice (if can be used).]
        /// </summary>
        public static bool CanDefeatBubble()
        {
            return HasDamagingItem(new List<string>() { "Bombs" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos()
        {
            return HasDamagingItem(new List<string>() { "Bow" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChuWorm()
        {
            return HasDamagingItem(new List<string>() { "Bombs" })
                && (hasBombs() || CanUse(Item.Progressive_Clawshot));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarknut()
        {
            return HasSword() || (CanDoDifficultCombat() && canSmash());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuBaba()
        {
            return HasDamagingItem(new List<string>() { "Shadow_Crystal" })
                || CanSheildAttack()
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuLike()
        {
            return hasBombs();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDodongo()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDinalfos()
        {
            return HasSword() || CanUse(Item.Ball_and_Chain) || CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireBubble()
        {
            return CanDefeatBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireKeese()
        {
            // Same logic.
            return CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireToadpoli()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || HasBowAndArrows()
                || CanSheildAttack()
                || (CanDoDifficultCombat() && CanUse(Item.Shadow_Crystal));
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
            return HasDamagingItem(new List<string>() {"Shadow_Crystal", "Spinner"})
                || CanSheildAttack()
                || CanUse(Item.Slingshot)
                || (CanDoDifficultCombat() && CanUse(Item.Lantern))
                || CanUse(Item.Progressive_Clawshot);
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
            return HasDamagingItem(new List<string>() {"Bombs", "Spinner", "Backslice"})
                || (CanDoDifficultCombat() && CanUse(Item.Spinner))
                || CanUse(Item.Slingshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceBubble()
        {
            return CanDefeatBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceKeese()
        {
            // Same logic.
            return CanDefeatKeese();
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
            return HasDamagingItem(new List<string>() { "Bombs" });
        }

        /// <summary>
        /// Checks if at least one item to defeat Keese is available.
        /// [Valid Items: Sword, B&C, Boots, Bow, SC, Spinner, Backslice (if can be used), Slingshot.]
        /// </summary>
        public static bool CanDefeatKeese()
        {
            return HasDamagingItem(new List<string>() { "Bombs" }) || CanUse(Item.Slingshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever()
        {
            return HasDamagingItem(new List<string>() { "Backslice" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos()
        {
            return HasDamagingItem(new List<string>() { "Spinner" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm()
        {
            return HasDamagingItem(new List<string>() { "Backslice" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite()
        {
            return HasDamagingItem(new List<string>() {"Bombs", "Boots", "Backslice"})
                || CanUse(Item.Lantern);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat()
        {
            return HasDamagingItem() || CanUse(Item.Slingshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight()
        {
            return HasDamagingItem(new List<string>() { "Spinner" });
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
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return HasDamagingItem(new List<string>() { "Shadow_Crystal" })
                || CanSheildAttack()
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot);
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
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese()
        {
            // Same logic.
            return CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShellBlade()
        {
            return CanUseWaterBombs()
                || (
                    HasSword()
                    && (CanUse(Item.Iron_Boots) || CanUseMagicArmorAsBoots())
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullfish()
        {
            return HasDamagingItem(new List<string>() { "Bombs", "Backslice" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalfos()
        {
            return canSmash();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalhound()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite()
        {
            return HasDamagingItem();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm()
        {
            return HasDamagingItem() && CanUse(Item.Boomerang);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado()
        {
            return HasDamagingItem(new List<string>() {"Bombs", "Boots", "Backslice"});
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWaterToadpoli()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || HasBowAndArrows()
                || CanSheildAttack()
                || CanDoDifficultCombat() && CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug()
        {
            return HasDamagingItem(new List<string>() {"Boots", "Spinner", "Backslice"});
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWalltula()
        {
            return CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Slingshot)
                || HasBowAndArrows()
                || CanUse(Item.Boomerang)
                || CanUse(Item.Progressive_Clawshot);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos()
        {
            return HasDamagingItem(new List<string>() { "Backslice" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma()
        {
            return HasDamagingItem(new List<string>() { "Backslice" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZantHead()
        {
            return CanUse(Item.Shadow_Crystal) || HasSword() || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatOok()
        {
            return HasDamagingItem(new List<string>() { "Spinner" });
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDangoro()
        {
            return (
                    HasSword()
                    || CanUse(Item.Shadow_Crystal)
                    || (
                        CanDoNicheStuff() && CanUse(Item.Ball_and_Chain)
                        || (CanUse(Item.Progressive_Bow) && hasBombs())
                    )
                ) && CanUse(Item.Iron_Boots);
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
            return HasDamagingItem(new List<string>() { "Spinner" });
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
            return HasSword()
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
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinCastle()
        {
            return HasSword()
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
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDeathSword()
        {
            return HasSword()
                && (
                    CanUse(Item.Boomerang)
                    || HasBowAndArrows()
                    || CanUse(Item.Progressive_Clawshot)
                )
                && CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarkhammer()
        {
            return HasDamagingItem(new List<string>() { "Spinner", "Backslice" }) || (CanDoDifficultCombat() && CanUseBacksliceAsSword());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPhantomZant()
        {
            return CanUse(Item.Shadow_Crystal) || HasSword();
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
                        HasDamagingItem(new List<string>() { "Spinner", "Backslice" })
                        || (CanDoDifficultCombat() && CanUseBacksliceAsSword())
                    )
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFyrus()
        {
            return CanUse(Item.Progressive_Bow)
                && CanUse(Item.Iron_Boots)
                && (HasSword() || (CanDoDifficultCombat() && CanUseBacksliceAsSword()));
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
            return (CanUse(Item.Spinner) && HasSword()) || (CanDoDifficultCombat() && CanUse(Item.Spinner));
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
            return CanUse(Item.Progressive_Bow) && CanUse(Item.Progressive_Dominion_Rod);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArgorok()
        {
            return getItemCount(Item.Progressive_Clawshot) >= 2
                && getItemCount(Item.Progressive_Sword) >= 2
                && (CanUse(Item.Iron_Boots) || CanUseMagicArmorAsBoots());
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
                    && (CanUse(Item.Iron_Boots) || CanUseMagicArmorAsBoots())
                    && (
                        CanUse(Item.Zora_Armor)
                        || (
                            CanDoNicheStuff()
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
            return CanUse(Item.Ball_and_Chain) || hasBombs();
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
            // Please use CanShopFromRoom in the future for DM HotSpring if randomizable- Lupa
            return CanUse(Item.Hylian_Shield)
                || CanShopFromRoom("Kakariko Malo Mart")
                || CanShopFromRoom("Castle Town Goron House")
                || HasReachedRoom("Death Mountain Hot Spring");
        }

        public static bool CanUseBottledFairy()
        {
            return HasBottle() && HasReachedRoom("Lake Hylia");
        }

        public static bool CanUseBottledFairies()
        {
            return HasBottles() && HasReachedRoom("Lake Hylia");
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
            return getItemCount(Item.Progressive_Bow) >= 1
                || (
                    CanDoNicheStuff()
                    && (
                        hasBombs()
                        || (HasSword() && getItemCount(Item.Progressive_Hidden_Skill) >= 6)
                    )
                )
                || (
                    CanDoNicheStuff()
                    && ((HasSword() && CanDoMoonBoots()) || CanDoBSMoonBoots())
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBreakMonkeyCage()
        {
            return HasSword()
                || CanUse(Item.Iron_Boots)
                || CanUse(Item.Spinner)
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || HasBowAndArrows()
                || CanUse(Item.Progressive_Clawshot)
                || CanDoNicheStuff() && CanSheildAttack();
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
            return canBreakMonkeyCage()
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
                );
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
        /// summary text.
        /// </summary>
        public static bool canBreakWoodenDoor()
        {
            return CanUse(Item.Shadow_Crystal) || HasSword() || canSmash() || CanUseBacksliceAsSword();
        }

        /// Start of helper functions for ER looking things - Lupa

        /// <summary>
        /// A function for this file to use. Checks if the provided room has been reached by the playthrough.
        /// </summary>
        /// <param name="room">Name of the room to check.</param>
        public static bool HasReachedRoom(string room)
        {
            // This ensures that the key (room name) must exist in the dictionary.
            if (Randomizer.Rooms.RoomDict.TryGetValue(room, out var RoomData))
            {
                return RoomData.ReachedByPlaythrough;
            }

            // If it does not, then print a warning to the console and return false to be safe.
            Console.WriteLine($"Warning: Room '{room}' not found in the dictionary. [line 1203 of LogicFunctions.cs]");
            return false;
        }

        /// <summary>
        /// Checks for if it is not shop sanity, and if the room can be accessed.
        /// </summary>
        /// <param name="room">Name of the room to check.</param>
        public static bool CanShopFromRoom(string room)
        {
            return HasReachedRoom(room) && !Randomizer.SSettings.shuffleShopItems;
        }

        /// Repeated checked rooms!

        /// Barnes' Bomb Shop
        public static bool HasReachedBarnesBombs = HasReachedRoom("Kakariko Barnes Bomb Shop Lower");

        /// Kakariko Malo Mart
        public static bool HasReachedKakarikoMaloMart = HasReachedRoom("Kakariko Malo Mart");

        /// Lower Kakariko Village
        public static bool HasReachedLowerKakariko = HasReachedRoom("Lower Kakariko Village");

        /// North Faron Woods
        public static bool HasReachedNorthFaronWoods = HasReachedRoom("North Faron Woods");

        /// South Castle Town
        public static bool HasReachedSouthCastleTown = 

        /// End of helper functions to check for ER looking things - Lupa

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasBombs()
        {
            return CanUse(Item.Filled_Bomb_Bag)
                && (
                    HasReachedBarnesBombs
                    || CanFishForWaterBombs()
                    || HasReachedRoom("City in The Sky Entrance")
                );
        }

        /// <summary>
        /// Checks if Eldin Field Water Bomb Fish Grotto has been reached, and there is a fishing rod.
        /// </summary>
        /// <returns></returns>
        public static bool CanFishForWaterBombs()
        {
            return HasReachedRoom("Eldin Field Water Bomb Fish Grotto") && CanUse(Item.Progressive_Fishing_Rod);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUseWaterBombs()
        {
            return CanUse(Item.Filled_Bomb_Bag)
                && (
                    HasReachedBarnesBombs
                    || CanFishForWaterBombs()
                    || (HasReachedBarnesBombs && HasReachedRoom("Castle Town Malo Mart"))
                );
        }

        /// <summary>
        /// This is a temporary function that ensures arrows can be refilled for bow usage in Faron Woods/FT.
        /// </summary>
        public static bool CanGetArrows()
        {
            return HasReachedRoom("Lost Woods")
                || (
                    canCompleteGoronMines()
                    && HasReachedKakarikoMaloMart
                )
                || CanShopFromRoom("Castle Town Goron House Balcony");
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompletePrologue()
        {
            return (
                (
                    HasReachedNorthFaronWoods
                    && CanDefeatBokoblin()
                ) || (Randomizer.SSettings.skipPrologue == true)
            );
        }

        public static bool CanCompleteGoats1()
        {
            return HasReachedRoom("Ordon Ranch") || canCompletePrologue();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanCompleteMDH()
        {
            return (Randomizer.SSettings.skipMdh == true)
                || (
                    canCompleteLakebedTemple()
                    && HasReachedSouthCastleTown
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
                    && HasReachedRoom("South Faron Woods")
                    && HasReachedRoom("Faron Woods Coros House Lower")
                    && HasReachedRoom("Mist Area Near Faron Woods Cave")
                    && HasReachedNorthFaronWoods
                    && HasReachedRoom("Ordon Spring")
                    && CanSurviveBonkDamage()
                );
        }

        /// <summary>
        /// Can complete Eldin twilight
        /// </summary>
        public static bool CanCompleteEldinTwilight()
        {
            return Randomizer.SSettings.eldinTwilightCleared
                || (
                    HasReachedRoom("Faron Field")
                    && HasReachedLowerKakariko
                    && HasReachedRoom("Kakariko Graveyard")
                    && HasReachedKakarikoMaloMart
                    && HasReachedRoom("Kakariko Barnes Bomb Shop Upper")
                    && HasReachedRoom("Kakariko Renados Sanctuary Basement")
                    && HasReachedRoom("Kakariko Elde Inn")
                    && HasReachedRoom("Kakariko Bug House")
                    && HasReachedRoom("Upper Kakariko Village")
                    && HasReachedRoom("Kakariko Watchtower")
                    && HasReachedRoom("Death Mountain Volcano")
                    && CanSurviveBonkDamage()
                );
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return Randomizer.SSettings.lanayruTwilightCleared
                || (
                    (HasReachedRoom("North Eldin Field") || CanUse(Item.Shadow_Crystal))
                    && HasReachedRoom("Zoras Domain")
                    && HasReachedRoom("Zoras Domain Throne Room")
                    && HasReachedRoom("Upper Zoras River")
                    && HasReachedRoom("Lake Hylia")
                    && HasReachedRoom("Lake Hylia Lanayru Spring")
                    && HasReachedSouthCastleTown
                    && CanSurviveBonkDamage()
                );
        }

        public static bool CanCompleteAllTwilight()
        {
            return CanCompleteFaronTwilight()
                && CanCompleteEldinTwilight()
                && CanCompleteLanayruTwilight();
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
            return canCompleteForestTemple()
                && canCompleteGoronMines()
                && canCompleteLakebedTemple()
                && canCompleteArbitersGrounds()
                && canCompleteSnowpeakRuins()
                && canCompleteTempleofTime()
                && canCompleteCityinTheSky()
                && canCompletePalaceofTwilight();
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

        /// <summary>
        /// Checks for the ability to survive damage done by bonks in OHKO mode.
        /// </summary>
        public static bool CanSurviveBonkDamage()
        {
            // Check the setting "bonksDoDamage"
            bool BonksDamageEnabled = Randomizer.SSettings.bonksDoDamage;

            // Check if OHKO is enabled.
            bool OneHitKnockOutEnabled = !Randomizer.SSettings.damageMagnification.Equals(DamageMagnification.OHKO);

            // If bonks do damage, check for the ability to use fairies.
            return !BonksDamageEnabled
                || (
                    BonksDamageEnabled
                    && (OneHitKnockOutEnabled || CanUseBottledFairies())
                );
        }

        /// <summary>
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
            return CanDoNicheStuff() && CanUse(Item.Iron_Boots);
        }

        /// <summary>
        /// Checks if the user can use Magic Armor as Iron Boots.
        /// </summary>
        public static bool CanUseMagicArmorAsBoots()
        {
            return CanDoNicheStuff() && CanUse(Item.Magic_Armor);
        }

        public static bool CanUseBacksliceAsSword()
        {
            return CanDoNicheStuff() && getItemCount(Item.Progressive_Hidden_Skill) >= 3;
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
                && HasReachedRoom("Kakariko Gorge");
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
