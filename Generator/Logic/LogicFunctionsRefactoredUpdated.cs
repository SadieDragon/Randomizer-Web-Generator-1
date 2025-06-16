using System;
using System.Collections.Generic;
using System.Reflection;
using TPRandomizer.SSettings.Enums;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using GLL = LogicFunctionsNS.GlitchlessLogic;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using HLF = LogicFunctionsNS.HelperFunctions;
using HSL = LogicFunctionsNS.HasSwordLevel;
using NLU = LogicFunctionsNS.NicheLogicUtils;

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
            return CUU.CanUse(item);
        }

        public static bool CanReplenishItem(Item item)
        {
            return CUU.CanReplenishItem(item);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUse(string item)
        {
            return CUU.CanUse(Enum.Parse<Item>(item));
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
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || BU.HasBombs()
                || CUU.CanUse(Item.Iron_Boots)
                || CUU.CanUse(Item.Shadow_Crystal)
                || CUU.CanUse(Item.Spinner);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasSword()
        {
            return HSL.HasSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatAeralfos()
        {
            return GLL.CanDefeatAeralfos() || NLU.CanUseIronBootsAndDoNiche();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmos()
        {
            return GLL.CanDefeatArmos() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent()
        {
            return GLL.CanDefeatBabaSerpent() || NLU.CanUseIronBootsOrBackslice();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return GLL.CanDefeatHangingBabaSerpent() && CanDefeatBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma()
        {
            return GLL.CanDefeatBabyGohma() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBari()
        {
            return GLL.CanDefeatBari();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBeamos()
        {
            return GLL.CanDefeatBeamos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba()
        {
            return GLL.CanDefeatBigBaba() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu()
        {
            return GLL.CanDefeatChu() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin()
        {
            return GLL.CanDefeatBokoblin() || NLU.CanUseIronBootsOrBackslice();
        }

        public static bool CanDefeatBokoblinRed()
        {
            return GLL.CanDefeatBokoblinRed()
                || NLU.CanUseBacksliceAsSword()
                // DifficultCombat
                || (
                    CanDoDifficultCombat()
                    && (CUU.CanUse(Item.Iron_Boots) || CUU.CanUse(Item.Spinner))
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombfish()
        {
            // second half of or statement is glitched logic
            return (GLL.CanDefeatBombfish() || (IsGlitchedLogic && CUU.CanUse(Item.Magic_Armor)))
                && GLL.CanDefeatBombfishCoreRequirements();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling()
        {
            return GLL.CanDefeatBombling() || NLU.CanUseIronBootsAndDoNiche();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit()
        {
            return GLL.CanDefeatBomskit() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBubble()
        {
            return GLL.CanDefeatBubble() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin()
        {
            return GLL.CanDefeatBulblin() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos()
        {
            return GLL.CanDefeatChilfos() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChuWorm()
        {
            return (GLL.CanDefeatChuWorm() || NLU.CanUseIronBootsOrBackslice())
                && GLL.CanDefeatChuWormCoreRequirements();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarknut()
        {
            return GLL.CanDefeatDarknut()
                // DifficultCombat
                || (CanDoDifficultCombat() && (BU.HasBombs() || CUU.CanUse(Item.Ball_and_Chain)));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuBaba()
        {
            return GLL.CanDefeatDekuBaba() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuLike()
        {
            return GLL.CanDefeatDekuLike();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDodongo()
        {
            return GLL.CanDefeatDodongo() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDinalfos()
        {
            return GLL.CanDefeatDinalfos();
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
            return CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireToadpoli()
        {
            return GLL.CanDefeatFireToadpoli()
                || (CanDoDifficultCombat() && CUU.CanUse(Item.Shadow_Crystal));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFreezard()
        {
            return GLL.CanDefeatFreezard();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGoron()
        {
            return GLL.CanDefeatGoron()
                || NLU.CanUseIronBootsOrBackslice()
                || (CanDoDifficultCombat() && CUU.CanUse(Item.Lantern)); // DifficultCombat
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGhoulRat()
        {
            return GLL.CanDefeatGhoulRat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGuay()
        {
            return GLL.CanDefeatGuay()
                || NLU.CanUseIronBootsAndDoNiche()
                || (CanDoDifficultCombat() && CUU.CanUse(Item.Spinner)); // DifficultCombat
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur()
        {
            return GLL.CanDefeatHelmasaur() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus()
        {
            return GLL.CanDefeatHelmasaurus() || NLU.CanUseIronBootsOrBackslice();
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
            return CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoe()
        {
            return GLL.CanDefeatPoe();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKargarok()
        {
            return GLL.CanDefeatKargarok() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKeese()
        {
            return GLL.CanDefeatKeese() || NLU.CanUseIronBootsOrBackslice();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsAndDoNiche()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsAndDoNiche()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Lantern)
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBeast()
        {
            return HSL.HasSword() || (CUU.CanUse(Item.Shadow_Crystal) && CanMidnaCharge());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBulblin()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || HLF.CanShieldAttack()
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowInsect()
        {
            return CUU.CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKargarok()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese()
        {
            return CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShellBlade()
        {
            return (
                BU.CanUseWaterBombs()
                || (
                    HSL.HasSword()
                    && (
                        CUU.CanUse(Item.Iron_Boots)
                        || (CanDoNicheStuff() && CUU.CanUse(Item.Magic_Armor))
                    )
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullfish()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsAndDoNiche()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalfos()
        {
            return BU.CanSmash();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalhound()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm()
        {
            return (
                (
                    HSL.HasSword()
                    || CUU.CanUse(Item.Ball_and_Chain)
                    || CUU.CanUse(Item.Progressive_Bow)
                    || CUU.CanUse(Item.Shadow_Crystal)
                    || CUU.CanUse(Item.Spinner)
                    || NLU.CanUseIronBootsOrBackslice()
                    || BU.HasBombs()
                ) && CUU.CanUse(Item.Boomerang)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWaterToadpoli()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || HLF.CanShieldAttack()
                || CanDoDifficultCombat() && (CUU.CanUse(Item.Shadow_Crystal))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWalltula()
        {
            return (
                CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Progressive_Clawshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsAndDoNiche()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsAndDoNiche()
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZantHead()
        {
            return CUU.CanUse(Item.Shadow_Crystal)
                || HSL.HasSword()
                || NLU.CanUseBacksliceAsSword();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatOok()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDangoro()
        {
            return (
                (
                    HSL.HasSword()
                    || CUU.CanUse(Item.Shadow_Crystal)
                    || (
                        CanDoNicheStuff() && CUU.CanUse(Item.Ball_and_Chain)
                        || (CUU.CanUse(Item.Progressive_Bow) && BU.HasBombs())
                    )
                ) && CUU.CanUse(Item.Iron_Boots)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatCarrierKargarok()
        {
            return CUU.CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTwilitBloat()
        {
            return CUU.CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuToad()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsOrBackslice()
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullKid()
        {
            return CUU.CanUse(Item.Progressive_Bow);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinBridge()
        {
            return CUU.CanUse(Item.Progressive_Bow);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinDesert()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal)
                || CUU.GetItemCount(Item.Progressive_Bow) > 2
                || NLU.CanUseBacksliceAsSword()
                || (
                    CanDoDifficultCombat()
                    && (
                        CUU.CanUse(Item.Spinner)
                        || CUU.CanUse(Item.Iron_Boots)
                        || BU.HasBombs()
                        || CUU.GetItemCount(Item.Progressive_Bow) >= 2
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
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal)
                || CUU.GetItemCount(Item.Progressive_Bow) > 2
                || (
                    CanDoDifficultCombat()
                    && (
                        CUU.CanUse(Item.Spinner)
                        || CUU.CanUse(Item.Iron_Boots)
                        || BU.HasBombs()
                        || NLU.CanUseBacksliceAsSword()
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
                HSL.HasSword()
                && (
                    CUU.CanUse(Item.Boomerang)
                    || CUU.CanUse(Item.Progressive_Bow)
                    || CUU.CanUse(Item.Progressive_Clawshot)
                )
                && CUU.CanUse(Item.Shadow_Crystal)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarkhammer()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || NLU.CanUseIronBootsAndDoNiche()
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
                || (CanDoDifficultCombat() && NLU.CanUseBacksliceAsSword())
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPhantomZant()
        {
            return (CUU.CanUse(Item.Shadow_Crystal) || HSL.HasSword());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDiababa()
        {
            return BU.CanLaunchBombs()
                || (
                    CUU.CanUse(Item.Boomerang)
                    && (
                        HSL.HasSword()
                        || CUU.CanUse(Item.Ball_and_Chain)
                        || NLU.CanUseIronBootsAndDoNiche()
                        || CUU.CanUse(Item.Shadow_Crystal)
                        || BU.HasBombs()
                        || (CanDoDifficultCombat() && NLU.CanUseBacksliceAsSword())
                    )
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFyrus()
        {
            return (
                CUU.CanUse(Item.Progressive_Bow)
                && CUU.CanUse(Item.Iron_Boots)
                && (HSL.HasSword() || (CanDoDifficultCombat() && NLU.CanUseBacksliceAsSword()))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMorpheel()
        {
            return (
                (
                    CUU.CanUse(Item.Zora_Armor)
                    && CUU.CanUse(Item.Iron_Boots)
                    && HSL.HasSword()
                    && CUU.CanUse(Item.Progressive_Clawshot)
                )
                || (
                    CanDoNicheStuff()
                    && (CUU.CanUse(Item.Progressive_Clawshot) && CanDoAirRefill() && HSL.HasSword())
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStallord()
        {
            return (
                (CUU.CanUse(Item.Spinner) && HSL.HasSword())
                || (CanDoDifficultCombat() && CUU.CanUse(Item.Spinner))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBlizzeta()
        {
            return CUU.CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmogohma()
        {
            return (CUU.CanUse(Item.Progressive_Bow) && CUU.CanUse(Item.Progressive_Dominion_Rod));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArgorok()
        {
            return (
                CUU.GetItemCount(Item.Progressive_Clawshot) >= 2
                && HSL.HasOrdonSword()
                && (
                    CUU.CanUse(Item.Iron_Boots)
                    || (CanDoNicheStuff() && CUU.CanUse(Item.Magic_Armor))
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZant()
        {
            return (
                HSL.HasMasterSword()
                && (
                    CUU.CanUse(Item.Boomerang)
                    && CUU.CanUse(Item.Progressive_Clawshot)
                    && CUU.CanUse(Item.Ball_and_Chain)
                    && (
                        CUU.CanUse(Item.Iron_Boots)
                        || (CanDoNicheStuff() && CUU.CanUse(Item.Magic_Armor))
                    )
                    && (CUU.CanUse(Item.Zora_Armor) || (IsGlitchedLogic && CanDoAirRefill()))
                )
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGanondorf()
        {
            return CUU.CanUse(Item.Shadow_Crystal) && HSL.HasMasterSword() && HHSL.HasEndingBlow();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canSmash()
        {
            return BU.CanSmash();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBurnWebs()
        {
            return CUU.CanUse(Item.Lantern) || BU.HasBombs() || CUU.CanUse(Item.Ball_and_Chain);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasRangedItem()
        {
            return (
                CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Boomerang)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasShield()
        {
            return (
                CUU.CanUse(Item.Hylian_Shield)
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
            return CUU.CanUse(Item.Lantern) && CUU.CanUse(Item.Coro_Bottle);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canLaunchBombs()
        {
            return BU.CanLaunchBombs();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCutHangingWeb()
        {
            return (
                CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Ball_and_Chain)
            );
        }

        public static int GetPlayerHealth()
        {
            double playerHealth = 3.0; // start at 3 since we have 3 hearts.

            playerHealth = playerHealth + (CUU.GetItemCount(Item.Piece_of_Heart) * 0.2); //Pieces of heart are 1/5 of a heart.
            playerHealth = playerHealth + CUU.GetItemCount(Item.Heart_Container);

            return (int)playerHealth;
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canKnockDownHCPainting()
        {
            return (
                CUU.CanUse(Item.Progressive_Bow)
                || (
                    CanDoNicheStuff() && (BU.HasBombs() || (HSL.HasSword() && HHSL.HasJumpStrike()))
                )
                || (IsGlitchedLogic && ((HSL.HasSword() && CanDoMoonBoots()) || CanDoBSMoonBoots()))
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBreakMonkeyCage()
        {
            return (
                HSL.HasSword()
                || CUU.CanUse(Item.Iron_Boots)
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs()
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || (CanDoNicheStuff() && HLF.CanShieldAttack())
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canPressMinesSwitch()
        {
            return CUU.CanUse(Item.Iron_Boots)
                || (CanDoNicheStuff() && CUU.CanUse(Item.Ball_and_Chain));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canFreeAllMonkeys()
        {
            return (
                canBreakMonkeyCage()
                && (
                    CUU.CanUse(Item.Lantern)
                    || (IsKeysy && (BU.HasBombs() || CUU.CanUse(Item.Iron_Boots)))
                )
                && canBurnWebs()
                && CUU.CanUse(Item.Boomerang)
                && CanDefeatBokoblin()
                && ((CUU.GetItemCount(Item.Forest_Temple_Small_Key) >= 4) || IsKeysy)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canKnockDownHangingBaba()
        {
            return (
                CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Slingshot)
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBreakWoodenDoor()
        {
            return (
                CUU.CanUse(Item.Shadow_Crystal)
                || HSL.HasSword()
                || BU.CanSmash()
                || NLU.CanUseBacksliceAsSword()
            );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasBombs()
        {
            return BU.HasBombs();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUseWaterBombs()
        {
            return BU.CanUseWaterBombs();
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
                || (ERLF.HasReachedRoom("Lake Hylia Long Cave") && BU.CanSmash())
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
            return HSL.CanStrikePedestal();
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
                    (ERLF.HasReachedRoom("North Eldin Field") || CUU.CanUse(Item.Shadow_Crystal))
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
                    && CUU.CanUse(Item.Shadow_Crystal)
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
            return CUU.CanUse(Item.Diababa_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteGoronMines()
        {
            return CUU.CanUse(Item.Fyrus_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteLakebedTemple()
        {
            return CUU.CanUse(Item.Morpheel_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteArbitersGrounds()
        {
            return CUU.CanUse(Item.Stallord_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteSnowpeakRuins()
        {
            return CUU.CanUse(Item.Blizzeta_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteTempleofTime()
        {
            return CUU.CanUse(Item.Armogohma_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompleteCityinTheSky()
        {
            return CUU.CanUse(Item.Argorok_Defeated);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCompletePalaceofTwilight()
        {
            return CUU.CanUse(Item.Zant_Defeated);
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
                if (CUU.CanUse(bug))
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
            return NLU.CanUseBacksliceAsSword();
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
            return HSL.HasWoodenSword() || HHSL.HasBackslice();
        }

        /// <summary>
        /// Check for a usable bottle (requires lantern to avoid issues with lantern oil in all bottles)
        /// </summary>
        public static bool HasBottle()
        {
            return (
                    CUU.CanUse(Item.Empty_Bottle)
                    || CUU.CanUse(Item.Sera_Bottle)
                    || CUU.CanUse(Item.Jovani_Bottle)
                    || CUU.CanUse(Item.Coro_Bottle)
                ) && CUU.CanUse(Item.Lantern);
        }

        public static bool HasBottles()
        {
            int n = 0;
            if (CUU.CanUse(Item.Lantern))
            {
                if (CUU.CanUse(Item.Empty_Bottle))
                {
                    n++;
                }
                if (CUU.CanUse(Item.Sera_Bottle))
                {
                    n++;
                }
                if (CUU.CanUse(Item.Jovani_Bottle))
                {
                    n++;
                }
                if (CUU.CanUse(Item.Coro_Bottle))
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
            return CUU.CanUse(Item.Iron_Boots) || CUU.CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for cutscene item (useful for cutscene dropping a bomb in specific spot)
        /// </summary>
        public static bool HasCutsceneItem()
        {
            return CUU.CanUse(Item.Progressive_Sky_Book)
                || HasBottle()
                || CUU.CanUse(Item.Horse_Call);
        }

        /// <summary>
        /// Check for if you can do LJAs
        /// </summary>
        public static bool CanDoLJA()
        {
            return HSL.HasSword() && CUU.CanUse(Item.Boomerang);
        }

        /// <summary>
        /// Check for if you can do Jump Strike LJAs
        /// </summary>
        public static bool CanDoJSLJA()
        {
            return HSL.HasSword() && CUU.CanUse(Item.Boomerang) && HHSL.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Map Glitch
        /// </summary>
        public static bool CanDoMapGlitch()
        {
            return CUU.CanUse(Item.Shadow_Crystal) && ERLF.HasReachedRoom("Kakariko Gorge");
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
            return HSL.HasSword()
                || HasBottle()
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Lantern)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Progressive_Dominion_Rod);
        }

        /// <summary>
        /// Check for if you can do Moon Boots
        /// </summary>
        public static bool CanDoMoonBoots()
        {
            return HSL.HasSword()
                && (
                    CUU.CanUse(Item.Magic_Armor)
                    || CUU.CanUse(Item.Iron_Boots) && GetItemWheelSlotCount() >= 3
                ); // Ensure you can equip something over boots
        }

        /// <summary>
        /// Check for if you can do Jump Strike Moon Boots
        /// </summary>
        public static bool CanDoJSMoonBoots()
        {
            return CanDoMoonBoots() && HHSL.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Back Slice Moon Boots
        /// </summary>
        public static bool CanDoBSMoonBoots()
        {
            return HHSL.HasBackslice() && CUU.CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for if you can do Ending Blow Moon Boots
        /// </summary>
        public static bool CanDoEBMoonBoots()
        {
            return CanDoMoonBoots() && HHSL.HasEndingBlow() && HSL.HasOrdonSword();
        }

        /// <summary>
        /// Check for if you can do Helm Splitter Moon Boots
        /// </summary>
        public static bool CanDoHSMoonBoots()
        {
            return CanDoMoonBoots() && HHSL.HasHelmSplitter() && HSL.HasSword() && hasShield();
        }

        /// <summary>
        /// Check for if you can do The Amazing Fly Glitch™
        /// </summary>
        public static bool CanDoFlyGlitch()
        {
            return CUU.CanUse(Item.Progressive_Fishing_Rod) && HasHeavyMod();
        }

        /// <summary>
        /// Check for if you can swim with Water Bombs
        /// </summary>
        public static bool CanDoAirRefill()
        {
            return BU.CanUseWaterBombs()
                && (
                    CUU.CanUse(Item.Magic_Armor)
                    || (CUU.CanUse(Item.Iron_Boots) && (GetItemWheelSlotCount() >= 3))
                ); // Ensure you can equip something over boots
        }

        /// <summary>
        /// Check for if you can do Hidden Village (glitched)
        /// </summary>
        public static bool CanDoHiddenVillageGlitched()
        {
            return CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Ball_and_Chain)
                || (
                    CUU.CanUse(Item.Slingshot)
                    && (
                        CUU.CanUse(Item.Shadow_Crystal)
                        || HSL.HasSword()
                        || BU.HasBombs()
                        || CUU.CanUse(Item.Iron_Boots)
                        || CUU.CanUse(Item.Spinner)
                    )
                );
        }

        /// <summary>
        /// Check for if you can get passed FT windless bridge room (glitched)
        /// </summary>
        public static bool CanDoFTWindlessBridgeRoom()
        {
            return BU.HasBombs() || CanDoBSMoonBoots() || CanDoJSMoonBoots();
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
                || HHSL.HasBackslice()
                || CanDoBSMoonBoots()
                || CanDoJSMoonBoots()
                || CanDoLJA()
                || (BU.HasBombs() && (HasHeavyMod() || HHSL.HasJumpStrike()));
        }

        // END OF GLITCHED LOGIC

        // TODO: Does anything else implement this?
        public static int getItemCount(Item itemToBeCounted)
        {
            return CUU.GetItemCount(itemToBeCounted);
        }

        public static int GetItemWheelSlotCount()
        {
            int count = 0;

            foreach (Item item in Randomizer.Items.ItemWheelItems)
            {
                if (CUU.CanUse(item))
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
