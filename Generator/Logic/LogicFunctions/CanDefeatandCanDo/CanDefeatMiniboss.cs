using TPRandomizer;

namespace LogicFunctionsNS.AggregateLogic
{
    public static class CanDefeatMiniBoss
    {
        public static bool CanDefeatZantHead()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                || HasSwordLevel.HasSword()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatOok()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatDangoro()
        {
            return CanUseUtils.CanUse(Item.Iron_Boots)
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Shadow_Crystal)
                    || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Ball_and_Chain))
                    || (CanUseUtils.CanUse(Item.Progressive_Bow) && BombUtils.HasBombs())
                );
        }

        public static bool CanDefeatCarrierKargarok()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatTwilitBloat()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        public static bool CanDefeatDekuToad()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanDefeatSkullKid()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow);
        }

        public static bool CanDefeatKingBulblinBridge()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow);
        }

        public static bool CanDefeatKingBulblinDesert()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || HasQuiverSize.HasLargeQuiver()
                || NicheLogicUtils.CanUseBacksliceAsSword()
                || (
                    SettingUtils.CanDoDifficultCombat()
                    && (
                        CanUseUtils.CanUse(Item.Spinner)
                        || CanUseUtils.CanUse(Item.Iron_Boots)
                        || BombUtils.HasBombs()
                        || HasQuiverSize.HasMediumQuiver()
                    )
                );
        }

        public static bool CanDefeatKingBulblinCastle()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || HasQuiverSize.HasLargeQuiver()
                || (
                    SettingUtils.CanDoDifficultCombat()
                    && (
                        CanUseUtils.CanUse(Item.Spinner)
                        || CanUseUtils.CanUse(Item.Iron_Boots)
                        || BombUtils.HasBombs()
                        || NicheLogicUtils.CanUseBacksliceAsSword()
                    )
                );
        }

        public static bool CanDefeatDeathSword()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                && HasSwordLevel.HasSword()
                && (
                    CanUseUtils.CanUse(Item.Boomerang)
                    || CanUseUtils.CanUse(Item.Progressive_Bow)
                    || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                );
        }

        public static bool CanDefeatDarkhammer()
        {
            return HasSwordLevel.HasSword()
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                || CanUseUtils.CanUse(Item.Shadow_Crystal)
                || BombUtils.HasBombs()
                || (
                    SettingUtils.CanDoDifficultCombat() && NicheLogicUtils.CanUseBacksliceAsSword()
                );
        }

        public static bool CanDefeatPhantomZant()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal) || HasSwordLevel.HasSword();
        }
    }
}
