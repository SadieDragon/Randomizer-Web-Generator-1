using System.Collections.Generic;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using HDI = LogicFunctionsNS.DamagingItems;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using HLF = LogicFunctionsNS.HelperFunctions;
using HSL = LogicFunctionsNS.HasSwordLevel;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

// TODO:
// - lists of damaging items
// - dict to pair them with keywords
// - 'HasDamagingItem' idea using this

namespace LogicFunctionsNS
{
    public class GlitchlessLogic
    {
        // Shorthand wrappers- not really required
        private static bool CanUseBallAndChain()
        {
            return CUU.CanUse(Item.Ball_and_Chain);
        }

        private static bool CanUseBoomerang()
        {
            return CUU.CanUse(Item.Boomerang);
        }

        private static bool CanUseBow()
        {
            return CUU.CanUse(Item.Progressive_Bow);
        }

        private static bool CanUseClawshot()
        {
            return CUU.CanUse(Item.Progressive_Clawshot);
        }

        private static bool CanUseIronBoots()
        {
            return CUU.CanUse(Item.Iron_Boots);
        }

        private static bool CanUseShadowCrystal()
        {
            return CUU.CanUse(Item.Shadow_Crystal);
        }

        private static bool CanUseSlingshot()
        {
            return CUU.CanUse(Item.Slingshot);
        }

        private static bool CanUseSpinner()
        {
            return CUU.CanUse(Item.Spinner);
        }

        // End of Shorthands

        public static bool CanDefeatAeralfos()
        {
            return CanUseClawshot()
                && (HSL.HasSword() || CanUseBallAndChain() || CanUseShadowCrystal());
        }

        public static bool CanDefeatArmos()
        {
            return HDI.HasDamagingItemOrClawshot();
        }

        public static bool CanDefeatBabaSerpent()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatBabyGohma()
        {
            return HDI.HasDamagingItemOrSlingshot();
        }

        public static bool CanDefeatBari()
        {
            return BU.CanUseWaterBombs() || CanUseClawshot();
        }

        public static bool CanDefeatBeamos()
        {
            return CanUseBallAndChain() || CanUseBow() || BU.HasBombs();
        }

        public static bool CanDefeatBigBaba()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatBombfish()
        {
            return CanUseIronBoots();
        }

        public static bool CanDefeatBombfishCoreRequirements()
        {
            return HSL.HasSword() || CanUseClawshot() || HLF.CanShieldAttack();
        }

        public static bool CanDefeatBombling()
        {
            return HDI.HasDamagingItemOrClawshot(includeBombs: false);
        }

        public static bool CanDefeatBomskit()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatBokoblin()
        {
            return HDI.HasDamagingItemOrSlingshot();
        }

        public static bool CanDefeatBokoblinRed()
        {
            return HSL.HasSword()
                || CanUseBallAndChain()
                || ((CUU.GetItemCount(Item.Progressive_Bow) >= 3) && LF.CanGetArrows())
                || CanUseShadowCrystal()
                || BU.HasBombs();
        }

        public static bool CanDefeatBubble()
        {
            return HDI.HasDamagingItem(includeBombs: false);
        }

        public static bool CanDefeatBulblin()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatChilfos()
        {
            return HSL.HasSword()
                || CanUseBallAndChain()
                || CanUseShadowCrystal()
                || CanUseSpinner()
                || BU.HasBombs();
        }

        public static bool CanDefeatChu()
        {
            return HDI.HasDamagingItemOrClawshot();
        }

        public static bool CanDefeatChuWorm()
        {
            return HDI.HasDamagingItem(includeBombs: false);
        }

        public static bool CanDefeatChuWormCoreRequirements()
        {
            return BU.HasBombs() || CanUseClawshot();
        }

        public static bool CanDefeatDarknut()
        {
            return HSL.HasSword();
        }

        public static bool CanDefeatDekuBaba()
        {
            return HDI.HasDamagingItem(extraItems: [Item.Progressive_Clawshot, Item.Slingshot]);
        }

        public static bool CanDefeatDekuLike()
        {
            return BU.HasBombs();
        }

        public static bool CanDefeatDinalfos()
        {
            return HSL.HasSword() || CanUseBallAndChain() || CanUseShadowCrystal();
        }

        public static bool CanDefeatDodongo()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatFireToadpoli()
        {
            return HSL.HasSword()
                || CanUseBallAndChain()
                || CanUseBow()
                || (CUU.CanUse(Item.Hylian_Shield) && HHSL.HasShieldAttack());
        }

        public static bool CanDefeatFreezard()
        {
            return CanUseBallAndChain();
        }

        public static bool CanDefeatGhoulRat()
        {
            return CanUseShadowCrystal();
        }

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

        public static bool CanDefeatGuay()
        {
            return HSL.HasSword()
                || CanUseBallAndChain()
                || CanUseBow()
                || CanUseShadowCrystal()
                || CanUseSlingshot();
        }

        // Note: this also needs the Niche def of CDBabaSerpent;
        //  please do not add `CanDefeatBabaSerpent()`.
        public static bool CanDefeatHangingBabaSerpent()
        {
            return CanUseBoomerang() || CanUseBow();
        }

        public static bool CanDefeatHelmasaur()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatHelmasaurus()
        {
            return HDI.HasDamagingItem();
        }

        public static bool CanDefeatKargarok()
        {
            return HDI.HasDamagingItem(includeBombs: false);
        }

        public static bool CanDefeatKeese()
        {
            return HDI.HasDamagingItemOrSlingshot(includeBombs: false);
        }

        public static bool CanDefeatPoe()
        {
            return CanUseShadowCrystal();
        }
    }
}
