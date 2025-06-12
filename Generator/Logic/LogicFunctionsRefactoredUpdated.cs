using System;
using System.Collections.Generic;
using System.Reflection;
using TPRandomizer.SSettings.Enums;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using HLF = LogicFunctionsNS.HelperFunctions;

namespace TPRandomizer
{
    /// <summary>
    /// summary text.
    /// </summary>
    public class LogicFunctionsUpdatedRefactored
    {
        // Placeholder notes for what's on the bridge
        public static SharedSettings SharedSettings = Randomizer.SSettings;
        public static bool IsGlitchedLogic = SharedSettings.logicRules == LogicRules.Glitched;
        public static bool IsKeysy = SharedSettings.smallKeySettings == SmallKeySettings.Keysy;
        public static bool IsOpenFaronWoods =
            SharedSettings.faronWoodsLogic == FaronWoodsLogic.Open;
        public static bool EldingTwilightCleared = SharedSettings.eldinTwilightCleared;

        //Evaluate the tokenized settings to their respective values that are set by the settings string.

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool EvaluateSetting(string setting, string value)
        {
            PropertyInfo[] settingProperties = SharedSettings.GetType().GetProperties();

            setting = setting.Replace("Setting.", "");
            bool isEqual = false;
            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(SharedSettings, null);
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
            return Randomizer.Items.heldItems.Contains(item) && CanReplenishItem(item);
        }

        public static bool CanReplenishItem(Item item)
        {
            bool replenish = false;
            switch (item)
            {
                case Item.Lantern:
                {
                    if (CanRefillOil())
                    {
                        replenish = true;
                    }
                    break;
                }

                case Item.Progressive_Bow:
                {
                    if (CanGetArrows())
                    {
                        replenish = true;
                    }
                    break;
                }

                default:
                {
                    replenish = true;
                    break;
                }
            }
            return replenish;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUse(string item)
        {
            return CanUse(Enum.Parse<Item>(item));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanChangeTime()
        {
            return CanUse(Item.Shadow_Crystal)
                || ERLF.HasReachedAnyRooms(RoomFunctions.timeFlowStages);
        }

        public static bool CanWarp()
        {
            return CanUse(Item.Shadow_Crystal)
                && ERLF.HasReachedAnyRooms(RoomFunctions.WarpableStages);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canGetHotSpringWater()
        {
            return (
                    ERLF.HasReachedLowerKakVillage()
                    || (ERLF.HasReachedRoom("Death Mountain Elevator Lower") && CanDefeatGoron())
                ) && HasBottle();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasDamagingItem()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || hasBombs()
                || CanUse(Item.Iron_Boots)
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Spinner);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasSword()
        {
            return CanUse(Item.Progressive_Sword);
        }

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
                    || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmos()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Progressive_Clawshot)
                || hasBombs()
                || CanUse(Item.Spinner)
                || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return (CanUse(Item.Boomerang) || CanUse(Item.Progressive_Bow))
                && LogicFunctions.CanDefeatBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot)
                || hasBombs()
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
            return CanUse(Item.Ball_and_Chain) || CanUse(Item.Progressive_Bow) || hasBombs();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba()
        {
            return HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Spinner)
                || hasBombs()
                || CanUseBacksliceAsSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Progressive_Clawshot)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
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
                (CanUse(Item.Iron_Boots) || IsGlitchedLogic && CanUse(Item.Magic_Armor))
                && (HasSword() || CanUse(Item.Progressive_Clawshot) || HLF.CanShieldAttack())
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Progressive_Clawshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBubble()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Spinner)
                || hasBombs()
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
                    HasSword()
                    || CanUse(Item.Ball_and_Chain)
                    || CanUse(Item.Progressive_Bow)
                    || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                    || CanUse(Item.Spinner)
                    || CanUse(Item.Shadow_Crystal)
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || HLF.CanShieldAttack()
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot)
                || hasBombs()
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
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireKeese()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Shadow_Crystal)
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
                || CanUse(Item.Progressive_Bow)
                || (CanUse(Item.Hylian_Shield) && HLF.HasShieldAttack())
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || HLF.CanShieldAttack()
                || CanUse(Item.Slingshot)
                || (CanDoDifficultCombat() && CanUse(Item.Lantern))
                || CanUse(Item.Progressive_Clawshot)
                || hasBombs()
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || (CanDoDifficultCombat() && CanUse(Item.Spinner))
                || CanUse(Item.Shadow_Crystal)
                || CanUse(Item.Slingshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceBubble()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceKeese()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Shadow_Crystal)
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKeese()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Lantern)
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
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
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || HLF.CanShieldAttack()
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Clawshot)
                || hasBombs()
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
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Shadow_Crystal)
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
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
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
                || CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm()
        {
            return (
                (
                    HasSword()
                    || CanUse(Item.Ball_and_Chain)
                    || CanUse(Item.Progressive_Bow)
                    || CanUse(Item.Shadow_Crystal)
                    || CanUse(Item.Spinner)
                    || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                    || hasBombs()
                    || CanUseBacksliceAsSword()
                ) && CanUse(Item.Boomerang)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
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
                || CanUse(Item.Progressive_Bow)
                || HLF.CanShieldAttack()
                || CanDoDifficultCombat() && (CanUse(Item.Shadow_Crystal))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
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
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Boomerang)
                || CanUse(Item.Progressive_Clawshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma()
        {
            return (
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Spinner)
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
            );
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
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
                    || CanUse(Item.Progressive_Bow)
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
                HasSword()
                || CanUse(Item.Ball_and_Chain)
                || CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                || CanUse(Item.Shadow_Crystal)
                || hasBombs()
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
                        HasSword()
                        || CanUse(Item.Ball_and_Chain)
                        || (CanDoNicheStuff() && CanUse(Item.Iron_Boots))
                        || CanUse(Item.Shadow_Crystal)
                        || hasBombs()
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
                    && (CanUse(Item.Progressive_Clawshot) && CanDoAirRefill() && HasSword())
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
            return (CanUse(Item.Progressive_Bow) && CanUse(Item.Progressive_Dominion_Rod));
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
                    && (CanUse(Item.Zora_Armor) || (IsGlitchedLogic && CanDoAirRefill()))
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
                || CanUse(Item.Progressive_Bow)
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
                || ERLF.CanShopFromRoom("Kakariko Malo Mart")
                || ERLF.CanShopFromRoom("Castle Town Goron House")
                || ERLF.HasReachedRoom("Death Mountain Hot Spring")
            );
        }

        public static bool CanUseBottledFairy()
        {
            return HasBottle() && ERLF.HasReachedLakeHylia();
        }

        public static bool CanUseBottledFairies()
        {
            return HasBottles() && ERLF.HasReachedLakeHylia();
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
            return ((CanUse(Item.Boomerang) || CanUse(Item.Progressive_Bow)) && hasBombs());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCutHangingWeb()
        {
            return (
                CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Progressive_Bow)
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
                CanUse(Item.Progressive_Bow)
                || (CanDoNicheStuff() && (hasBombs() || (HasSword() && HLF.HasJumpStrike())))
                || (IsGlitchedLogic && ((HasSword() && CanDoMoonBoots()) || CanDoBSMoonBoots()))
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
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Progressive_Clawshot)
                || (CanDoNicheStuff() && HLF.CanShieldAttack())
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
                && (CanUse(Item.Lantern) || (IsKeysy && (hasBombs() || CanUse(Item.Iron_Boots))))
                && canBurnWebs()
                && CanUse(Item.Boomerang)
                && CanDefeatBokoblin()
                && ((getItemCount(Item.Forest_Temple_Small_Key) >= 4) || IsKeysy)
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
                    ERLF.HasReachedBarnesBombs()
                    || (ERLF.HasReachedEFBombfishGrotto() && CanUse(Item.Progressive_Fishing_Rod))
                    || ERLF.HasReachedRoom("City in The Sky Entrance")
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
                    ERLF.HasReachedBarnesBombs()
                    || (ERLF.HasReachedEFBombfishGrotto() && CanUse(Item.Progressive_Fishing_Rod))
                    || (
                        ERLF.HasReachedBarnesBombs() && ERLF.HasReachedRoom("Castle Town Malo Mart")
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
                ERLF.HasReachedRoom("Lost Woods")
                || (canCompleteGoronMines() && ERLF.HasReachedKakMaloMart())
                || ERLF.CanShopFromRoom("Castle Town Goron House Balcony")
            );
        }

        public static bool CanRefillOil()
        {
            return (
                ERLF.HasReachedNFaronWoods()
                || ERLF.HasReachedSFaronWoods()
                || ERLF.HasReachedRoom("Arbiters Grounds Entrance")
                || (ERLF.HasReachedRoom("Lake Hylia Long Cave") && canSmash())
                || ERLF.HasReachedRoom("Ordon Seras Shop")
                || (canCompleteGoronMines() && ERLF.HasReachedLowerKakVillage() && CanChangeTime())
                || ERLF.CanShopFromRoom("Castle Town Goron House")
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompletePrologue()
        {
            return (ERLF.HasReachedNFaronWoods() && CanDefeatBokoblin())
                || (SharedSettings.skipPrologue == true);
        }

        public static bool CanCompleteGoats1()
        {
            return ERLF.HasReachedRoom("Ordon Ranch") || canCompletePrologue();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanCompleteMDH()
        {
            return (
                (SharedSettings.skipMdh == true)
                || (canCompleteLakebedTemple() && ERLF.HasReachedSCastleTown())
            );
            //return (canCompleteLakebedTemple() || (SharedSettings.skipMdh == true));
        }

        public static bool CanMidnaCharge()
        {
            return CanCompleteMDH() && CanCompleteAllTwilight();
        }

        public static bool CanStrikePedestal()
        {
            return getItemCount(Item.Progressive_Sword) >= (int)SharedSettings.totEntrance;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canClearForest()
        {
            return (
                (canCompleteForestTemple() || IsOpenFaronWoods)
                && canCompletePrologue()
                && CanCompleteFaronTwilight()
            );
        }

        /// <summary>
        /// Can complete Faron twilight
        /// </summary>
        public static bool CanCompleteFaronTwilight()
        {
            return SharedSettings.faronTwilightCleared
                || (
                    canCompletePrologue()
                    && ERLF.HasReachedSFaronWoods()
                    && ERLF.HasReachedRoom("Faron Woods Coros House Lower")
                    && ERLF.HasReachedRoom("Mist Area Near Faron Woods Cave")
                    && ERLF.HasReachedNFaronWoods()
                    && ERLF.HasReachedRoom("Ordon Spring")
                    && HLF.CanSurviveBonkDamage()
                );
        }

        /// <summary>
        /// Can complete Eldin twilight
        /// </summary>
        public static bool CanCompleteEldinTwilight()
        {
            return EldingTwilightCleared
                || (
                    ERLF.HasReachedRoom("Faron Field")
                    && ERLF.HasReachedLowerKakVillage()
                    && ERLF.HasReachedRoom("Kakariko Graveyard")
                    && ERLF.HasReachedKakMaloMart()
                    && ERLF.HasReachedRoom("Kakariko Barnes Bomb Shop Upper")
                    && ERLF.HasReachedRoom("Kakariko Renados Sanctuary Basement")
                    && ERLF.HasReachedRoom("Kakariko Elde Inn")
                    && ERLF.HasReachedRoom("Kakariko Bug House")
                    && ERLF.HasReachedRoom("Upper Kakariko Village")
                    && ERLF.HasReachedRoom("Kakariko Watchtower")
                    && ERLF.HasReachedRoom("Death Mountain Volcano")
                    && HLF.CanSurviveBonkDamage()
                );
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return SharedSettings.lanayruTwilightCleared
                || (
                    (ERLF.HasReachedRoom("North Eldin Field") || CanUse(Item.Shadow_Crystal))
                    && ERLF.HasReachedRoom("Zoras Domain")
                    && ERLF.HasReachedZorasThroneRoom()
                    && ERLF.HasReachedRoom("Upper Zoras River")
                    && ERLF.HasReachedLakeHylia()
                    && ERLF.HasReachedRoom("Lake Hylia Lanayru Spring")
                    && ERLF.HasReachedSCastleTown()
                    && HLF.CanSurviveBonkDamage()
                );
        }

        public static bool CanWarpMeteor()
        {
            return CanCompleteLanayruTwilight()
                || (
                    CanCompleteEldinTwilight()
                    && ERLF.HasReachedZorasThroneRoom()
                    && CanUse(Item.Shadow_Crystal)
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
            return ERLF.CanUnlockRegionalMap(RoomFunctions.OrdonaMapRooms);
        }

        public static bool CanUnlockFaronMap()
        {
            return ERLF.CanUnlockRegionalMap(RoomFunctions.FaronMapRooms);
        }

        public static bool CanUnlockEldinMap()
        {
            return ERLF.CanUnlockRegionalMap(RoomFunctions.EldinMapRooms);
        }

        public static bool CanUnlockLanayruMap()
        {
            return ERLF.CanUnlockRegionalMap(RoomFunctions.LanayruMapRooms);
        }

        public static bool CanUnlockSnowpeakMap()
        {
            return SharedSettings.skipSnowpeakEntrance
                || ERLF.CanUnlockRegionalMap(RoomFunctions.SnowpeakMapRooms);
        }

        public static bool CanUnlockGerudoMap()
        {
            return ERLF.CanUnlockRegionalMap(RoomFunctions.GerudoMapRooms);
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
            return IsGlitchedLogic;
        }

        public static bool CanUseBacksliceAsSword()
        {
            return CanDoNicheStuff() && HLF.HasBackslice();
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
            return CanUse(Item.Progressive_Sword) || HLF.HasBackslice();
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
            return CanUse(Item.Progressive_Sky_Book) || HasBottle() || CanUse(Item.Horse_Call);
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
            return HasSword() && CanUse(Item.Boomerang) && HLF.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Map Glitch
        /// </summary>
        public static bool CanDoMapGlitch()
        {
            return CanUse(Item.Shadow_Crystal) && ERLF.HasReachedRoom("Kakariko Gorge");
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
                || CanUse(Item.Progressive_Clawshot)
                || CanUse(Item.Lantern)
                || CanUse(Item.Progressive_Bow)
                || CanUse(Item.Slingshot)
                || CanUse(Item.Progressive_Dominion_Rod);
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
            return CanDoMoonBoots() && HLF.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Back Slice Moon Boots
        /// </summary>
        public static bool CanDoBSMoonBoots()
        {
            return HLF.HasBackslice() && CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for if you can do Ending Blow Moon Boots
        /// </summary>
        public static bool CanDoEBMoonBoots()
        {
            return CanDoMoonBoots()
                && CanUse(Item.Progressive_Hidden_Skill)
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
            return CanUse(Item.Progressive_Fishing_Rod) && HasHeavyMod();
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
                    IsOpenFaronWoods
                    || (canCompleteForestTemple() || CanDoLJA() || CanDoMapGlitch())
                )
            );
        }

        /// <summary>
        /// Check for if Eldin twilight can be completed (glitched). Check this for if map warp can be obtained
        /// </summary>
        public static bool CanCompleteEldinTwilightGlitched()
        {
            return EldingTwilightCleared || canClearForestGlitched();
        }

        /// <summary>
        /// Check for if you need the key for getting to Lakebed Deku Toad
        ///
        public static bool CanSkipKeyToDekuToad()
        {
            return IsKeysy
                || HLF.HasBackslice()
                || CanDoBSMoonBoots()
                || CanDoJSMoonBoots()
                || CanDoLJA()
                || (hasBombs() && (HasHeavyMod() || HLF.HasJumpStrike()));
        }

        // END OF GLITCHED LOGIC

        public static int getItemCount(Item itemToBeCounted)
        {
            List<Item> itemList = Randomizer.Items.heldItems;
            int itemQuantity = 0;
            foreach (var item in itemList)
            {
                if ((item == itemToBeCounted) && CanReplenishItem(itemToBeCounted))
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
