using System;
using TPRandomizer.SSettings.Enums;
using BOU = LogicFunctionsNS.BottleUtils;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using DCLCE = LogicFunctionsNS.DifficultCombatLogic.CanDefeatCommonEnemy;
using DCLM = LogicFunctionsNS.DifficultCombatLogic.CanDefeatMiniBoss;
using DCLU = LogicFunctionsNS.DifficultCombatLogicUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using GLCE = LogicFunctionsNS.GlitchedLogic.CanDefeatCommonEnemy;
using GLLCE = LogicFunctionsNS.GlitchlessLogic.CanDefeatCommonEnemy;
using GLLM = LogicFunctionsNS.GlitchlessLogic.CanDefeatMiniBoss;
using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using HDI = LogicFunctionsNS.DamagingItems;
using HLF = LogicFunctionsNS.HelperFunctions;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;
using NLCE = LogicFunctionsNS.NicheLogic.CanDefeatCommonEnemy;
using NLM = LogicFunctionsNS.NicheLogic.CanDefeatMiniBoss;
using NLU = LogicFunctionsNS.NicheLogicUtils;

// TODO: aggregate class

namespace TPRandomizer
{
    /// <summary>
    /// summary text.
    /// </summary>
    public class LogicFunctionsUpdatedRefactored
    {
        # region GlitchlessUtils
        //Evaluate the tokenized settings to their respective values that are set by the settings string.

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool EvaluateSetting(string setting, string value)
        {
            return HLF.EvaluateSetting(setting, value);
        }

        /// <summary>
        /// Checks the setting for difficult combat. Difficult combat includes: difficult, annoying, or time consuming combat
        /// </summary>
        public static bool CanDoDifficultCombat() => DCLU.CanDoDifficultCombat();

        /// <sumamry>
        /// Checks the setting for niche stuff. Niche stuff includes things that may not be obvious to most players, such as damaging enemies with boots, lantern on Gorons, drained Magic Armor for heavy mod, etc.
        /// </summary>
        public static bool CanDoNicheStuff() => NLU.CanDoNicheStuff();

        public static bool CanUseBacksliceAsSword() => NLU.CanUseBacksliceAsSword();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUse(Item item) => CUU.CanUse(item);

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUse(string item) => CanUse(Enum.Parse<Item>(item));

        public static bool CanReplenishItem(Item item) => CUU.CanReplenishItem(item);

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanChangeTime() => HLF.CanChangeTime();

        public static bool CanWarp() => HLF.CanWarp();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canGetHotSpringWater() => BOU.CanGetHotSpringWater();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasDamagingItem()
        {
            return HDI.HasBaseDamagingItem(extraItems: Item.Iron_Boots);
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasSword() => HSL.HasSword();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canSmash() => BU.CanSmash();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canBurnWebs() => MIU.CanBurnWebs();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasRangedItem() => MIU.HasRangedItem();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasShield() => MIU.HasShield();

        public static bool CanUseBottledFairy() => BOU.CanUseBottledFairy();

        public static bool CanUseBottledFairies() => BOU.CanUseBottledFairies();

        public static bool CanUseOilBottle() => BOU.CanUseOilBottle();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canLaunchBombs() => BU.CanLaunchBombs();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool canCutHangingWeb() => MIU.CanCutHangingWeb();

        public static int GetPlayerHealth() => HLF.GetPlayerHealth();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool hasBombs() => BU.HasBombs();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanUseWaterBombs() => BU.CanUseWaterBombs();

        /// <summary>
        /// This is a temporary function that ensures arrows can be refilled for bow usage in Faron Woods/FT.
        /// </summary>
        public static bool CanGetArrows() => CUU.CanGetArrows();

        public static bool CanRefillOil() => CUU.CanRefillOil();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool HasBug() => MIU.HasBug();

        // TODO: If option to not have bug models replaced becomes a thing, this function can be useful
        public static bool CanGetBugWithLantern() => false;

        /// <summary>
        /// Check for a usable bottle (requires lantern to avoid issues with lantern oil in all bottles)
        /// </summary>
        public static bool HasBottle() => BOU.HasBottle();

        public static bool HasBottles() => BOU.HasBottles();

        public static int getItemCount(Item itemToBeCounted) => CUU.GetItemCount(itemToBeCounted);

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool verifyItemQuantity(string itemToBeCounted, int quantity)
        {
            return CUU.VerifyItemQuantity(itemToBeCounted, quantity);
        }

        public static int GetItemWheelSlotCount() => GLU.GetItemWheelSlotCount();

        # endregion

        # region CanDefeatCommonEnemy
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatAeralfos()
        {
            return CanUse(Item.Progressive_Clawshot)
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
                    HasSword()
                    || CanUse(Item.Progressive_Clawshot)
                    || (hasShield() && getItemCount(Item.Progressive_Hidden_Skill) >= 2)
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
                && (hasBombs() || CanUse(Item.Progressive_Clawshot));
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
            return HasSword() || (CanUse(Item.Shadow_Crystal) && CanMidnaCharge());
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
            return CanUseWaterBombs()
                || (HasSword() && (GLLCE.CanDefeatShellBlade() || NLCE.CanDefeatShellBlade()));
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
            return CanUse(Item.Boomerang)
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
        # endregion

        # region CanDefeatMiniboss
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
        # endregion

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
        public static bool canKnockDownHCPainting()
        {
            return (
                CanUse(Item.Progressive_Bow)
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
                || CanUse(Item.Progressive_Bow)
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
                    && ERLF.HasReachedRoom("Faron Woods Coros House Lower")
                    && ERLF.HasReachedRoom("Mist Area Near Faron Woods Cave")
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
                    && ERLF.HasReachedRoom("Kakariko Barnes Bomb Shop Upper")
                    && ERLF.HasReachedRoom("Kakariko Renados Sanctuary Basement")
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

        public static bool CanWarpMeteor()
        {
            return CanCompleteLanayruTwilight()
                || (
                    CanCompleteEldinTwilight()
                    && Randomizer.Rooms.RoomDict["Zoras Domain Throne Room"].ReachedByPlaythrough
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

        // START OF GLITCHED LOGIC
        # region GlitchedUtils
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
    }
}
