using System.Linq;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class GlitchedLogicUtils
    {
        /// <summary>
        /// Check for sword or Back Slice (aka fake sword)
        /// </summary>
        public static bool HasSwordOrBS()
        {
            return HasSwordLevel.HasSword() || HasHiddenSkillLevel.HasBackslice();
        }

        /// <summary>
        /// Check for heavy mod (boots or MA)
        /// </summary>
        public static bool HasHeavyMod()
        {
            return CanUseUtils.CanUse(Item.Iron_Boots) || CanUseUtils.CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for cutscene item (useful for cutscene dropping a bomb in specific spot)
        /// </summary>
        public static bool HasCutsceneItem()
        {
            return CanUseUtils.CanUse(Item.Progressive_Sky_Book)
                || BottleUtils.HasBottle()
                || CanUseUtils.CanUse(Item.Horse_Call);
        }

        /// <summary>
        /// Check for if you have any one-handed item
        /// </summary>
        public static bool HasOneHandedItem()
        {
            return HasSwordLevel.HasSword()
                || BottleUtils.HasBottle()
                || CanUseUtils.CanUse(Item.Boomerang)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || CanUseUtils.CanUse(Item.Lantern)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Dominion_Rod);
        }

        public static int GetItemWheelSlotCount()
        {
            return Randomizer.Items.ItemWheelItems.Count(CanUseUtils.CanUse);
        }

        public static bool CanEquipOverBoots()
        {
            return CanUseUtils.CanUse(Item.Iron_Boots) && (GetItemWheelSlotCount() >= 3);
        }

        public static bool HasMagicArmorOrCanEquipOverBoots()
        {
            return CanUseUtils.CanUse(Item.Magic_Armor) || CanEquipOverBoots();
        }

        /// <summary>
        /// Check for if you can do LJAs
        /// </summary>
        public static bool CanDoLJA()
        {
            return HasSwordLevel.HasSword() || CanUseUtils.CanUse(Item.Boomerang);
        }

        /// <summary>
        /// Check for if you can do Jump Strike LJAs
        /// </summary>
        public static bool CanDoJSLJA()
        {
            return CanDoLJA() && HasHiddenSkillLevel.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Map Glitch
        /// </summary>
        public static bool CanDoMapGlitch()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                && ERLogicFunctions.HasReachedRoom("Kakariko Gorge");
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
            return HasSwordLevel.HasSword() && HasMagicArmorOrCanEquipOverBoots();
        }

        /// <summary>
        /// Check for if you can do Jump Strike Moon Boots
        /// </summary>
        public static bool CanDoJSMoonBoots()
        {
            return CanDoMoonBoots() && HasHiddenSkillLevel.HasJumpStrike();
        }

        /// <summary>
        /// Check for if you can do Back Slice Moon Boots
        /// </summary>
        public static bool CanDoBSMoonBoots()
        {
            return HasHiddenSkillLevel.HasBackslice() && CanUseUtils.CanUse(Item.Magic_Armor);
        }

        /// <summary>
        /// Check for if you can do Ending Blow Moon Boots
        /// </summary>
        public static bool CanDoEBMoonBoots()
        {
            return CanDoMoonBoots()
                && HasHiddenSkillLevel.HasEndingBlow()
                && HasSwordLevel.HasOrdonSword();
        }

        /// <summary>
        /// Check for if you can do Helm Splitter Moon Boots
        /// </summary>
        public static bool CanDoHSMoonBoots()
        {
            return CanDoMoonBoots()
                && HasHiddenSkillLevel.HasHelmSplitter()
                && HasSwordLevel.HasSword()
                && MiscItemUtils.HasShield();
        }

        /// <summary>
        /// Check for if you can do The Amazing Fly Glitch™
        /// </summary>
        public static bool CanDoFlyGlitch()
        {
            return CanUseUtils.CanUse(Item.Progressive_Fishing_Rod) && HasHeavyMod();
        }

        /// <summary>
        /// Check for if you can swim with Water Bombs
        /// </summary>
        public static bool CanDoAirRefill()
        {
            return BombUtils.CanUseWaterBombs() && HasMagicArmorOrCanEquipOverBoots();
        }
    }
}
