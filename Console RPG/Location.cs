using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location Ember_Town = new Location("Ember Town", "This town is the center of the Solar kingdom");
        public static Location ROBOSHARK1s_House = new Location("Roboshark1's house", "Home sweet Home.");
        public static Location Tent_shop = new Location("Tanoshi's shop", "It's a very festive shop", new Shop("Tanoshi", "Tanoshi's shop of wonders", new List<Item>() { HealthPotionItem.Crimson_Soda, ManaPotionItem.Mana_Cookie, Armor.hat, Weapon.Cleaver}));
        public static Location Cookies_House = new Location("Cookie's House", "His cookie jar always get stolen for some reason");
        public static Location Solar_Castle = new Location("Solar Castle", "The Grand castle of the Solar Kingdom");
        public static Location Arena = new Location("Grand Arena", "Its an arena for battle", new Battle(new List<Enemy>() {Enemy.Gladiator}));
        public static Location Dark_Forest = new Location("The Dark Forest", "Monsters lurk in those forests", new Battle(new List<Enemy>() {Enemy.Corpse_Screecher, Enemy.Undead_Brute, Enemy.Undead}));
        public static Location Forest = new Location("The forest", "Looks nice", new Battle(new List<Enemy>() { Enemy.slime, Enemy.Forest_golem }));
        public static Location Lake = new Location("Fishing Lake", "My dog likes to sit next to the lake and watch the sunset.", new Battle(new List<Enemy> { Enemy.Dummy}));
        public static Location Farm = new Location("Roboshark's Farm", "I like to make sure my animals are well fed as well as making sure my crops are growing well");
        public static Location Dungeon = new Location("Dungeon", "Its a dungeon", new Battle(new List<Enemy> { Enemy.Skeleton_Guard }));
        public static Location Treasure_room = new Location("Treasure room", "Its filled with treasure", new Battle(new List<Enemy> { Enemy.Mimic }));
        public static Location Dark_Castle = new Location("Dark Castle", "It intimidates you", new Battle(new List<Enemy> { Enemy.Skeleton_Guard, Enemy.Shadow_crawler, Enemy.Skeleton_Guard }));
        public static Location Elf_Village = new Location("Elf Village", "Its a village full of elves");
        public static Location Great_Tree = new Location("The Great Tree", "The Great tree of the elf village, its majestic", new Battle(new List<Enemy> { Enemy.Boulder}));
        public static Location Final_Destination = new Location("Final Destination", "The Final Battle", new Battle(new List<Enemy> { Enemy.Bowser}));

        public string name;
        public string description;
        public PointOfInterest interaction;

        public Location north, east, south, west;

        public Location(string name, string description, PointOfInterest interaction = null)
        {
            this.name = name;
            this.description = description;
            this.interaction = interaction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }
            
            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
        }

        public void Resolve(List<Player> players)
        {
            Console.WriteLine("You find yourself in " + this.name + ".");
            Console.WriteLine(this.description);

            // Null checking to make sure there is a battle to resolve.
            interaction?.Resolve(players);

            if (!(north is null))
                Console.WriteLine("NORTH: " + this.north.name);

            if (!(east is null))
                Console.WriteLine("EAST: " + this.east.name);

            if (!(south is null))
                Console.WriteLine("SOUTH: " + this.south.name);

            if (!(west is null))
                Console.WriteLine("WEST: " + this.west.name);

            string direction = Console.ReadLine();
            Location nextLocation = null;

            //What happens if the user doesn't give a proper input?

            if (direction == "north")
                nextLocation = this.north;
            else if (direction == "east")
                nextLocation = this.east;
            else if (direction == "south")
                nextLocation = this.south;
            else if (direction == "west")
                nextLocation = this.west;
            else
                this.Resolve(players);
            nextLocation.Resolve(players);
        }
    }
}
