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
                    || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                );
        }

        public static bool CanDefeatArmos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || BombUtils.HasBombs()
                || CanUseUtils.CanUse(Item.Spinner)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatBabaSerpent()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return (CanUseUtils.CanUse(Item.Boomerang) || CanUseUtils.CanUse(Item.Progressive_Bow))
                && LogicFunctions.CanDefeatBabaSerpent();
        }

        public static bool CanDefeatBabyGohma()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
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
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Spinner)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatChu()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatBokoblin()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatBokoblinRed()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || HasQuiverSize.HasLargeQuiver()
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword()
                || (
                    SettingUtils.CanDoDifficultCombat()
                    && (CanUseUtils.CanUse(Item.Iron_Boots) || CanUseUtils.CanUse(Item.Spinner))
                );
        }

        public static bool CanDefeatBombfish()
        {
            return (
                    CanUseUtils.CanUse(Item.Iron_Boots)
                    || (SettingUtils.IsGlitchedLogic() && CanUseUtils.CanUse(Item.Magic_Armor))
                )
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                    || MiscItemUtils.CanShieldAttack()
                );
        }

        public static bool CanDefeatBombling()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot);
        }

        public static bool CanDefeatBomskit()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword()
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots));
        }

        public static bool CanDefeatBubble()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatBulblin()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatChilfos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Spinner)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatChuWorm()
        {
            return (BombUtils.HasBombs() || CanUseUtils.CanUse(Item.Progressive_Clawshot))
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Ball_and_Chain)
                    || CanUseUtils.CanUse(Item.Progressive_Bow)
                    || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                    || CanUseUtils.CanUse(Item.Spinner)
                    || CanUseUtils.CanUse(Item.Shadow_Crystal)
                    || NicheLogicUtils.CanUseBacksliceAsSword()
                );
        }

        public static bool CanDefeatDarknut()
        {
            return HasSwordLevel.HasSword()
                || (
                    SettingUtils.CanDoDifficultCombat()
                    && (BombUtils.HasBombs() || CanUseUtils.CanUse(Item.Ball_and_Chain))
                );
        }

        public static bool CanDefeatDekuBaba()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || MiscItemUtils.CanShieldAttack()
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatDekuLike()
        {
            return BombUtils.HasBombs();
        }

        public static bool CanDefeatDodongo()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatDinalfos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatFireBubble()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatFireKeese()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatFireToadpoli()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (CanUseUtils.CanUse(Item.Hylian_Shield) && HasHiddenSkillLevel.HasShieldAttack())
                || (SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Shadow_Crystal));
        }

        public static bool CanDefeatFreezard()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain);
        }

        public static bool CanDefeatGoron()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || MiscItemUtils.CanShieldAttack()
                || CanUseUtils.CanUse(Item.Slingshot)
                || (SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Lantern))
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
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
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || (SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Spinner))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || CanUseUtils.CanUse(Item.Slingshot);
        }

        public static bool CanDefeatHelmasaur()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatHelmasaurus()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatIceBubble()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatIceKeese()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatPoe()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatKargarok()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatKeese()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatLeever()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs();
        }

        public static bool CanDefeatLizalfos()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatMiniFreezard()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatMoldorm()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs();
        }

        public static bool CanDefeatPoisonMite()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Lantern)
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatPuppet()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatRat()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatRedeadKnight()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
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
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatShadowDekuBaba()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || MiscItemUtils.CanShieldAttack()
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatShadowInsect()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatShadowKargarok()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatShadowKeese()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatShadowVermin()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatShellBlade()
        {
            return BombUtils.CanUseWaterBombs()
                || (
                    HasSwordLevel.HasSword()
                    && (
                        CanUseUtils.CanUse(Item.Iron_Boots)
                        || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Magic_Armor))
                    )
                );
        }

        public static bool CanDefeatSkullfish()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatSkulltula()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatStalfos()
        {
            return BombUtils.CanSmash();
        }

        public static bool CanDefeatStalhound()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatStalchild()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatTektite()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatTileWorm()
        {
            return CanUseUtils.CanUse(Item.Boomerang)
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Ball_and_Chain)
                    || CanUseUtils.CanUse(Item.Progressive_Bow)
                    || CanUseUtils.CanUse(Item.Shadow_Crystal)
                    || CanUseUtils.CanUse(Item.Spinner)
                    || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                    || BombUtils.HasBombs()
                    || NicheLogicUtils.CanUseBacksliceAsSword()
                );
        }

        public static bool CanDefeatToado()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatWaterToadpoli()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || MiscItemUtils.CanShieldAttack()
                || (SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Shadow_Crystal));
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
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs();
        }

        public static bool CanDefeatYoungGohma()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Spinner)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs();
        }
    }
}
