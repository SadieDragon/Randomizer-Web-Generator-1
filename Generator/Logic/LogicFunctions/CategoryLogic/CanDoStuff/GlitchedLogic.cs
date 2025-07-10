using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using HSL = LogicFunctionsNS.HasSwordLevel;

// CanDefeatBombling or CanSmash repeated often in FT

namespace LogicFunctionsNS.GlitchedLogic
{
    public class CanDoStuff
    {
        public static bool CanKnockDownHCPainting()
        {
            return SettingUtils.IsGlitchedLogic()
                && ((HSL.HasSword() && GLU.CanDoMoonBoots()) || GLU.CanDoBSMoonBoots());
        }

        /// <summary>
        /// Check for if you need the key for getting to Lakebed Deku Toad
        ///
        public static bool CanSkipKeyToDekuToad()
        {
            return (Randomizer.SSettings.smallKeySettings == SmallKeySettings.Keysy)
                || HHSL.HasBackslice()
                || GLU.CanDoBSMoonBoots()
                || GLU.CanDoJSMoonBoots()
                || GLU.CanDoLJA()
                || (BU.HasBombs() && (GLU.HasHeavyMod() || HHSL.HasJumpStrike()));
        }

        /// <summary>
        /// Check for if you can do Hidden Village (glitched)
        /// </summary>
        public static bool CanDoHiddenVillageGlitched()
        {
            return CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Ball_and_Chain)
                || (
                    CUU.CanUse(Item.Slingshot)
                    && (
                        CUU.CanUse(Item.Shadow_Crystal)
                        || HSL.HasSword()
                        || BU.HasBombs()
                        || CUU.CanUse(Item.Iron_Boots)
                        || CUU.CanUse(Item.Spinner)
                    )
                );
        }

        /// <summary>
        /// Check for if you can get passed FT windless bridge room (glitched)
        /// </summary>
        public static bool CanDoFTWindlessBridgeRoom()
        {
            return BU.HasBombs() || GLU.CanDoBSMoonBoots() || GLU.CanDoJSMoonBoots();
        }

        public static bool CanClearForestGlitched()
        {
            return (Randomizer.SSettings.faronWoodsLogic == FaronWoodsLogic.Open)
                || GLU.CanDoLJA()
                || GLU.CanDoMapGlitch();
        }
    }
}
