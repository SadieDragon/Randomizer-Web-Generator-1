// Leave this file, do not delete it. If logic changes come later, then you can very easily
//  just update the functions within this file, or add new ones as needed. Do not try to
//  simplify this, unless you are going to simplify the `CanX` system altogether. - Lupa

using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtilities;
using NLU = LogicFunctionsNS.NicheLogicUtils;

namespace LogicFunctionsNS.NicheLogic
{
    public class CanDefeatCommonEnemy
    {
        public static bool CanDefeatAeralfos() => NLU.CanDoNicheCombat(includeBackslice: false);

        public static bool CanDefeatArmos() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBabaSerpent() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBabyGohma() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBigBaba() => NLU.CanDoNicheCombat();

        public static bool CanDefeatChu() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBokoblin() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBokoblinRed() => NLU.CanDoNicheCombat(includeBoots: false);

        public static bool CanDefeatBombling() => NLU.CanDoNicheCombat(includeBackslice: false);

        public static bool CanDefeatBomskit() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBubble() => NLU.CanDoNicheCombat();

        public static bool CanDefeatBulblin() => NLU.CanDoNicheCombat();

        public static bool CanDefeatChilfos() => NLU.CanDoNicheCombat();

        public static bool CanDefeatChuWorm() => NLU.CanDoNicheCombat();

        public static bool CanDefeatDekuBaba() => NLU.CanDoNicheCombat();

        public static bool CanDefeatDodongo() => NLU.CanDoNicheCombat();

        public static bool CanDefeatFireBubble() => NLU.CanDoNicheCombat();

        public static bool CanDefeatFireKeese() => NLU.CanDoNicheCombat();

        public static bool CanDefeatGoron() => NLU.CanDoNicheCombat();

        public static bool CanDefeatGuay() => NLU.CanDoNicheCombat(includeBackslice: false);

        public static bool CanDefeatHelmasaur() => NLU.CanDoNicheCombat();

        public static bool CanDefeatHelmasaurus() => NLU.CanDoNicheCombat();

        public static bool CanDefeatIceBubble() => NLU.CanDoNicheCombat();

        public static bool CanDefeatIceKeese() => NLU.CanDoNicheCombat();

        public static bool CanDefeatKargarok() => NLU.CanDoNicheCombat();

        public static bool CanDefeatKeese() => NLU.CanDoNicheCombat();

        public static bool CanDefeatLeever() => NLU.CanDoNicheCombat(includeBackslice: false);

        public static bool CanDefeatLizalfos() => NLU.CanDoNicheCombat();

        public static bool CanDefeatMiniFreezard() => NLU.CanDoNicheCombat();

        public static bool CanDefeatMoldorm() => NLU.CanDoNicheCombat(includeBackslice: false);

        public static bool CanDefeatPuppet() => NLU.CanDoNicheCombat();

        public static bool CanDefeatRat() => NLU.CanDoNicheCombat();

        public static bool CanDefeatRedeadKnight() => NLU.CanDoNicheCombat();

        public static bool CanDefeatShadowBulblin() => NLU.CanDoNicheCombat();

        public static bool CanDefeatShadowDekuBaba() => NLU.CanDoNicheCombat();

        public static bool CanDefeatShadowKargarok() => NLU.CanDoNicheCombat();

        public static bool CanDefeatShadowKeese() => NLU.CanDoNicheCombat();

        public static bool CanDefeatShadowVermin() => NLU.CanDoNicheCombat();

        public static bool CanDefeatShellBlade()
        {
            return NLU.CanDoNicheStuff() && CUU.CanUse(Item.Magic_Armor);
        }

        public static bool CanDefeatSkullfish() => NLU.CanDoNicheCombat();

        public static bool CanDefeatSkulltula() => NLU.CanDoNicheCombat();

        public static bool CanDefeatStalhound() => NLU.CanDoNicheCombat();

        public static bool CanDefeatStalchild() => NLU.CanDoNicheCombat();

        public static bool CanDefeatTektite() => NLU.CanDoNicheCombat();

        public static bool CanDefeatTileWorm() => NLU.CanDoNicheCombat();

        public static bool CanDefeatWhiteWolfos() => NLU.CanDoNicheCombat(includeBackslice: false);

        public static bool CanDefeatYoungGohma() => NLU.CanDoNicheCombat(includeBackslice: false);
    }
}
