using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : PointOfInterest
    {
        public string ownerName;
        public string shopName;
        public List<Item> items;

        public Shop(string ownerName, string shopName, List<Item> items) : base(false)
        {
            this.ownerName = ownerName;
            this.shopName = shopName;
            this.items = items;
        }

        public override void Resolve(List<Player> players)
        {
            Console.WriteLine($"Welcome to {shopName}!");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("BUY | SELL | TALK | LEAVE");
                string userInput = Console.ReadLine();
                if (userInput == "buy")
                {
                    Item item = ChooseItem(this.items);
                    Player.CoinCount -= item.shopPrice;
                    Player.Inventory.Add(item);

                    Console.WriteLine($"You bought {item.name}!");
                }
                else if (userInput == "sell")
                {
                    Item item = ChooseItem(Player.Inventory);
                    Player.CoinCount += item.shopPrice;
                    Player.Inventory.Remove(item);

                    Console.WriteLine($"You sold {item.name}!");
                }
                else if (userInput == "talk")
                {
                    Console.WriteLine("Yknow, I used to be one of the weakest members in my tribe which belongs to the majin race who were known as the weakest race and magic users since we can only use illusion magic but it was considered as the most useless and weakest form of magic of where im from. But that changed when i met someone named lilith, now my illusion magic is the most strongest since it can become phycial illusions.");
                }
                else if (userInput == "leave")
                {
                    break;
                }
            }

            Console.WriteLine("Come back later");
        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to buy:");

            // Iterate through each of the choices.
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} (${choices[i].shopPrice}) ({choices[i].description})");
            }

            // Let user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
}
