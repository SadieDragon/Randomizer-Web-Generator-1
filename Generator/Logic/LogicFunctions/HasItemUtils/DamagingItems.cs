using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using HSL = LogicFunctionsNS.HasSwordLevel;

namespace LogicFunctionsNS
{
    public class DamagingItems
    {
        public DamagingItems()
        {
            BaseDIList =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Shadow_Crystal,
                Item.Spinner,
            ];
        }

        private static List<Item> baseDIList;
        public static List<Item> BaseDIList
        {
            get { return baseDIList; }
            set { baseDIList = value; }
        }

        public static bool HasAnyDamagingItem(List<Item> ListOfItems)
        {
            return ListOfItems.Any(CUU.CanUse);
        }

        public static bool HasBaseDamagingItem()
        {
            return HasAnyDamagingItem(BaseDIList);
        }

        // TODO: better name
        public static bool HasDamagingItem(
            bool IncludeSword = true,
            bool IncludeBombs = true,
            List<Item> ExtraItems = null
        )
        {
            ExtraItems ??= new List<Item>(); // Use a blank list if none provided

            return HasBaseDamagingItem()
                || (IncludeSword && HSL.HasSword())
                || (IncludeBombs && BU.HasBombs())
                || HasAnyDamagingItem(ExtraItems);
        }

        public static bool HasDamagingItemOrClawshot(
            bool IncludeSword = true,
            bool IncludeBombs = true
        )
        {
            return HasDamagingItem(IncludeSword, IncludeBombs, [Item.Progressive_Clawshot]);
        }

        public static bool HasDamagingItemOrSlingshot(
            bool IncludeSword = true,
            bool IncludeBombs = true
        )
        {
            return HasDamagingItem(IncludeSword, IncludeBombs, [Item.Slingshot]);
        }
    }
}
