using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtilities;
using NLU = LogicFunctionsNS.NicheLogicUtils;

namespace LogicFunctionsNS.NicheLogic
{
    public class CanDefeatMiniBoss
    {
        public static bool CanDefeatZantHead() => NLU.CanDoNicheCombat(includeBoots: false);

        public static bool CanDefeatOok() => NLU.CanDoNicheCombat();

        public static bool CanDefeatDangoro()
        {
            return NLU.CanDoNicheStuff() && CUU.CanUse(Item.Ball_and_Chain);
        }

        public static bool CanDefeatDekuToad() => NLU.CanDoNicheCombat();

        public static bool CanDefeatKingBulblinDesert()
        {
            return NLU.CanDoNicheCombat(includeBoots: false);
        }

        public static bool CanDefeatDarkhammer() => NLU.CanDoNicheCombat(includeBackslice: false);
    }
}
