using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    // This class derives from Entity!
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() { ManaPotionItem.Mana_Cookie, HealthPotionItem.Crimson_Soda};
        public static int CoinCount = 500;

        public static Player ROBOSHARK1 = new Player("ROBOSHARK1", 500, 1000, new Stats(150, 250, 20), 50);

        public int level;

        public Player(string name, int hp, int mana, Stats stats, int level) : base(name, hp, mana, stats)
        {
            this.level = level;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("Type in the number of which enemy you want to target.");
            // Iterate through each of the choices.
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            if (index <0 || index > choices.Count)
            {
                Console.WriteLine("No such enemy exist.");
                return ChooseTarget(choices);
            }

            return choices[index - 1];
        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to use:");

            // Iterate through each of the choices.
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            // Let user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public override void Attack(Entity target)
        {
            // You guys figure out how to calculate the damage and subtract from the target's hp.
            int damage = this.stats.strength - target.stats.defense;
            int hp = target.currentHP -= damage;
            Console.WriteLine($"{this.name} attacked {target.name} for {damage} and now has {hp} hp!");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("ATTACK | ITEM");
            string choice = Console.ReadLine();

            if (choice == "attack")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }

            else if (choice == "item")
            {
                Item item = ChooseItem(Inventory);
                Entity target = ChooseTarget(players.Cast<Entity>().ToList());

                item.Use(this, target);
                Inventory.Remove(item);
            }
        }
    }
}
