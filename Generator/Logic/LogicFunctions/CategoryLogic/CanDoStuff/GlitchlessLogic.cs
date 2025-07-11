using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using HBL = LogicFunctionsNS.HasQuiverSize;
using HDI = LogicFunctionsNS.DamagingItems;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;

namespace LogicFunctionsNS.GlitchlessLogic
{
    public class CanDoStuff
    {
        public static bool CanKnockDownHCPainting() => HBL.HasBow();

        public static bool CanBreakMonkeyCage()
        {
            return HDI.HasMeleeAltDamagingItem()
                || CUU.CanUse(Item.Iron_Boots)
                || CUU.CanUse(Item.Spinner)
                || CUU.CanUse(Item.Progressive_Clawshot);
        }

        public static bool CanPressMinesSwitch() => CUU.CanUse(Item.Iron_Boots);

        public static bool CanFreeAllMonkeys()
        {
            return MIU.CanBurnWebs()
                && CUU.CanUse(Item.Boomerang)
                && (SettingUtils.IsKeysy() || (CUU.GetItemCount(Item.Forest_Temple_Small_Key) >= 4))
                && (
                    CUU.CanUse(Item.Lantern)
                    || (SettingUtils.IsKeysy() && (BU.HasBombs() || CUU.CanUse(Item.Iron_Boots)))
                );
        }

        public static bool CanKnockDownHangingBaba()
        {
            return CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Slingshot);
        }

        public static bool CanBreakWoodenDoor()
        {
            return CUU.CanUse(Item.Shadow_Crystal) || HSL.HasSword() || BU.CanSmash();
        }
    }
}
