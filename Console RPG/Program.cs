using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // West is left, east is right
            Location.Ember_Town.SetNearbyLocations(north: Location.Solar_Castle, south: Location.Tent_shop, east: Location.ROBOSHARK1s_House, west: Location.Cookies_House);
            Location.ROBOSHARK1s_House.SetNearbyLocations(west: Location.Ember_Town, east: Location.Arena, north: Location.Lake, south: Location.Farm);
            Location.Solar_Castle.SetNearbyLocations(south: Location.Ember_Town);
            Location.Cookies_House.SetNearbyLocations(east: Location.Ember_Town , west: Location.Dark_Forest);
            Location.Arena.SetNearbyLocations(east: Location.Forest , west: Location.ROBOSHARK1s_House);
            Location.Lake.SetNearbyLocations(south: Location.ROBOSHARK1s_House);
            Location.Farm.SetNearbyLocations(north: Location.ROBOSHARK1s_House);
            Location.Forest.SetNearbyLocations(west: Location.Arena, north: Location.Elf_Village);
            Location.Dark_Forest.SetNearbyLocations(east: Location.Cookies_House, south: Location.Dungeon, north: Location.Dark_Castle);
            Location.Dungeon.SetNearbyLocations(east: Location.Treasure_room, north: Location.Dark_Forest);
            Location.Treasure_room.SetNearbyLocations(west: Location.Dungeon);
            Location.Dark_Castle.SetNearbyLocations(south: Location.Dark_Forest, north: Location.Final_Destination);
            Location.Elf_Village.SetNearbyLocations(south: Location.Forest, north: Location.Great_Tree);
            Location.Great_Tree.SetNearbyLocations(south: Location.Elf_Village);
            Location.Final_Destination.SetNearbyLocations(south: Location.Dark_Castle);
            Location.Ember_Town.Resolve(new List<Player>() { Player.ROBOSHARK1 });

        }
    }
}
