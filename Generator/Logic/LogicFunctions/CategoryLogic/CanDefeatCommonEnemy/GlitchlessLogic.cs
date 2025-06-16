// All basic logic goes in here. Treat glitchless as the most basic form of logic to always be
//  tested for. Glitched is `Glitchless + Glitched`, Niche is `Glitchless + Niche`, etc. To
//  update the core logic for one of the functions, find the function in here. If it does not
//  exist, make one.
// - Lupa

// TODO: CTRL+F - RedeadKnight - Place ShadowBeast once `CanMidnaCharge` is updated/moved/whatever

using System.Collections.Generic;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using HDI = LogicFunctionsNS.DamagingItems;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using HLF = LogicFunctionsNS.HelperFunctions;
using HSL = LogicFunctionsNS.HasSwordLevel;

namespace LogicFunctionsNS.GlitchlessLogic
{
    public class CanDefeatCommonEnemy
    {
        public static bool CanDefeatAeralfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatArmos() => HDI.HasDamagingItemOrClawshot();

        public static bool CanDefeatBabaSerpent() => HDI.HasDamagingItem();

        public static bool CanDefeatHangingBabaSerpent()
        {
            return CUU.CanUse(Item.Boomerang) || CUU.CanUse(Item.Progressive_Bow);
        }

        public static bool CanDefeatBabyGohma()
        {
            List<Item> damagingItems =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Spinner,
                Item.Slingshot,
                Item.Progressive_Clawshot,
            ];

            return HSL.HasSword() || HDI.HasAnyDamagingItem(damagingItems) || BU.HasBombs();
        }

        public static bool CanDefeatBari()
        {
            return BU.CanUseWaterBombs() || CUU.CanUse(Item.Progressive_Clawshot);
        }

        public static bool CanDefeatBeamos()
        {
            return CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || BU.HasBombs();
        }

        public static bool CanDefeatBigBaba() => HDI.HasDamagingItem();

        public static bool CanDefeatChu() => HDI.HasDamagingItemOrClawshot();

        public static bool CanDefeatBokoblin() => HDI.HasDamagingItemOrSlingshot();

        public static bool CanDefeatBokoblinRed()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || (CUU.GetItemCount(Item.Progressive_Bow) >= 3)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        public static bool CanDefeatBombfish() => CUU.CanUse(Item.Iron_Boots);

        public static bool CanDefeatBombling() => HDI.HasDamagingItemOrClawshot(true);

        public static bool CanDefeatBomskit() => HDI.HasDamagingItem();

        public static bool CanDefeatBubble() => HDI.HasDamagingItem(true);

        public static bool CanDefeatBulblin() => HDI.HasDamagingItem();

        public static bool CanDefeatChilfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal)
                || CUU.CanUse(Item.Spinner)
                || BU.HasBombs();
        }

        public static bool CanDefeatChuWorm() => HDI.HasDamagingItem(true);

        public static bool CanDefeatDarknut() => HSL.HasSword();

        public static bool CanDefeatDekuBaba()
        {
            List<Item> damagingItems =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Spinner,
                Item.Slingshot,
                Item.Progressive_Clawshot,
            ];

            return HSL.HasSword()
                || HDI.HasAnyDamagingItem(damagingItems)
                || HLF.CanShieldAttack()
                || BU.HasBombs();
        }

        public static bool CanDefeatDekuLike() => BU.HasBombs();

        public static bool CanDefeatDodongo() => HDI.HasDamagingItem();

        public static bool CanDefeatDinalfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatFireBubble() => HDI.HasDamagingItem(true);

        public static bool CanDefeatFireKeese() => HDI.HasDamagingItem(true);

        public static bool CanDefeatFireToadpoli()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || (CUU.CanUse(Item.Hylian_Shield) && HHSL.HasShieldAttack());
        }

        public static bool CanDefeatFreezard() => CUU.CanUse(Item.Ball_and_Chain);

        public static bool CanDefeatGoron()
        {
            List<Item> damagingItems =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Spinner,
                Item.Slingshot,
                Item.Progressive_Clawshot,
            ];

            return HSL.HasSword()
                || HDI.HasAnyDamagingItem(damagingItems)
                || HLF.CanShieldAttack()
                || BU.HasBombs();
        }

        public static bool CanDefeatGhoulRat() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatGuay()
        {
            List<Item> damagingItems =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Shadow_Crystal,
                Item.Slingshot,
            ];

            return HSL.HasSword() || HDI.HasAnyDamagingItem(damagingItems);
        }

        public static bool CanDefeatHelmasaur() => HDI.HasDamagingItem();

        public static bool CanDefeatHelmasaurus() => HDI.HasDamagingItem();

        public static bool CanDefeatIceBubble() => HDI.HasDamagingItem(true);

        public static bool CanDefeatIceKeese() => HDI.HasDamagingItemOrSlingshot(true);

        public static bool CanDefeatPoe() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatKargarok() => HDI.HasDamagingItem(true);

        public static bool CanDefeatKeese() => HDI.HasDamagingItemOrSlingshot(true);

        public static bool CanDefeatLeever() => HDI.HasDamagingItem();

        public static bool CanDefeatLizalfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        public static bool CanDefeatMiniFreezard() => HDI.HasDamagingItem();

        public static bool CanDefeatMoldorm() => HDI.HasDamagingItem();

        public static bool CanDefeatPoisonMite()
        {
            return HDI.HasDamagingItem(includeBombs: false, Item.Lantern);
        }

        public static bool CanDefeatPuppet() => HDI.HasDamagingItem();

        public static bool CanDefeatRat() => HDI.HasDamagingItemOrSlingshot();

        public static bool CanDefeatRedeadKnight()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        // TODO: SB requires MidnaCharge handling

        public static bool CanDefeatShadowBulblin() => HDI.HasDamagingItem();

        public static bool CanDefeatShadowDekuBaba()
        {
            // sword, b&c, bow, spinner, sling, claw, bombs
            List<Item> damagingItems =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Spinner,
                Item.Slingshot,
                Item.Progressive_Clawshot,
            ];

            return HSL.HasSword()
                || HDI.HasAnyDamagingItem(damagingItems)
                || BU.HasBombs()
                || HLF.CanShieldAttack();
        }

        public static bool CanDefeatShadowInsect() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatShadowKargarok() => HDI.HasDamagingItem();

        public static bool CanDefeatShadowKeese()
        {
            return HDI.HasDamagingItemOrSlingshot(includeBombs: false);
        }

        public static bool CanDefeatShadowVermin() => HDI.HasDamagingItem();

        public static bool CanDefeatShellBlade() => CUU.CanUse(Item.Iron_Boots);

        public static bool CanDefeatSkullfish() => HDI.HasDamagingItem(false);

        public static bool CanDefeatSkulltula() => HDI.HasDamagingItem();

        public static bool CanDefeatStalfos() => BU.CanSmash();

        public static bool CanDefeatStalhound() => HDI.HasDamagingItem();

        public static bool CanDefeatStalchild() => HDI.HasDamagingItem();

        public static bool CanDefeatTektite() => HDI.HasDamagingItem();

        public static bool CanDefeatTileWorm() => HDI.HasDamagingItem();

        public static bool CanDefeatToado() => HDI.HasDamagingItem(false);

        public static bool CanDefeatWaterToadpoli()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || HLF.CanShieldAttack();
        }

        public static bool CanDefeatTorchSlug()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        public static bool CanDefeatWalltula()
        {
            List<Item> damagingItems =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Boomerang,
                Item.Slingshot,
                Item.Progressive_Clawshot,
            ];

            return HDI.HasAnyDamagingItem(damagingItems);
        }

        public static bool CanDefeatWhiteWolfos() => HDI.HasDamagingItem();

        public static bool CanDefeatYoungGohma() => HDI.HasDamagingItem();
    }
}
