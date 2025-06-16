using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using CUU = LogicFunctionsNS.CanUseUtilities;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;

namespace LogicFunctionsNS
{
    public class NicheLogicUtils
    {
        public static bool CanDoNicheStuff()
        {
            // TODO: Change to use setting once it is made
            return Randomizer.SSettings.logicRules == LogicRules.Glitched;
        }

        public static bool CanUseIronBootsAndDoNiche()
        {
            return CanDoNicheStuff() && CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanUseBacksliceAsSword()
        {
            return CanDoNicheStuff() && HHSL.HasBackslice();
        }
    }
}
