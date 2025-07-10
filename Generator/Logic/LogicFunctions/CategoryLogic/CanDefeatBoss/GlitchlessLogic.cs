using TPRandomizer;

namespace LogicFunctionsNS.GlitchlessLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa()
        {
            return DamagingItems.HasMeleeAltDamagingItem(includeBow: false);
        }

        public static bool CanDefeatFyrus() => HasSwordLevel.HasSword();

        public static bool CanDefeatMorpheel()
        {
            return CanUseUtils.CanUse(Item.Zora_Armor) && CanUseUtils.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatStallord()
        {
            return CanUseUtils.CanUse(Item.Spinner) && HasSwordLevel.HasSword();
        }

        public static bool CanDefeatBlizzeta() => CanUseUtils.CanUse(Item.Ball_and_Chain);

        public static bool CanDefeatArmogohma()
        {
            return HasBowLevel.HasBow() && CanUseUtils.CanUse(Item.Progressive_Dominion_Rod);
        }

        public static bool CanDefeatArgorok() => CanUseUtils.CanUse(Item.Iron_Boots);

        // Zant's glitchless is currently not able to be extracted into a fn. See the AL for the reason.

        public static bool CanDefeatGanondorf()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                && HasSwordLevel.HasMasterSword()
                && HasHiddenSkillLevel.HasEndingBlow();
        }
    }
}
