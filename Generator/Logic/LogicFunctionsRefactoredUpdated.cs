// Untested; not hooked to anything; scratchpad ish file.

// using LogicFunctionsNS;
using System;
using System.Linq;
using LogicFunctionsNS;
using TPRandomizer.SSettings.Enums;

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
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Fused_Shadow,
                        requirementCount
                    );
                }
                case CastleRequirements.Mirror_Shards:
                {
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Mirror_Shard,
                        requirementCount
                    );
                }
                case CastleRequirements.Dungeons:
                {
                    return Randomizer.Items.BossItems.Count(CanUseUtils.CanUse) >= requirementCount;
                }
                case CastleRequirements.Vanilla:
                {
                    return CanCompleteDungeon.CanCompletePalaceofTwilight();
                }
                case CastleRequirements.Poe_Souls:
                {
                    return CanUseUtils.VerifyItemQuantity(Item.Poe_Soul, requirementCount);
                }
                case CastleRequirements.Hearts:
                {
                    return HelperFunctions.GetPlayerHealth() >= requirementCount;
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
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Fused_Shadow,
                        requirementCount
                    );
                }
                case CastleBKRequirements.Mirror_Shards:
                {
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Mirror_Shard,
                        requirementCount
                    );
                }
                case CastleBKRequirements.Dungeons:
                {
                    return Randomizer.Items.BossItems.Count(CanUseUtils.CanUse) >= requirementCount;
                }
                case CastleBKRequirements.Poe_Souls:
                {
                    return CanUseUtils.VerifyItemQuantity(Item.Poe_Soul, requirementCount);
                }
                case CastleBKRequirements.Hearts:
                {
                    return HelperFunctions.GetPlayerHealth() >= requirementCount;
                }
            }

            return false;
        }
        #endregion

        #region KnownNeeded
        public static bool CanCompleteGoronMines() => CanCompleteDungeon.CanCompleteGoronMines();

        public static bool CanCompleteSnowpeakRuins() =>
            CanCompleteDungeon.CanCompleteSnowpeakRuins();

        public static bool CanCompleteTempleofTime() =>
            CanCompleteDungeon.CanCompleteTempleofTime();

        public static bool HasRangedItem() => MiscItemUtils.HasRangedItem();

        public static bool HasBombs() => BombUtils.HasBombs();

        public static bool HasSword() => HasSwordLevel.HasSword();

        public static bool CanSmash() => BombUtils.CanSmash();

        public static bool CanChangeTime() => CanDoStuff.CanChangeTime();

        public static bool CanLaunchBombs() => BombUtils.CanLaunchBombs();

        public static bool CanGetHotSpringWater() => BottleUtils.CanGetHotSpringWater();

        public static bool CanBurnWebs() => MiscItemUtils.CanBurnWebs();

        public static bool CanCutHangingWeb() => MiscItemUtils.CanCutHangingWeb();

        public static bool HasDamagingItem()
        {
            // Iron boots is often treated as a niche item, and is never used in the logic fns,
            // but to return it to how it's originally coded. - Lupa
            return HasDamagingItemUtils.HasDamagingItem() || CanUseUtils.CanUse(Item.Iron_Boots);
        }

        public static bool CanUseWaterBombs() => BombUtils.CanUseWaterBombs();
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

        public static bool CanMidnaCharge() => CanDoStuff.CanMidnaCharge();

        public static bool CanStrikePedestal() => SettingUtils.CanStrikePedestal();

        // TODO: Goes with story stuff, as it is a 1-time use to change ZD from ice to not
        public static bool CanWarpMeteor()
        {
            return CanCompleteLanayruTwilight()
                || (
                    CanCompleteEldinTwilight()
                    && ERLogicFunctions.HasReachedRoom("Zoras Domain Throne Room")
                    && CanUseUtils.CanUse(Item.Shadow_Crystal)
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
                || (ERLogicFunctions.HasReachedRoom("North Faron Woods") && CanDefeatBokoblin());
        }

        public static bool CanCompleteGoats1()
        {
            return CanCompletePrologue() || ERLogicFunctions.HasReachedRoom("Ordon Ranch");
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanCompleteMDH()
        {
            return SettingUtils.HasSkippedMDH()
                || (
                    CanCompleteDungeon.CanCompleteLakebedTemple()
                    && ERLogicFunctions.HasReachedRoom("Castle Town South")
                );
            //return (CanCompleteLakebedTemple() || (Randomizer.SSettings.skipMdh == true));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanClearForest()
        {
            return (CanCompleteDungeon.CanCompleteForestTemple() || SettingUtils.IsOpenWoods())
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
                    && HelperFunctions.CanCompleteTwilight(RoomFunctions.faronTwilightRooms)
                );
        }

        /// <summary>
        /// Can complete Eldin twilight
        /// </summary>
        public static bool CanCompleteEldinTwilight()
        {
            return SettingUtils.HasSkippedEldinTwilight()
                || HelperFunctions.CanCompleteTwilight(RoomFunctions.eldinTwilightRooms);
        }

        public static bool CanCompleteLanayruTwilight()
        {
            return SettingUtils.HasSkippedLanayruTwilight()
                || (
                    HelperFunctions.CanCompleteTwilight(RoomFunctions.lanayruTwilightRooms)
                    && (
                        ERLogicFunctions.HasReachedRoom("North Eldin Field")
                        || CanUseUtils.CanUse(Item.Shadow_Crystal)
                    )
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
        public static bool HasSwordOrBS() => GlitchedLogicUtils.HasSwordOrBS();

        public static bool HasHeavyMod() => GlitchedLogicUtils.HasHeavyMod();

        public static bool HasCutsceneItem() => GlitchedLogicUtils.HasCutsceneItem();

        public static bool CanDoLJA() => GlitchedLogicUtils.CanDoLJA();

        public static bool CanDoJSLJA() => GlitchedLogicUtils.CanDoJSLJA();

        public static bool CanDoMapGlitch() => GlitchedLogicUtils.CanDoMapGlitch();

        public static bool CanDoStorage() => GlitchedLogicUtils.CanDoStorage();

        public static bool HasOneHandedItem() => GlitchedLogicUtils.HasOneHandedItem();

        public static bool CanDoMoonBoots() => GlitchedLogicUtils.CanDoMoonBoots();

        public static bool CanDoJSMoonBoots() => GlitchedLogicUtils.CanDoJSMoonBoots();

        public static bool CanDoBSMoonBoots() => GlitchedLogicUtils.CanDoBSMoonBoots();

        public static bool CanDoEBMoonBoots() => GlitchedLogicUtils.CanDoEBMoonBoots();

        public static bool CanDoHSMoonBoots() => GlitchedLogicUtils.CanDoHSMoonBoots();

        public static bool CanDoFlyGlitch() => GlitchedLogicUtils.CanDoFlyGlitch();

        public static bool CanDoAirRefill() => GlitchedLogicUtils.CanDoAirRefill();
        #endregion

        #region GlitchedCanDoStuff
        /// <summary>
        /// Check for if you Can do Hidden Village (glitched)
        /// </summary>
        public static bool CanDoHiddenVillageGlitched()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || (
                    CanUseUtils.CanUse(Item.Slingshot)
                    && (
                        CanUseUtils.CanUse(Item.Shadow_Crystal)
                        || HasSwordLevel.HasSword()
                        || BombUtils.HasBombs()
                        || CanUseUtils.CanUse(Item.Iron_Boots)
                        || CanUseUtils.CanUse(Item.Spinner)
                    )
                );
        }

        /// <summary>
        /// Check for if you Can get passed FT windless bridge room (glitched)
        /// </summary>
        public static bool CanDoFTWindlessBridgeRoom()
        {
            return BombUtils.HasBombs()
                || GlitchedLogicUtils.CanDoBSMoonBoots()
                || GlitchedLogicUtils.CanDoJSMoonBoots();
        }

        // TODO: Combine this into the overall CanClearForest.
        // This requires the changes noted about TDM.
        public static bool CanClearForestGlitched()
        {
            return CanCompletePrologue()
                && (
                    SettingUtils.IsOpenWoods()
                    || CanCompleteDungeon.CanCompleteForestTemple()
                    || GlitchedLogicUtils.CanDoLJA()
                    || GlitchedLogicUtils.CanDoMapGlitch()
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
