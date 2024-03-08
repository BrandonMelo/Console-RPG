using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Battle : PointOfInterest
    {
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players)
        {
            if(this.isResolved)
            {
                return;
            }
            // Loop the turn system.
            while (true)
            {
                // Loop through all the players
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.WriteLine("It is " + player.name + "'s turn.");
                        player.DoTurn(players, enemies);
                    }
                }

                // Loop through all the enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It is " + enemy.name + "'s turn.");
                        enemy.DoTurn(players, enemies);
                    }
                }

                // If the player loose...
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("G A M E  O V E R");
                    break;
                }

                // If the players win...
                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine("The enemy has fallen");
                    this.isResolved = true;
                    break;
                }
            }

            //Put any code here that should happen regardless of who wins.
            Console.WriteLine("Battle over!");
        }
    }
}
