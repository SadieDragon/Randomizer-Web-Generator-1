using TPRandomizer;

namespace LogicFunctionsNS.AggregateLogic
{
    public class CanDefeatCommonEnemy
    {
        public static bool CanDefeatAeralfos()
        {
            return CanUseUtils.CanUse(Item.Progressive_Clawshot)
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Ball_and_Chain)
                    || CanUseUtils.CanUse(Item.Shadow_Crystal)
                    || NicheLogicUtils.CanUseIronBootsNiche()
                );
        }

        public static bool CanDefeatArmos()
        {
            return HasDamagingItemUtils.HasDamagingItemIClawshot()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatBabaSerpent()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return CanDefeatBabaSerpent()
                && (CanUseUtils.CanUse(Item.Boomerang) || CanUseUtils.CanUse(Item.Progressive_Bow));
        }

        public static bool CanDefeatBabyGohma()
        {
            return HasDamagingItemUtils.HasDamagingItemECrystal()
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatBari()
        {
            return BombUtils.CanUseWaterBombs() || CanUseUtils.CanUse(Item.Progressive_Clawshot);
        }

        public static bool CanDefeatBeamos()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || BombUtils.HasBombs();
        }

        public static bool CanDefeatBigBaba()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatChu()
        {
            return HasDamagingItemUtils.HasDamagingItemIClawshot()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatBokoblin()
        {
            return HasDamagingItemUtils.HasDamagingItemISlingshot()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatBokoblinRed()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || HasQuiverSize.HasLargeQuiver()
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword()
                || DifficultCombatLogicUtils.CanUseSpinnerOrIronBootsInDC();
        }

        public static bool CanDefeatBombfish()
        {
            return HelperFunctions.CanUseBootsOrGlitchedMagicArmor()
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                    || MiscItemUtils.CanShieldAttack()
                );
        }

        public static bool CanDefeatBombling()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || NicheLogicUtils.CanUseIronBootsNiche();
        }

        public static bool CanDefeatBomskit()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatBubble()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatBulblin()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatChilfos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Spinner)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatChuWorm()
        {
            return (BombUtils.HasBombs() || CanUseUtils.CanUse(Item.Progressive_Clawshot))
                && (
                    HasDamagingItemUtils.HasDamagingItemEBombs()
                    || NicheLogicUtils.CanDoNicheCombat()
                );
        }

        public static bool CanDefeatDarknut()
        {
            return HasSwordLevel.HasSword()
                || (SettingUtils.CanDoDifficultCombat() && BombUtils.CanSmash());
        }

        public static bool CanDefeatDekuBaba()
        {
            return HasDamagingItemUtils.HasDamagingItemECrystal()
                || MiscItemUtils.CanShieldAttack()
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatDekuLike()
        {
            return BombUtils.HasBombs();
        }

        public static bool CanDefeatDodongo()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatDinalfos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatFireBubble()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatFireKeese()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || CanUseUtils.CanUse(Item.Slingshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatFireToadpoli()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (CanUseUtils.CanUse(Item.Hylian_Shield) && HasHiddenSkillLevel.HasShieldAttack())
                || DifficultCombatLogicUtils.CanUseShadowCrystalInDC();
        }

        public static bool CanDefeatFreezard()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain);
        }

        public static bool CanDefeatGoron()
        {
            return HasDamagingItemUtils.HasDamagingItemECrystal()
                || MiscItemUtils.CanShieldAttack()
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || (SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Lantern))
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatGhoulRat()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatGuay()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Slingshot)
                || NicheLogicUtils.CanUseIronBootsNiche()
                || DifficultCombatLogicUtils.CanUseSpinnerInDC();
        }

        public static bool CanDefeatHelmasaur()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatHelmasaurus()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatIceBubble()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatIceKeese()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || CanUseUtils.CanUse(Item.Slingshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatPoe()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatKargarok()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatKeese()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || CanUseUtils.CanUse(Item.Slingshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatLeever()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanUseIronBootsNiche();
        }

        public static bool CanDefeatLizalfos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatMiniFreezard()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatMoldorm()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanUseIronBootsNiche();
        }

        public static bool CanDefeatPoisonMite()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs() || CanUseUtils.CanUse(Item.Lantern);
        }

        public static bool CanDefeatPuppet()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || NicheLogicUtils.CanUseIronBootsNiche()
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatRat()
        {
            return HasDamagingItemUtils.HasDamagingItemISlingshot()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatRedeadKnight()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatShadowBeast()
        {
            return HasSwordLevel.HasSword()
                || (
                    CanUseUtils.CanUse(Item.Shadow_Crystal)
                    && LogicFunctionsUpdatedRefactored.CanMidnaCharge()
                );
        }

        public static bool CanDefeatShadowBulblin()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatShadowDekuBaba()
        {
            return HasDamagingItemUtils.HasDamagingItemECrystal()
                || MiscItemUtils.CanShieldAttack()
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatShadowInsect()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatShadowKargarok()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatShadowKeese()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || CanUseUtils.CanUse(Item.Slingshot)
                || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatShadowVermin()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatShellBlade()
        {
            return BombUtils.CanUseWaterBombs()
                || (HasSwordLevel.HasSword() && HelperFunctions.CanUseBootsOrNicheMagicArmor());
        }

        public static bool CanDefeatSkullfish()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs()
                || NicheLogicUtils.CanUseIronBootsNiche();
        }

        public static bool CanDefeatSkulltula()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatStalfos()
        {
            return BombUtils.CanSmash();
        }

        public static bool CanDefeatStalhound()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatStalchild()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatTektite()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat();
        }

        public static bool CanDefeatTileWorm()
        {
            return CanUseUtils.CanUse(Item.Boomerang)
                && (HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanDoNicheCombat());
        }

        public static bool CanDefeatToado()
        {
            return HasDamagingItemUtils.HasDamagingItemEBombs();
        }

        public static bool CanDefeatWaterToadpoli()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || MiscItemUtils.CanShieldAttack()
                || DifficultCombatLogicUtils.CanUseShadowCrystalInDC();
        }

        public static bool CanDefeatTorchSlug()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs();
        }

        public static bool CanDefeatWalltula()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Boomerang)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot);
        }

        public static bool CanDefeatWhiteWolfos()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanUseIronBootsNiche();
        }

        public static bool CanDefeatYoungGohma()
        {
            return HasDamagingItemUtils.HasDamagingItem() || NicheLogicUtils.CanUseIronBootsNiche();
        }
    }
}
