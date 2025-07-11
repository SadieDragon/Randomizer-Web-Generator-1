using TPRandomizer;

namespace LogicFunctionsNS.AggregateLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa()
        {
            return BombUtils.CanLaunchBombs()
                || (
                    CanUseUtils.CanUse(Item.Boomerang)
                    && (
                        HasSwordLevel.HasSword()
                        || CanUseUtils.CanUse(Item.Ball_and_Chain)
                        || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots))
                        || CanUseUtils.CanUse(Item.Shadow_Crystal)
                        || BombUtils.HasBombs()
                        || (
                            SettingUtils.CanDoDifficultCombat()
                            && NicheLogicUtils.CanUseBacksliceAsSword()
                        )
                    )
                );
        }

        public static bool CanDefeatFyrus()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow)
                && CanUseUtils.CanUse(Item.Iron_Boots)
                && (
                    HasSwordLevel.HasSword()
                    || (
                        SettingUtils.CanDoDifficultCombat()
                        && NicheLogicUtils.CanUseBacksliceAsSword()
                    )
                );
        }

        public static bool CanDefeatMorpheel()
        {
            return (
                    CanUseUtils.CanUse(Item.Zora_Armor)
                    && CanUseUtils.CanUse(Item.Iron_Boots)
                    && HasSwordLevel.HasSword()
                    && CanUseUtils.CanUse(Item.Progressive_Clawshot)
                )
                || (
                    SettingUtils.CanDoNicheStuff()
                    && CanUseUtils.CanUse(Item.Progressive_Clawshot)
                    && GlitchedLogicUtils.CanDoAirRefill()
                    && HasSwordLevel.HasSword()
                );
        }

        public static bool CanDefeatStallord()
        {
            return (CanUseUtils.CanUse(Item.Spinner) && HasSwordLevel.HasSword())
                || (SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Spinner));
        }

        public static bool CanDefeatBlizzeta()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain);
        }

        public static bool CanDefeatArmogohma()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow)
                && CanUseUtils.CanUse(Item.Progressive_Dominion_Rod);
        }

        public static bool CanDefeatArgorok()
        {
            return HasClawshotCount.HasDoubleClawshot()
                && HasSwordLevel.HasOrdonSword()
                && (
                    CanUseUtils.CanUse(Item.Iron_Boots)
                    || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Magic_Armor))
                );
        }

        public static bool CanDefeatZant()
        {
            return HasSwordLevel.HasMasterSword()
                && CanUseUtils.CanUse(Item.Boomerang)
                && CanUseUtils.CanUse(Item.Progressive_Clawshot)
                && CanUseUtils.CanUse(Item.Ball_and_Chain)
                && (
                    CanUseUtils.CanUse(Item.Iron_Boots)
                    || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Magic_Armor))
                )
                && (
                    CanUseUtils.CanUse(Item.Zora_Armor)
                    || (SettingUtils.IsGlitchedLogic() && GlitchedLogicUtils.CanDoAirRefill())
                );
        }

        public static bool CanDefeatGanondorf()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                && HasSwordLevel.HasMasterSword()
                && CanUseUtils.CanUse(Item.Progressive_Hidden_Skill);
        }
    }
}
