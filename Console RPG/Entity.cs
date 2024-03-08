using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    // Structs are useful for storing simple plain data.
    struct Stats
    {
        public int strength;
        public int defense;
        public int agility;

        public Stats(int strength, int defense, int agility)
        {
            this.strength = strength;
            this.defense = defense;
            this.agility = agility;
        }
    }

    // Classes are useful for storing complex objects.
    abstract class Entity
    {
        public string name;

        public int currentHP, maxHP;
        public int currentMana, maxMana;

        // This is called composition. Composition is awesome!
        public Stats stats;

        public Entity(string name, int hp, int mana, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currentMana = mana;
            this.maxMana = mana;
            this.stats = stats;
        }

        // Abstract functions can be overriden by their derived class.
        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> choices);
        public abstract void Attack(Entity target);

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
}
