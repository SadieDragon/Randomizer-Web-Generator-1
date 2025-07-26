// Untested; not hooked to anything; scratchpad ish file.

// using LogicFunctionsNS;
using System;
using System.Linq;
using LogicFunctionsNS;
using LogicFunctionsNS.AggregateLogic;
using TPRandomizer.SSettings.Enums;
using BOU = LogicFunctionsNS.BottleUtils;
using BU = LogicFunctionsNS.BombUtils;
using CCD = LogicFunctionsNS.CanCompleteDungeon;
using CUU = LogicFunctionsNS.CanUseUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using HLF = LogicFunctionsNS.HelperFunctions;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;

// maybe add a helper for llc - GLL `CanSmash & Lantern` GL `CanSmash`?

namespace TPRandomizer
{
    /// <summary>
    /// summary text.
    /// </summary>
    public class LogicFunctionsUpdatedRefactored
    {
        private static readonly SharedSettings sharedSettings = SettingUtils.sharedSettings;

        // Evaluate the tokenized settings to their respective values that are set by the settings string.
        #region ToRefactor
        // New functions that have been added since I started that I need to sort out.
        public static bool CanBreakHCBarrier()
        {
            int requirementCount = sharedSettings.castleRequirementCount;

            switch (sharedSettings.castleRequirements)
            {
                case CastleRequirements.Open:
                {
                    return true;
                }
                case CastleRequirements.Fused_Shadows:
                {
                    return CUU.VerifyItemQuantity(Item.Progressive_Fused_Shadow, requirementCount);
                }
                case CastleRequirements.Mirror_Shards:
                {
                    return CUU.VerifyItemQuantity(Item.Progressive_Mirror_Shard, requirementCount);
                }
                case CastleRequirements.Dungeons:
                {
                    return Randomizer.Items.BossItems.Count(CUU.CanUse) >= requirementCount;
                }
                case CastleRequirements.Vanilla:
                {
                    return CCD.CanCompletePalaceofTwilight();
                }
                case CastleRequirements.Poe_Souls:
                {
                    return CUU.VerifyItemQuantity(Item.Poe_Soul, requirementCount);
                }
                case CastleRequirements.Hearts:
                {
                    return HLF.GetPlayerHealth() >= requirementCount;
                }
            }

            return false;
        }

        public static bool CanOpenHCBKGate()
        {
            int requirementCount = sharedSettings.castleBKRequirementCount;

            switch (sharedSettings.castleBKRequirements)
            {
                case CastleBKRequirements.None:
                {
                    return true;
                }
                case CastleBKRequirements.Fused_Shadows:
                {
                    return CUU.VerifyItemQuantity(Item.Progressive_Fused_Shadow, requirementCount);
                }
                case CastleBKRequirements.Mirror_Shards:
                {
                    return CUU.VerifyItemQuantity(Item.Progressive_Mirror_Shard, requirementCount);
                }
                case CastleBKRequirements.Dungeons:
                {
                    return Randomizer.Items.BossItems.Count(CUU.CanUse) >= requirementCount;
                }
                case CastleBKRequirements.Poe_Souls:
                {
                    return CUU.VerifyItemQuantity(Item.Poe_Soul, requirementCount);
                }
                case CastleBKRequirements.Hearts:
                {
                    return HLF.GetPlayerHealth() >= requirementCount;
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

        public static bool CanChangeTime() => CanDoStuff.CanChangeTime();

        public static bool CanLaunchBombs() => BU.CanLaunchBombs();

        public static bool CanGetHotSpringWater() => BOU.CanGetHotSpringWater();

        public static bool CanBurnWebs() => MIU.CanBurnWebs();

        public static bool CanCutHangingWeb() => MIU.CanCutHangingWeb();

        public static bool HasDamagingItem()
        {
            // Iron boots is often treated as a niche item, and is never used in the logic fns,
            // but to return it to how it's originally coded. - Lupa
            return HasDamagingItemUtils.HasDamagingItem() || CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanUseWaterBombs() => BU.CanUseWaterBombs();
        #endregion

        // TODO: If option to not have bug models replaced becomes a thing, this function can be useful
        // public static bool CanGetBugWithLantern() => false;

        #region CanDefeatCommonEnemy
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatAeralfos() => CanDefeatCommonEnemy.CanDefeatAeralfos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmos() => CanDefeatCommonEnemy.CanDefeatArmos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent() => CanDefeatCommonEnemy.CanDefeatBabaSerpent();

        public static bool CanDefeatHangingBabaSerpent()
        {
            return CanDefeatCommonEnemy.CanDefeatHangingBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma() => CanDefeatCommonEnemy.CanDefeatBabyGohma();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBari() => CanDefeatCommonEnemy.CanDefeatBari();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBeamos() => CanDefeatCommonEnemy.CanDefeatBeamos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba() => CanDefeatCommonEnemy.CanDefeatBigBaba();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu() => CanDefeatCommonEnemy.CanDefeatChu();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin() => CanDefeatCommonEnemy.CanDefeatBokoblin();

        public static bool CanDefeatBokoblinRed() => CanDefeatCommonEnemy.CanDefeatBokoblinRed();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombfish() => CanDefeatCommonEnemy.CanDefeatBombfish();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling() => CanDefeatCommonEnemy.CanDefeatBombling();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit() => CanDefeatCommonEnemy.CanDefeatBomskit();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBubble() => CanDefeatCommonEnemy.CanDefeatBubble();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin() => CanDefeatCommonEnemy.CanDefeatBulblin();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos() => CanDefeatCommonEnemy.CanDefeatChilfos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChuWorm() => CanDefeatCommonEnemy.CanDefeatChuWorm();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarknut() => CanDefeatCommonEnemy.CanDefeatDarknut();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuBaba() => CanDefeatCommonEnemy.CanDefeatDekuBaba();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuLike() => CanDefeatCommonEnemy.CanDefeatDekuLike();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDodongo() => CanDefeatCommonEnemy.CanDefeatDodongo();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDinalfos() => CanDefeatCommonEnemy.CanDefeatDinalfos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireBubble() => CanDefeatCommonEnemy.CanDefeatFireBubble();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireKeese() => CanDefeatCommonEnemy.CanDefeatFireKeese();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireToadpoli() => CanDefeatCommonEnemy.CanDefeatFireToadpoli();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFreezard() => CanDefeatCommonEnemy.CanDefeatFreezard();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGoron() => CanDefeatCommonEnemy.CanDefeatGoron();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGhoulRat() => CanDefeatCommonEnemy.CanDefeatGhoulRat();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGuay() => CanDefeatCommonEnemy.CanDefeatGuay();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur() => CanDefeatCommonEnemy.CanDefeatHelmasaur();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus() => CanDefeatCommonEnemy.CanDefeatHelmasaurus();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceBubble() => CanDefeatCommonEnemy.CanDefeatIceBubble();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceKeese() => CanDefeatCommonEnemy.CanDefeatIceKeese();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoe() => CanDefeatCommonEnemy.CanDefeatPoe();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKargarok() => CanDefeatCommonEnemy.CanDefeatKargarok();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKeese() => CanDefeatCommonEnemy.CanDefeatKeese();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever() => CanDefeatCommonEnemy.CanDefeatLeever();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos() => CanDefeatCommonEnemy.CanDefeatLizalfos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard() => CanDefeatCommonEnemy.CanDefeatMiniFreezard();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm() => CanDefeatCommonEnemy.CanDefeatMoldorm();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite() => CanDefeatCommonEnemy.CanDefeatPoisonMite();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet() => CanDefeatCommonEnemy.CanDefeatPuppet();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat() => CanDefeatCommonEnemy.CanDefeatRat();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight() => CanDefeatCommonEnemy.CanDefeatRedeadKnight();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBeast() => CanDefeatCommonEnemy.CanDefeatShadowBeast();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBulblin()
        {
            return CanDefeatCommonEnemy.CanDefeatShadowBulblin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return CanDefeatCommonEnemy.CanDefeatShadowDekuBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowInsect() => CanDefeatCommonEnemy.CanDefeatShadowInsect();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKargarok()
        {
            return CanDefeatCommonEnemy.CanDefeatShadowKargarok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese() => CanDefeatCommonEnemy.CanDefeatShadowKeese();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin() => CanDefeatCommonEnemy.CanDefeatShadowVermin();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShellBlade() => CanDefeatCommonEnemy.CanDefeatShellBlade();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullfish() => CanDefeatCommonEnemy.CanDefeatSkullfish();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula() => CanDefeatCommonEnemy.CanDefeatSkulltula();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalfos() => CanDefeatCommonEnemy.CanDefeatStalfos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalhound() => CanDefeatCommonEnemy.CanDefeatStalhound();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild() => CanDefeatCommonEnemy.CanDefeatStalchild();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite() => CanDefeatCommonEnemy.CanDefeatTektite();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm() => CanDefeatCommonEnemy.CanDefeatTileWorm();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado() => CanDefeatCommonEnemy.CanDefeatToado();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWaterToadpoli()
        {
            return CanDefeatCommonEnemy.CanDefeatWaterToadpoli();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug() => CanDefeatCommonEnemy.CanDefeatTorchSlug();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWalltula() => CanDefeatCommonEnemy.CanDefeatWalltula();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos() => CanDefeatCommonEnemy.CanDefeatWhiteWolfos();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma() => CanDefeatCommonEnemy.CanDefeatYoungGohma();
        #endregion

        #region CanDefeatMiniBoss
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZantHead() => CanDefeatMiniBoss.CanDefeatZantHead();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatOok() => CanDefeatMiniBoss.CanDefeatOok();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDangoro() => CanDefeatMiniBoss.CanDefeatDangoro();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatCarrierKargarok()
        {
            return CanDefeatMiniBoss.CanDefeatCarrierKargarok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTwilitBloat() => CanDefeatMiniBoss.CanDefeatTwilitBloat();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuToad() => CanDefeatMiniBoss.CanDefeatDekuToad();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullKid() => CanDefeatMiniBoss.CanDefeatSkullKid();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinBridge()
        {
            return CanDefeatMiniBoss.CanDefeatKingBulblinBridge();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinDesert()
        {
            return CanDefeatMiniBoss.CanDefeatKingBulblinDesert();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKingBulblinCastle()
        {
            return CanDefeatMiniBoss.CanDefeatKingBulblinCastle();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDeathSword() => CanDefeatMiniBoss.CanDefeatDeathSword();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarkhammer() => CanDefeatMiniBoss.CanDefeatDarkhammer();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPhantomZant() => CanDefeatMiniBoss.CanDefeatPhantomZant();
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
        public static bool CanKnockDownHCPainting() => CanDoStuff.CanKnockDownHCPainting();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanBreakMonkeyCage() => CanDoStuff.CanBreakMonkeyCage();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanPressMinesSwitch() => CanDoStuff.CanPressMinesSwitch();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanFreeAllMonkeys() => CanDoStuff.CanFreeAllMonkeys();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanKnockDownHangingBaba() => CanDoStuff.CanKnockDownHangingBaba();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanBreakWoodenDoor() => CanDoStuff.CanBreakWoodenDoor();

        public static bool CanMidnaCharge()
        {
            return CanCompleteMDH() && CanCompleteAllTwilight();
        }

        public static bool CanStrikePedestal() => SettingUtils.CanStrikePedestal();

        public static bool CanWarpMeteor()
        {
            return CanCompleteLanayruTwilight()
                || (
                    CanCompleteEldinTwilight()
                    && ERLF.HasReachedRoom("Zoras Domain Throne Room")
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
            return SettingUtils.HasSkippedPrologue()
                || (ERLF.HasReachedRoom("North Faron Woods") && CanDefeatBokoblin());
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
            return SettingUtils.HasSkippedMDH()
                || (CCD.CanCompleteLakebedTemple() && ERLF.HasReachedRoom("Castle Town South"));
            //return (CanCompleteLakebedTemple() || (Randomizer.SSettings.skipMdh == true));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanClearForest()
        {
            return (CCD.CanCompleteForestTemple() || SettingUtils.IsOpenWoods())
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
            return SettingUtils.HasSkippedFaronTwilight()
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
            return SettingUtils.HasSkippedEldinTwilight()
                || HLF.CanCompleteTwilight(RoomFunctions.eldinTwilightRooms);
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return SettingUtils.HasSkippedLanayruTwilight()
                || (
                    (ERLF.HasReachedRoom("North Eldin Field") || CUU.CanUse(Item.Shadow_Crystal))
                    && HLF.CanCompleteTwilight(RoomFunctions.lanayruTwilightRooms)
                );
        }

        public static bool CanCompleteAllTwilight()
        {
            return CanCompleteFaronTwilight()
                && CanCompleteEldinTwilight()
                && CanCompleteLanayruTwilight();
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
        /// Check for if you Can get passed FT windless bridge room (glitched)
        /// </summary>
        public static bool CanDoFTWindlessBridgeRoom()
        {
            return BU.HasBombs() || GLU.CanDoBSMoonBoots() || GLU.CanDoJSMoonBoots();
        }

        // TODO: Combine this into the overall CanClearForest.
        // This requires the changes noted about TDM.
        public static bool CanClearForestGlitched()
        {
            return CanCompletePrologue()
                && (
                    SettingUtils.IsOpenWoods()
                    || CCD.CanCompleteForestTemple()
                    || GLU.CanDoLJA()
                    || GLU.CanDoMapGlitch()
                );
        }

        /// <summary>
        /// Check for if Eldin twilight Can be completed (glitched). Check this for if map warp Can be obtained
        /// </summary>
        // TODO: This Can probably be removed once CanClearForest is simplified.
        public static bool CanCompleteEldinTwilightGlitched()
        {
            return SettingUtils.HasSkippedEldinTwilight() || CanClearForestGlitched();
        }

        /// <summary>
        /// Check for if you need the key for getting to Lakebed Deku Toad
        ///
        public static bool CanSkipKeyToDekuToad()
        {
            return SettingUtils.IsKeysy()
                || HasHiddenSkillLevel.HasBackslice()
                || CanDoBSMoonBoots()
                || CanDoJSMoonBoots()
                || CanDoLJA()
                || (HasBombs() && (HasHeavyMod() || HasHiddenSkillLevel.HasBackslice()));
        }
        #endregion
        // END OF GLITCHED LOGIC
    }
}
