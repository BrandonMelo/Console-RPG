using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    // This class also derives from Entity!
    class Enemy : Entity
    {
        public static Enemy slime = new Enemy("Slime", 20, 10, new Stats(251, 5, 2), 5); // 1
        public static Enemy Gladiator = new Enemy("Gladiator", 150, 5, new Stats(300, 100, 15), 50); // 50
        public static Enemy Corpse_Screecher = new Enemy("Corpse Screecher", 300, 500, new Stats(370, 150, 100), 250); // 120
        public static Enemy Undead_Brute = new Enemy("Undead Brute", 200, 50, new Stats(550, 500, 15), 50); // 300
        public static Enemy Undead = new Enemy("Undead", 100, 0, new Stats(300, 50, 40), 25); // 50
        public static Enemy Forest_golem = new Enemy("Forest Golem", 555, 1000, new Stats(650, 200, 5), 500); // 400
        public static Enemy Mimic = new Enemy("Chest mimic", 50, 100, new Stats(500, 1000, 2), 1500); // 250
        public static Enemy Skeleton_Guard = new Enemy("Skeleton Guard", 230, 250, new Stats(385, 45, 50), 20); // 135
        public static Enemy Shadow_crawler = new Enemy("Shadow Crawler", 200, 200, new Stats(350, 25, 100), 30); // 100
        public static Enemy Bowser = new Enemy("Bowser", 1500, 2000, new Stats(550, 500, 15), 2500); // 300
        public static Enemy Dummy = new Enemy("Dummy", 125000, 0, new Stats(250, 0, 0), 0); // 0
        public static Enemy Boulder = new Enemy("Boulder", 125000, 0, new Stats(250, 100, 0), 0); // 0

        public int coinsDroppedOnDefeated;

        public Enemy(string name, int hp, int mana, Stats stats, int coinsDroppedOnDefeated) : base(name, hp, mana, stats)
        {
            this.coinsDroppedOnDefeated = coinsDroppedOnDefeated;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
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
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
