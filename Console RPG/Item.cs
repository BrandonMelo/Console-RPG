using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public static HealthPotionItem Crimson_Soda = new HealthPotionItem("ROBOSHARK1's Crimson Soda", "Taste like cherries.", 12, 50, 50);
        public string name;
        public string description;

        public int shopPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;
        }

        public abstract void Use(Entity user, Entity target);
    }
}
