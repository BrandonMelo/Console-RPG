using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float durability;
        public float weight;
        public float rarity;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, float durability, float weight, float rarity) : base(name, description, shopPrice, sellPrice)
        {
            this.durability = durability;
            this.weight = weight;
            this.rarity = rarity;
            this.isEquipped = false;
        }
    }

    class Armor : Equipment
    {
        public int defense;
        public static Armor hat = new Armor("hat", "Warning: This hat will lower your defense.", 50, 25, 10, 1, 1, 10);
        public Armor(string name, string description, int shopPrice, int sellPrice, float durability, float weight, float rarity, int defense) : base(name, description, shopPrice, sellPrice, durability, weight, rarity)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, Entity target)
        {
            // Flip the value of whether or not it's equipped.
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                // Increase the target's defense if they equip the item.
                target.stats.defense += this.defense;
                Console.WriteLine($"You equipped {this.name}. You gained {this.defense} defense.");
            }
            else
            {
                // Decreases the target's defense if they equip the item.
                target.stats.defense -= this.defense;
            }
        }
    }

    class Weapon : Equipment
    {
        public int damage;

        public static Weapon Cleaver = new Weapon("Butchers cleaver", "It's a powerful item.", 100, 50, 1000000, 1, 10, 1500);
        public Weapon(string name, string description, int shopPrice, int sellPrice, float durability, float weight, float rarity, int damage) : base(name, description, shopPrice, sellPrice, durability, weight, rarity)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            // Flip the value of whether or not it's equipped.
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                // Increase the target's defense if they equip the item.
                target.stats.strength += this.damage;
                Console.WriteLine($"You equipped {this.name}. You gained {this.damage} attack power.");
            }
            else
            {
                // Decreases the target's defense if they equip the item.
                target.stats.strength -= this.damage;
            }
        }
    }
}
