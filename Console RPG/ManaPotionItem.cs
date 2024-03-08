using System;

namespace Console_RPG
{
    class ManaPotionItem : Item
    {
        public static ManaPotionItem Mana_Cookie = new ManaPotionItem("Cookies special cookie", "It seems to be stolen", 20, 10, 20);

        public int manaRestor;

        public ManaPotionItem(string name, string description, int shopPrice, int maxAmount, int manaRestor) : base(name, description, shopPrice, maxAmount)
        {
            this.manaRestor = manaRestor;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentMana += this.manaRestor;
            Console.WriteLine($"You used {name} , you restored {manaRestor} MP");
        }
    }
}
