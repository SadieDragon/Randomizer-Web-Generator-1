using System.Linq;
using TPRandomizer;
using BOU = LogicFunctionsNS.BottleUtils;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;

namespace LogicFunctionsNS
{
    public class GlitchedLogicUtils
    {
        /// <summary>
        /// Check for sword or Back Slice (aka fake sword)
        /// </summary>
        public static bool HasSwordOrBS()
        {
            return HSL.HasSword() || HHSL.HasBackslice();
        }

        /// <summary>
        /// Check for heavy mod (boots or MA)
        /// </summary>
        public static bool HasHeavyMod()
        {
            return CUU.CanUse(Item.Iron_Boots) || CUU.CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for cutscene item (useful for cutscene dropping a bomb in specific spot)
        /// </summary>
        public static bool HasCutsceneItem()
        {
            return CUU.CanUse(Item.Progressive_Sky_Book)
                || BOU.HasBottle()
                || CUU.CanUse(Item.Horse_Call);
        }

        /// <summary>
        /// Check for if you have any one-handed item
        /// </summary>
        public static bool HasOneHandedItem()
        {
            return HSL.HasSword()
                || BOU.HasBottle()
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Lantern)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Progressive_Dominion_Rod);
        }

        public static int GetItemWheelSlotCount()
        {
            return Randomizer.Items.ItemWheelItems.Count(CUU.CanUse);
        }

        public static bool CanEquipOverBoots()
        {
            return CUU.CanUse(Item.Iron_Boots) && (GetItemWheelSlotCount() >= 3);
        }

        public static bool HasMagicArmorOrCanEquipOverBoots()
        {
            return CUU.CanUse(Item.Magic_Armor) || CanEquipOverBoots();
        }

        /// <summary>
        /// Check for if you can do LJAs
        /// </summary>
        public static bool CanDoLJA()
        {
            return HSL.HasSword() || CUU.CanUse(Item.Boomerang);
        }

        /// <summary>
        /// Check for if you can do Jump Strike LJAs
        /// </summary>
        public static bool CanDoJSLJA()
        {
            return CanDoLJA() && HHSL.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Map Glitch
        /// </summary>
        public static bool CanDoMapGlitch()
        {
            return CUU.CanUse(Item.Shadow_Crystal) && ERLF.HasReachedRoom("Kakariko Gorge");
        }

        /// <summary>
        /// Check for if you can do storage (aka Reverse Door Adventure (RDA)). Note: Needs a one-handed item
        /// </summary>
        public static bool CanDoStorage()
        {
            return CanDoMapGlitch() && HasOneHandedItem();
        }

        /// <summary>
        /// Check for if you can do Moon Boots
        /// </summary>
        public static bool CanDoMoonBoots()
        {
            return HSL.HasSword() && HasMagicArmorOrCanEquipOverBoots();
        }

        /// <summary>
        /// Check for if you can do Jump Strike Moon Boots
        /// </summary>
        public static bool CanDoJSMoonBoots()
        {
            return CanDoMoonBoots() && HHSL.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Back Slice Moon Boots
        /// </summary>
        public static bool CanDoBSMoonBoots()
        {
            return HHSL.HasBackslice() && CUU.CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for if you can do Ending Blow Moon Boots
        /// </summary>
        public static bool CanDoEBMoonBoots()
        {
            return CanDoMoonBoots() && HHSL.HasEndingBlow() && HSL.HasOrdonSword();
        }

        /// <summary>
        /// Check for if you can do Helm Splitter Moon Boots
        /// </summary>
        public static bool CanDoHSMoonBoots()
        {
            return CanDoMoonBoots() && HHSL.HasHelmSplitter() && HSL.HasSword() && MIU.HasShield();
        }

        /// <summary>
        /// Check for if you can do The Amazing Fly Glitch™
        /// </summary>
        public static bool CanDoFlyGlitch()
        {
            return CUU.CanUse(Item.Progressive_Fishing_Rod) && HasHeavyMod();
        }

        /// <summary>
        /// Check for if you can swim with Water Bombs
        /// </summary>
        public static bool CanDoAirRefill()
        {
            return BU.CanUseWaterBombs() && HasMagicArmorOrCanEquipOverBoots();
        }
    }
}
