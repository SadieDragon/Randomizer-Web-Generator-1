using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class CanDoStuff
    {
        public static bool CanKnockDownHCPainting()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow)
                || (
                    SettingUtils.CanDoNicheStuff()
                    && (
                        BombUtils.HasBombs()
                        || (HasSwordLevel.HasSword() && HasHiddenSkillLevel.HasJumpStrike())
                    )
                )
                || (
                    SettingUtils.IsGlitchedLogic()
                    && (
                        (HasSwordLevel.HasSword() && GlitchedLogicUtils.CanDoMoonBoots())
                        || GlitchedLogicUtils.CanDoBSMoonBoots()
                    )
                );
        }

        public static bool CanBreakMonkeyCage()
        {
            return HasDamagingItemUtils.HasDamagingItemIClawshot()
                || CanUseUtils.CanUse(Item.Iron_Boots)
                || (SettingUtils.CanDoNicheStuff() && MiscItemUtils.CanShieldAttack());
        }

        public static bool CanPressMinesSwitch()
        {
            return CanUseUtils.CanUse(Item.Iron_Boots)
                || (SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Ball_and_Chain));
        }

        public static bool CanFreeAllMonkeys()
        {
            return CanBreakMonkeyCage()
                && (
                    CanUseUtils.CanUse(Item.Lantern)
                    || (
                        SettingUtils.IsKeysy()
                        && (BombUtils.HasBombs() || CanUseUtils.CanUse(Item.Iron_Boots))
                    )
                )
                && MiscItemUtils.CanBurnWebs()
                && CanUseUtils.CanUse(Item.Boomerang)
                && CanDefeatCommonEnemy.CanDefeatBokoblin()
                && (
                    (CanUseUtils.GetItemCount(Item.Forest_Temple_Small_Key) >= 4)
                    || SettingUtils.IsKeysy()
                );
        }

        public static bool CanKnockDownHangingBaba()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || CanUseUtils.CanUse(Item.Boomerang)
                || CanUseUtils.CanUse(Item.Slingshot);
        }

        public static bool CanBreakWoodenDoor()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                || HasSwordLevel.HasSword()
                || BombUtils.CanSmash()
                || NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanChangeTime()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                || ERLogicFunctions.HasReachedAnyRooms(RoomFunctions.timeFlowStages);
        }

        public static bool CanWarp()
        {
            return CanUseUtils.CanUse(Item.Shadow_Crystal)
                && ERLogicFunctions.HasReachedAnyRooms(RoomFunctions.WarpableStages);
        }

        // TODO: Move twilights into a file
        // TODO: Move MDH out into a story stuff file
        public static bool CanMidnaCharge()
        {
            return LogicFunctionsUpdatedRefactored.CanCompleteMDH()
                || LogicFunctionsUpdatedRefactored.CanCompleteAllTwilight();
        }
    }
}
