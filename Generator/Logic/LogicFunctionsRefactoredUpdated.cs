// Untested; not hooked to anything; scratchpad ish file.

// using LogicFunctionsNS;
using TPRandomizer.SSettings.Enums;
using BOU = LogicFunctionsNS.BottleUtils;
using BU = LogicFunctionsNS.BombUtils;
using CanDefeatBoss = LogicFunctionsNS.AggregateLogic.CanDefeatBoss;
using CCD = LogicFunctionsNS.CanCompleteDungeon;
using CUU = LogicFunctionsNS.CanUseUtilities;
using DCLCE = LogicFunctionsNS.DifficultCombatLogic.CanDefeatCommonEnemy;
using DCLM = LogicFunctionsNS.DifficultCombatLogic.CanDefeatMiniBoss;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using GLCDS = LogicFunctionsNS.GlitchedLogic.CanDoStuff;
using GLCE = LogicFunctionsNS.GlitchedLogic.CanDefeatCommonEnemy;
using GLLCDS = LogicFunctionsNS.GlitchlessLogic.CanDoStuff;
using GLLCE = LogicFunctionsNS.GlitchlessLogic.CanDefeatCommonEnemy;
using GLLM = LogicFunctionsNS.GlitchlessLogic.CanDefeatMiniBoss;
using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using HDI = LogicFunctionsNS.DamagingItems;
using HLF = LogicFunctionsNS.HelperFunctions;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;
using NLCDS = LogicFunctionsNS.NicheLogic.CanDoStuff;
using NLCE = LogicFunctionsNS.NicheLogic.CanDefeatCommonEnemy;
using NLM = LogicFunctionsNS.NicheLogic.CanDefeatMiniBoss;

// TODO: aggregate class

// maybe add a helper for llc - GLL `CanSmash & Lantern` GL `CanSmash`?

// Where is used notes:
// - `LogicTokenizer.cs` > `Function`'s override of `Evaluate`
//    - `typeof(LogicFunctions).GetMethod(FunctionName)` - ???
//       - seems to check if the method even exists, and if it returns a boolean. so any fns that
//         don't return a boolean, but have wrappers, should probably be taken note of.

namespace TPRandomizer
{
    /// <summary>
    /// summary text.
    /// </summary>
    public class LogicFunctionsUpdatedRefactored
    {
        // Evaluate the tokenized settings to their respective values that are set by the settings string.
        #region ToRefactor
        // New functions that have been added since I started that I need to sort out.
        public static bool CanBreakHCBarrier()
        {
            switch (Randomizer.SSettings.castleRequirements)
            {
                case CastleRequirements.Open:
                {
                    return true;
                }
                case CastleRequirements.Fused_Shadows:
                {
                    return CUU.GetItemCount(Item.Progressive_Fused_Shadow)
                        >= Randomizer.SSettings.castleRequirementCount;
                }
                case CastleRequirements.Mirror_Shards:
                {
                    return CUU.GetItemCount(Item.Progressive_Mirror_Shard)
                        >= Randomizer.SSettings.castleRequirementCount;
                }
                case CastleRequirements.Dungeons:
                {
                    int dungeonCount = 0;
                    foreach (Item boss in Randomizer.Items.BossItems)
                    {
                        if (CUU.CanUse(boss))
                        {
                            dungeonCount++;
                        }
                    }
                    return dungeonCount >= Randomizer.SSettings.castleRequirementCount;
                }
                case CastleRequirements.Vanilla:
                {
                    return CCD.CanCompletePalaceofTwilight();
                }
                case CastleRequirements.Poe_Souls:
                {
                    return CUU.GetItemCount(Item.Poe_Soul)
                        >= Randomizer.SSettings.castleRequirementCount;
                }
                case CastleRequirements.Hearts:
                {
                    return HLF.GetPlayerHealth() >= Randomizer.SSettings.castleRequirementCount;
                }
            }

            return false;
        }

        public static bool CanOpenHCBKGate()
        {
            switch (Randomizer.SSettings.castleBKRequirements)
            {
                case CastleBKRequirements.None:
                {
                    return true;
                }
                case CastleBKRequirements.Fused_Shadows:
                {
                    return CUU.GetItemCount(Item.Progressive_Fused_Shadow)
                        >= Randomizer.SSettings.castleBKRequirementCount;
                }
                case CastleBKRequirements.Mirror_Shards:
                {
                    return CUU.GetItemCount(Item.Progressive_Mirror_Shard)
                        >= Randomizer.SSettings.castleBKRequirementCount;
                }
                case CastleBKRequirements.Dungeons:
                {
                    int dungeonCount = 0;
                    foreach (Item boss in Randomizer.Items.BossItems)
                    {
                        if (CUU.CanUse(boss))
                        {
                            dungeonCount++;
                        }
                    }
                    return dungeonCount >= Randomizer.SSettings.castleBKRequirementCount;
                }
                case CastleBKRequirements.Poe_Souls:
                {
                    return CUU.GetItemCount(Item.Poe_Soul)
                        >= Randomizer.SSettings.castleBKRequirementCount;
                }
                case CastleBKRequirements.Hearts:
                {
                    return HLF.GetPlayerHealth() >= Randomizer.SSettings.castleBKRequirementCount;
                }
            }

            return false;
        }
        #endregion

        #region KnownNeeded
        public static bool CanCompleteGoronMines() => CCD.CanCompleteGoronMines();

        public static bool CanCompleteSnowpeakRuins() => CCD.CanCompleteSnowpeakRuins();

        public static bool CanCompleteTempleofTime() => CCD.CanCompleteTempleofTime();

        public static bool HasRangedItem() => MIU.HasRangedItem();

        public static bool HasBombs() => BU.HasBombs();

        public static bool HasSword() => HSL.HasSword();

        public static bool CanSmash() => BU.CanSmash();

        public static bool CanChangeTime() => HLF.CanChangeTime();

        public static bool CanLaunchBombs() => BU.CanLaunchBombs();

        public static bool CanGetHotSpringWater() => BOU.CanGetHotSpringWater();

        public static bool CanBurnWebs() => MIU.CanBurnWebs();

        public static bool CanCutHangingWeb() => MIU.CanCutHangingWeb();

        public static bool HasDamagingItem()
        {
            return HDI.HasBaseDamagingItem(extraItems: Item.Iron_Boots);
        }

        public static bool CanUseWaterBombs() => BU.CanUseWaterBombs();
        #endregion

        // // TODO: If option to not have bug models replaced becomes a thing, this function can be useful
        // public static bool CanGetBugWithLantern() => false;

        #region CanDefeatCommonEnemy
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatAeralfos()
        {
            return CUU.CanUse(Item.Progressive_Clawshot)
                && (GLLCE.CanDefeatAeralfos() || NLCE.CanDefeatAeralfos());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmos()
        {
            return GLLCE.CanDefeatArmos() || NLCE.CanDefeatArmos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent()
        {
            return GLLCE.CanDefeatBabaSerpent() || NLCE.CanDefeatBabaSerpent();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return GLLCE.CanDefeatHangingBabaSerpent() && CanDefeatBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma()
        {
            return GLLCE.CanDefeatBabyGohma() || NLCE.CanDefeatBabyGohma();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBari()
        {
            return GLLCE.CanDefeatBari();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBeamos()
        {
            return GLLCE.CanDefeatBeamos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba()
        {
            return GLLCE.CanDefeatBigBaba() || NLCE.CanDefeatBigBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu()
        {
            return GLLCE.CanDefeatChu() || NLCE.CanDefeatChu();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin()
        {
            return GLLCE.CanDefeatBokoblin() || NLCE.CanDefeatBokoblin();
        }

        public static bool CanDefeatBokoblinRed()
        {
            return GLLCE.CanDefeatBokoblinRed()
                || NLCE.CanDefeatBokoblinRed()
                || DCLCE.CanDefeatBokoblinRed();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombfish()
        {
            return (GLLCE.CanDefeatBombfish() || GLCE.CanDefeatBombfish())
                && (
                    HSL.HasSword()
                    || CUU.CanUse(Item.Progressive_Clawshot)
                    || (MIU.HasShield() && CUU.GetItemCount(Item.Progressive_Hidden_Skill) >= 2)
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling()
        {
            return GLLCE.CanDefeatBombling() || NLCE.CanDefeatBombling();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit()
        {
            return GLLCE.CanDefeatBomskit() || NLCE.CanDefeatBomskit();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBubble()
        {
            return GLLCE.CanDefeatBubble() || NLCE.CanDefeatBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin()
        {
            return GLLCE.CanDefeatBulblin() || NLCE.CanDefeatBulblin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos()
        {
            return GLLCE.CanDefeatChilfos() || NLCE.CanDefeatChilfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChuWorm()
        {
            return (GLLCE.CanDefeatChuWorm() || NLCE.CanDefeatChuWorm())
                && (BU.HasBombs() || CUU.CanUse(Item.Progressive_Clawshot));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarknut()
        {
            return GLLCE.CanDefeatDarknut() || DCLCE.CanDefeatDarknut();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuBaba()
        {
            return GLLCE.CanDefeatDekuBaba() || NLCE.CanDefeatDekuBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuLike()
        {
            return GLLCE.CanDefeatDekuLike();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDodongo()
        {
            return GLLCE.CanDefeatDodongo() || NLCE.CanDefeatDodongo();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDinalfos()
        {
            return GLLCE.CanDefeatDinalfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireBubble()
        {
            return GLLCE.CanDefeatFireBubble() || NLCE.CanDefeatFireBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireKeese()
        {
            return GLLCE.CanDefeatFireKeese() || NLCE.CanDefeatFireKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireToadpoli()
        {
            return GLLCE.CanDefeatFireToadpoli() || DCLCE.CanDefeatFireToadpoli();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFreezard()
        {
            return GLLCE.CanDefeatFreezard();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGoron()
        {
            return GLLCE.CanDefeatGoron() || NLCE.CanDefeatGoron() || DCLCE.CanDefeatGoron();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGhoulRat()
        {
            return GLLCE.CanDefeatGhoulRat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGuay()
        {
            return GLLCE.CanDefeatGuay() || NLCE.CanDefeatGuay() || DCLCE.CanDefeatGuay();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur()
        {
            return GLLCE.CanDefeatHelmasaur() || NLCE.CanDefeatHelmasaur();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus()
        {
            return GLLCE.CanDefeatHelmasaurus() || NLCE.CanDefeatHelmasaurus();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceBubble()
        {
            return GLLCE.CanDefeatIceBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceKeese()
        {
            return GLLCE.CanDefeatIceKeese() || NLCE.CanDefeatIceKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoe()
        {
            return GLLCE.CanDefeatPoe();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKargarok()
        {
            return GLLCE.CanDefeatKargarok() || NLCE.CanDefeatKargarok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKeese()
        {
            return GLLCE.CanDefeatKeese() || NLCE.CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever()
        {
            return GLLCE.CanDefeatLeever() || NLCE.CanDefeatLeever();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos()
        {
            return GLLCE.CanDefeatLizalfos() || NLCE.CanDefeatLizalfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard()
        {
            return GLLCE.CanDefeatMiniFreezard() || NLCE.CanDefeatMiniFreezard();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm()
        {
            return GLLCE.CanDefeatMoldorm() || NLCE.CanDefeatMoldorm();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite()
        {
            return GLLCE.CanDefeatPoisonMite();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet()
        {
            return GLLCE.CanDefeatPuppet() || NLCE.CanDefeatPuppet();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat()
        {
            return GLLCE.CanDefeatRat() || NLCE.CanDefeatRat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight()
        {
            return GLLCE.CanDefeatRedeadKnight() || NLCE.CanDefeatRedeadKnight();
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
            return GLLCE.CanDefeatShadowBulblin() || NLCE.CanDefeatShadowBulblin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return GLLCE.CanDefeatShadowDekuBaba() || NLCE.CanDefeatShadowDekuBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowInsect()
        {
            return GLLCE.CanDefeatShadowInsect();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKargarok()
        {
            return GLLCE.CanDefeatShadowKargarok() || NLCE.CanDefeatShadowKargarok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese()
        {
            return GLLCE.CanDefeatShadowKeese() || NLCE.CanDefeatShadowKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin()
        {
            return GLLCE.CanDefeatShadowVermin() || NLCE.CanDefeatShadowVermin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShellBlade()
        {
            return BU.CanUseWaterBombs()
                || (HSL.HasSword() && (GLLCE.CanDefeatShellBlade() || NLCE.CanDefeatShellBlade()));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullfish()
        {
            return GLLCE.CanDefeatSkullfish() || NLCE.CanDefeatSkullfish();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula()
        {
            return GLLCE.CanDefeatSkulltula() || NLCE.CanDefeatSkulltula();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalfos()
        {
            return GLLCE.CanDefeatStalfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalhound()
        {
            return GLLCE.CanDefeatStalhound() || NLCE.CanDefeatStalhound();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild()
        {
            return GLLCE.CanDefeatStalchild() || NLCE.CanDefeatStalchild();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite()
        {
            return GLLCE.CanDefeatTektite() || NLCE.CanDefeatTektite();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm()
        {
            return CUU.CanUse(Item.Boomerang)
                && (GLLCE.CanDefeatTileWorm() || NLCE.CanDefeatTileWorm());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado()
        {
            return GLLCE.CanDefeatToado();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWaterToadpoli()
        {
            return GLLCE.CanDefeatWaterToadpoli() || DCLCE.CanDefeatWaterToadpoli();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug()
        {
            return GLLCE.CanDefeatTorchSlug();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWalltula()
        {
            return GLLCE.CanDefeatWalltula();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos()
        {
            return GLLCE.CanDefeatWhiteWolfos() || NLCE.CanDefeatWhiteWolfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma()
        {
            return GLLCE.CanDefeatYoungGohma() || NLCE.CanDefeatYoungGohma();
        }
        #endregion

        #region CanDefeatMiniboss
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZantHead()
        {
            return GLLM.CanDefeatZantHead() || NLM.CanDefeatZantHead();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatOok()
        {
            return GLLM.CanDefeatOok() || NLM.CanDefeatOok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDangoro()
        {
            return CUU.CanUse(Item.Iron_Boots)
                && (GLLM.CanDefeatDangoro() || NLM.CanDefeatDangoro());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatCarrierKargarok() => GLLM.CanDefeatCarrierKargarok();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTwilitBloat() => GLLM.CanDefeatTwilitBloat();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuToad()
        {
            return GLLM.CanDefeatDekuToad() || NLM.CanDefeatDekuToad();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullKid() => GLLM.CanDefeatSkullKid();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinBridge() => GLLM.CanDefeatKingBulblinBridge();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinDesert()
        {
            return GLLM.CanDefeatKingBulblinBridge()
                || NLM.CanDefeatKingBulblinDesert()
                || DCLM.CanDefeatKingBulblinDesert();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinCastle()
        {
            return GLLM.CanDefeatKingBulblinCastle() || DCLM.CanDefeatKingBulblinCastle();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDeathSword() => GLLM.CanDefeatDeathSword();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarkhammer()
        {
            return GLLM.CanDefeatDarkhammer()
                || NLM.CanDefeatDarkhammer()
                || DCLM.CanDefeatDarkhammer();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPhantomZant() => GLLM.CanDefeatPhantomZant();
        #endregion

        #region CanDefeatBoss
        public static bool CanDefeatDiababa() => CanDefeatBoss.CanDefeatDiababa();

        public static bool CanDefeatFyrus() => CanDefeatBoss.CanDefeatFyrus();

        public static bool CanDefeatMorpheel() => CanDefeatBoss.CanDefeatMorpheel();

        public static bool CanDefeatStallord() => CanDefeatBoss.CanDefeatStallord();

        public static bool CanDefeatBlizzeta() => CanDefeatBoss.CanDefeatBlizzeta();

        public static bool CanDefeatArmogohma() => CanDefeatBoss.CanDefeatArmogohma();

        public static bool CanDefeatArgorok() => CanDefeatBoss.CanDefeatArgorok();

        public static bool CanDefeatZant() => CanDefeatBoss.CanDefeatZant();

        public static bool CanDefeatGanondorf() => CanDefeatBoss.CanDefeatGanondorf();
        #endregion

        #region CanDoStuff
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanKnockDownHCPainting()
        {
            return GLLCDS.CanKnockDownHCPainting()
                || NLCDS.CanKnockDownHCPainting()
                || GLCDS.CanKnockDownHCPainting();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanBreakMonkeyCage()
        {
            return GLLCDS.CanBreakMonkeyCage() || NLCDS.CanBreakMonkeyCage();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanPressMinesSwitch()
        {
            return GLLCDS.CanPressMinesSwitch() || NLCDS.CanPressMinesSwitch();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanFreeAllMonkeys()
        {
            return CanBreakMonkeyCage() && CanDefeatBokoblin() && GLLCDS.CanFreeAllMonkeys();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanKnockDownHangingBaba() => GLLCDS.CanKnockDownHangingBaba();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanBreakWoodenDoor()
        {
            return GLLCDS.CanBreakWoodenDoor() || NLCDS.CanBreakWoodenDoor();
        }

        public static bool CanMidnaCharge()
        {
            return CanCompleteMDH() && CanCompleteAllTwilight();
        }

        public static bool CanStrikePedestal()
        {
            return CUU.GetItemCount(Item.Progressive_Sword)
                >= (int)Randomizer.SSettings.totEntrance;
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
        #endregion

        #region CanDoStoryStuff
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanCompletePrologue()
        {
            return (Randomizer.SSettings.skipPrologue == true)
                || (ERLF.HasReachedNFaronWoods() && CanDefeatBokoblin());
        }

        public static bool CanCompleteGoats1()
        {
            return CanCompletePrologue() || ERLF.HasReachedRoom("Ordon Ranch");
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanCompleteMDH()
        {
            return (Randomizer.SSettings.skipMdh == true)
                || (CCD.CanCompleteLakebedTemple() && ERLF.HasReachedSCastleTown());
            //return (CanCompleteLakebedTemple() || (Randomizer.SSettings.skipMdh == true));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanClearForest()
        {
            return (
                    CCD.CanCompleteForestTemple()
                    || (Randomizer.SSettings.faronWoodsLogic == FaronWoodsLogic.Open)
                )
                && CanCompletePrologue()
                && CanCompleteFaronTwilight();
        }
        #endregion

        // Twilights, Dungeons, and Maps should probably be their own files in a RF dir

        #region Twilights
        /// <summary>
        /// Can complete Faron twilight
        /// </summary>
        public static bool CanCompleteFaronTwilight()
        {
            return Randomizer.SSettings.faronTwilightCleared
                || (
                    CanCompletePrologue()
                    && HLF.CanCompleteTwilight(RoomFunctions.faronTwilightRooms)
                );
        }

        /// <summary>
        /// Can complete Eldin twilight
        /// </summary>
        public static bool CanCompleteEldinTwilight()
        {
            return Randomizer.SSettings.eldinTwilightCleared
                || HLF.CanCompleteTwilight(RoomFunctions.eldinTwilightRooms);
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return Randomizer.SSettings.lanayruTwilightCleared
                || (
                    (ERLF.HasReachedRoom("North Eldin Field") || CUU.CanUse(Item.Shadow_Crystal))
                    && HLF.CanCompleteTwilight(RoomFunctions.lanayruTwilightRooms)
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
        #endregion

        // START OF GLITCHED LOGIC
        #region GlitchedUtils
        public static bool HasSwordOrBS() => GLU.HasSwordOrBS();

        public static bool HasHeavyMod() => GLU.HasHeavyMod();

        public static bool HasCutsceneItem() => GLU.HasCutsceneItem();

        public static bool CanDoLJA() => GLU.CanDoLJA();

        public static bool CanDoJSLJA() => GLU.CanDoJSLJA();

        public static bool CanDoMapGlitch() => GLU.CanDoMapGlitch();

        public static bool CanDoStorage() => GLU.CanDoStorage();

        public static bool HasOneHandedItem() => GLU.HasOneHandedItem();

        public static bool CanDoMoonBoots() => GLU.CanDoMoonBoots();

        public static bool CanDoJSMoonBoots() => GLU.CanDoJSMoonBoots();

        public static bool CanDoBSMoonBoots() => GLU.CanDoBSMoonBoots();

        public static bool CanDoEBMoonBoots() => GLU.CanDoEBMoonBoots();

        public static bool CanDoHSMoonBoots() => GLU.CanDoHSMoonBoots();

        public static bool CanDoFlyGlitch() => GLU.CanDoFlyGlitch();

        public static bool CanDoAirRefill() => GLU.CanDoAirRefill();
        #endregion

        #region GlitchedCanDoStuff
        /// <summary>
        /// Check for if you Can do Hidden Village (glitched)
        /// </summary>
        public static bool CanDoHiddenVillageGlitched() => GLCDS.CanDoHiddenVillageGlitched();

        /// <summary>
        /// Check for if you Can get passed FT windless bridge room (glitched)
        /// </summary>
        public static bool CanDoFTWindlessBridgeRoom() => GLCDS.CanDoFTWindlessBridgeRoom();

        // TODO: Combine this into the overall CanClearForest.
        // This requires the changes noted about TDM.
        public static bool CanClearForestGlitched()
        {
            return CanCompletePrologue()
                && (CCD.CanCompleteForestTemple() || GLCDS.CanClearForestGlitched());
        }

        /// <summary>
        /// Check for if Eldin twilight Can be completed (glitched). Check this for if map warp Can be obtained
        /// </summary>
        // TODO: This Can probably be removed once CanClearForest is simplified.
        public static bool CanCompleteEldinTwilightGlitched()
        {
            return Randomizer.SSettings.eldinTwilightCleared || CanClearForestGlitched();
        }

        /// <summary>
        /// Check for if you need the key for getting to Lakebed Deku Toad
        ///
        public static bool CanSkipKeyToDekuToad() => GLCDS.CanSkipKeyToDekuToad();
        #endregion
        // END OF GLITCHED LOGIC
    }
}
