using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {


            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> combinedItems = new List<int>();



            while(true)
            {
                if(firstLootBox.Count == 0 || secondLootBox.Count == 0)
                {
                    break;
                }

                int sumOfElements = firstLootBox.Peek() + secondLootBox.Peek();
                if(sumOfElements % 2 == 0)
                {
                    combinedItems.Add(sumOfElements);
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    int removedItemSecondBox = secondLootBox.Pop();
                    firstLootBox.Enqueue(removedItemSecondBox);
                }
            }


            //Printing:

            if(firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (combinedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {combinedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {combinedItems.Sum()}");
            }

        }
    }
}
