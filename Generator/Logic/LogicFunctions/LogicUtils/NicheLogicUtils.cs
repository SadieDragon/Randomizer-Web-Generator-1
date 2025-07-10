using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using CUU = LogicFunctionsNS.CanUseUtils;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;

namespace LogicFunctionsNS
{
    public class NicheLogicUtils
    {
        /// <sumamry>
        /// Checks the setting for niche stuff. Niche stuff includes things that may not be obvious to most players, such as damaging enemies with boots, lantern on Gorons, drained Magic Armor for heavy mod, etc.
        /// </summary>
        public static bool CanDoNicheStuff()
        {
            // TODO: Change to use setting once it is made
            return Randomizer.SSettings.logicRules == LogicRules.Glitched;
        }

        public static bool CanDoNicheCombat(bool includeBackslice = true, bool includeBoots = true)
        {
            return CanDoNicheStuff()
                && (
                    (includeBackslice && HHSL.HasBackslice())
                    || (includeBoots && CUU.CanUse(Item.Iron_Boots))
                );
        }

        public static bool CanUseBacksliceAsSword()
        {
            return CanDoNicheStuff() && HHSL.HasBackslice();
        }

        public static bool CanUseMagicArmorNiche()
        {
            return CanDoNicheStuff() && CUU.CanUse(Item.Magic_Armor);
        }
    }
}
