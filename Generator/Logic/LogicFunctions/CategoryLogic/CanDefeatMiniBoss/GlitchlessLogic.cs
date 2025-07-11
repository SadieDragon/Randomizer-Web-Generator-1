using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using HBL = LogicFunctionsNS.HasQuiverSize;
using HDI = LogicFunctionsNS.DamagingItems;
using HSL = LogicFunctionsNS.HasSwordLevel;

namespace LogicFunctionsNS.GlitchlessLogic
{
    public class CanDefeatMiniBoss
    {
        public static bool CanDefeatZantHead()
        {
            return CUU.CanUse(Item.Shadow_Crystal) || HSL.HasSword();
        }

        public static bool CanDefeatOok() => HDI.HasMeleeAltDamagingItem();

        public static bool CanDefeatDangoro()
        {
            return HSL.HasSword()
                || CUU.CanUse(Item.Shadow_Crystal)
                || (HBL.HasBow() && BU.HasBombs());
        }

        public static bool CanDefeatCarrierKargarok() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatTwilitBloat() => CUU.CanUse(Item.Shadow_Crystal);

        public static bool CanDefeatDekuToad() => HDI.HasMeleeAltDamagingItem();

        public static bool CanDefeatSkullKid() => HBL.HasBow();

        public static bool CanDefeatKingBulblinBridge() => HBL.HasBow();

        public static bool CanDefeatKingBulblinDesert()
        {
            return HDI.HasMeleeAltDamagingItem(includeBombs: false, includeBow: false)
                || HBL.HasLargeQuiver();
        }

        public static bool CanDefeatKingBulblinCastle()
        {
            return HDI.HasMeleeAltDamagingItem(includeBombs: false, includeBow: false)
                || HBL.HasLargeQuiver();
        }

        public static bool CanDefeatDeathSword()
        {
            return HSL.HasSword()
                && CUU.CanUse(Item.Shadow_Crystal)
                && (
                    CUU.CanUse(Item.Boomerang)
                    || HBL.HasBow()
                    || CUU.CanUse(Item.Progressive_Clawshot)
                );
        }

        public static bool CanDefeatDarkhammer() => HDI.HasMeleeAltDamagingItem();

        public static bool CanDefeatPhantomZant()
        {
            return CUU.CanUse(Item.Shadow_Crystal) || HSL.HasSword();
        }
    }
}
