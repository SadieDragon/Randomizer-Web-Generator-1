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

        public static bool HasAnyDamagingItem(List<Item> listOfItems)
        {
            return listOfItems.Any(CUU.CanUse);
        }

        public static bool HasBaseDamagingItem()
        {
            return HasAnyDamagingItem(BaseDIList);
        }

        // TODO: better name
        public static bool HasDamagingItem(bool includeBombs = true, List<Item> extraItems = null)
        {
            extraItems ??= new List<Item>(); // Use a blank list if none provided

            return HasBaseDamagingItem()
                || HSL.HasSword()
                || (includeBombs && BU.HasBombs())
                || HasAnyDamagingItem(extraItems);
        }

        public static bool HasDamagingItemOrClawshot(bool includeBombs = true)
        {
            return HasDamagingItem(includeBombs, [Item.Progressive_Clawshot]);
        }

        public static bool HasDamagingItemOrSlingshot(bool includeBombs = true)
        {
            return HasDamagingItem(includeBombs, [Item.Slingshot]);
        }
    }
}
