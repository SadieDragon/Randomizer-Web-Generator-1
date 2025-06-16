// All basic logic goes in here. Treat glitchless as the most basic form of logic to always be
//  tested for. Glitched is `Glitchless + Glitched`, Niche is `Glitchless + Niche`, etc. To
//  update the core logic for one of the functions, find the function in here. If it does not
//  exist, make one.
// - Lupa

// TODO: CTRL+F - RedeadKnight - Place ShadowBeast once `CanMidnaCharge` is updated/moved/whatever

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

        public static bool CanDefeatArmos() => HDI.HasBaseDamagingItemOrClawshot();

        public static bool CanDefeatBabaSerpent() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatHangingBabaSerpent()
        {
            return CUU.CanUse(Item.Boomerang) || CUU.CanUse(Item.Progressive_Bow);
        }

        public static bool CanDefeatBabyGohma()
        {
            return HSL.HasSword() || HDI.HasAltDamagingItem() || BU.HasBombs();
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

        public static bool CanDefeatBigBaba() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatChu() => HDI.HasBaseDamagingItemOrClawshot();

        public static bool CanDefeatBokoblin() => HDI.HasBaseDamagingItemOrSlingshot();

        public static bool CanDefeatBokoblinRed()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || (CUU.GetItemCount(Item.Progressive_Bow) >= 3)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        public static bool CanDefeatBombfish() => CUU.CanUse(Item.Iron_Boots);

        public static bool CanDefeatBombling() => HDI.HasBaseDamagingItemOrClawshot(true);

        public static bool CanDefeatBomskit() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatBubble() => HDI.HasBaseDamagingItem(true);

        public static bool CanDefeatBulblin() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatChilfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal)
                || CUU.CanUse(Item.Spinner)
                || BU.HasBombs();
        }

        public static bool CanDefeatChuWorm() => HDI.HasBaseDamagingItem(true);

        public static bool CanDefeatDarknut() => HSL.HasSword();

        public static bool CanDefeatDekuBaba()
        {
            return HSL.HasSword()
                || HDI.HasAltDamagingItem()
                || HLF.CanShieldAttack()
                || BU.HasBombs();
        }

        public static bool CanDefeatDekuLike() => BU.HasBombs();

        public static bool CanDefeatDodongo() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatDinalfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatFireBubble() => HDI.HasBaseDamagingItem(true);

        public static bool CanDefeatFireKeese() => HDI.HasBaseDamagingItem(true);

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
            return HSL.HasSword()
                || HDI.HasAltDamagingItem()
                || HLF.CanShieldAttack()
                || BU.HasBombs();
        }

        public static bool CanDefeatGhoulRat() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatGuay()
        {
            return HSL.HasSword()
                || HDI.HasAltDamagingItem(includeClawshot: false, extraItem: Item.Shadow_Crystal);
        }

        public static bool CanDefeatHelmasaur() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatHelmasaurus() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatIceBubble() => HDI.HasBaseDamagingItem(true);

        public static bool CanDefeatIceKeese() => HDI.HasBaseDamagingItemOrSlingshot(true);

        public static bool CanDefeatPoe() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatKargarok() => HDI.HasBaseDamagingItem(true);

        public static bool CanDefeatKeese() => HDI.HasBaseDamagingItemOrSlingshot(true);

        public static bool CanDefeatLeever() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatLizalfos()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        public static bool CanDefeatMiniFreezard() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatMoldorm() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatPoisonMite()
        {
            return HDI.HasBaseDamagingItem(includeBombs: false, extraItems: Item.Lantern);
        }

        public static bool CanDefeatPuppet() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatRat() => HDI.HasBaseDamagingItemOrSlingshot();

        public static bool CanDefeatRedeadKnight()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Shadow_Crystal)
                || BU.HasBombs();
        }

        // TODO: SB requires MidnaCharge handling

        public static bool CanDefeatShadowBulblin() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatShadowDekuBaba()
        {
            return HSL.HasSword()
                || HDI.HasAltDamagingItem()
                || BU.HasBombs()
                || HLF.CanShieldAttack();
        }

        public static bool CanDefeatShadowInsect() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatShadowKargarok() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatShadowKeese()
        {
            return HDI.HasBaseDamagingItemOrSlingshot(includeBombs: false);
        }

        public static bool CanDefeatShadowVermin() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatShellBlade() => CUU.CanUse(Item.Iron_Boots);

        public static bool CanDefeatSkullfish() => HDI.HasBaseDamagingItem(false);

        public static bool CanDefeatSkulltula() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatStalfos() => BU.CanSmash();

        public static bool CanDefeatStalhound() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatStalchild() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatTektite() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatTileWorm() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatToado() => HDI.HasBaseDamagingItem(false);

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
            return HDI.HasAltDamagingItem(extraItem: Item.Boomerang);
        }

        public static bool CanDefeatWhiteWolfos() => HDI.HasBaseDamagingItem();

        public static bool CanDefeatYoungGohma() => HDI.HasBaseDamagingItem();
    }
}
