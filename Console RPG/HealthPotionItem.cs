using System;

namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public static HealthPotionItem Crimson_Soda = new HealthPotionItem("ROBOSHARK1's Crimson Soda", "Taste like cherries.", 12, 50, 50);

        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description,shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
            Console.WriteLine($"You used {name} , you recovered {healAmount} HP");
        }
    }
}
