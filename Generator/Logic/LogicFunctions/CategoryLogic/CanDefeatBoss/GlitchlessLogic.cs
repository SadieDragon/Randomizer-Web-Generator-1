using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;
using HBL = LogicFunctionsNS.HasBowLevel;
using HDI = LogicFunctionsNS.DamagingItems;
using HSL = LogicFunctionsNS.HasSwordLevel;

namespace LogicFunctionsNS.GlitchlessLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa() => HDI.HasMeleeAltDamagingItem(includeBow: false);

        public static bool CanDefeatFyrus() => HSL.HasSword();

        public static bool CanDefeatMorpheel()
        {
            return CUU.CanUse(Item.Zora_Armor) && CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatStallord()
        {
            return CUU.CanUse(Item.Spinner) && HSL.HasSword();
        }

        public static bool CanDefeatBlizzeta() => CUU.CanUse(Item.Ball_and_Chain);

        public static bool CanDefeatArmogohma()
        {
            return HBL.HasBow() && CUU.CanUse(Item.Progressive_Dominion_Rod);
        }

        public static bool CanDefeatArgorok() => CUU.CanUse(Item.Iron_Boots);

        // Zant's glitchless is currently not able to be extracted into a fn. See the AL for the reason.

        public static bool CanDefeatGanondorf()
        {
            return CUU.CanUse(Item.Shadow_Crystal)
                && HSL.HasMasterSword()
                && HasHiddenSkillLevel.HasEndingBlow();
        }
    }
}
