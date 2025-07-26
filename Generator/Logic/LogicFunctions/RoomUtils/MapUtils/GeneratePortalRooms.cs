using System;
using System.Collections.Generic;
using LogicFunctionsNS.AggregateLogic;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class PortalRooms
    {
        public static List<Room> GeneratePortalRooms()
        {
            // Console.WriteLine("Generating the portal rooms.");

            List<Room> portalRooms = [];

            // If we cannot warp, then we cannot use portals anyway.
            if (!CanDoStuff.CanWarp())
            {
                // Console.WriteLine("Cannot warp; did not generate any portal rooms.");
                return portalRooms;
            }

            // Helper function to wrap the foreach loop
            // Essentially, using a dict is like saying "if this key, then add this value" in this case,
            //   with less if statements.
            // Furthermore, I am checking within the function if the map can be unlocked, further reducing
            //   repeated if statements.
            void AddToPortalRooms(
                Func<bool> canUnlockMap,
                params (Item portal, string room)[] entries
            )
            {
                // TODO: Can I move the `canUnlockMap` function in here? Is it needed anywhere else? - Lupa
                if (!canUnlockMap())
                {
                    // Console.WriteLine(
                    //     $"Cannot access this map, not adding rooms for it. {canUnlockMap}"
                    // );
                    return;
                }

                foreach (var (portal, room) in entries)
                {
                    // Console.WriteLine($"{portal} being checked, which maps to {room}");
                    if (CanUseUtils.CanUse(portal))
                    {
                        // Console.WriteLine($"Added {room} to the entry.");
                        portalRooms.Add(Randomizer.Rooms.RoomDict[room]);
                    }
                }
            }

            // With sewers no longer a thing, the player starts with Ordon Portal (until we find a way to randomize it)
            // AddToPortalRooms(LogicFunctions.CanUnlockOrdonaMap(), (Item.Ordon_Portal, "Ordon Spring"));
            if (CanUnlockMap.CanUnlockOrdonaMap())
            {
                portalRooms.Add(Randomizer.Rooms.RoomDict["Ordon Spring"]);
            }

            // Faron
            AddToPortalRooms(
                CanUnlockMap.CanUnlockFaronMap,
                (Item.South_Faron_Portal, "South Faron Woods"),
                (Item.North_Faron_Portal, "North Faron Woods"),
                (Item.Sacred_Grove_Portal, "Sacred Grove Lower")
            );

            // Eldin
            AddToPortalRooms(
                CanUnlockMap.CanUnlockEldinMap,
                (Item.Kakariko_Village_Portal, "Lower Kakariko Village"),
                (Item.Kakariko_Gorge_Portal, "Kakariko Gorge"),
                (Item.Death_Mountain_Portal, "Death Mountain Volcano"),
                (Item.Bridge_of_Eldin_Portal, "Eldin Field")
            );

            // Lanayru
            AddToPortalRooms(
                CanUnlockMap.CanUnlockLanayruMap,
                (Item.Lake_Hylia_Portal, "Lake Hylia"),
                (Item.Castle_Town_Portal, "Outside Castle Town West"),
                (Item.Zoras_Domain_Portal, "Zoras Domain Throne Room"),
                (Item.Upper_Zoras_River_Portal, "Upper Zoras River")
            );

            // Snowpeak
            AddToPortalRooms(
                CanUnlockMap.CanUnlockSnowpeakMap,
                (Item.Snowpeak_Portal, "Snowpeak Summit Upper")
            );

            // Desert
            AddToPortalRooms(
                CanUnlockMap.CanUnlockGerudoMap,
                (Item.Gerudo_Desert_Portal, "Gerudo Desert Cave of Ordeals Plateau"),
                (Item.Mirror_Chamber_Portal, "Mirror Chamber Upper")
            );

            // Console.WriteLine($"{portalRooms}");
            return portalRooms;
        }
    }
}
