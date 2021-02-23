using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int breads = 0;
            int cakes = 0;
            int pastrys = 0;
            int fruitPies = 0;

            while(true)
            {

                if(liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }

                int combined = liquids.Peek() + ingredients.Peek();

                if(combined == 25)
                {
                    breads++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }

                else if(combined == 50)
                {
                    cakes++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }

                else if (combined == 75)
                {
                    pastrys++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }

                else if (combined == 100)
                {
                    fruitPies++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }

                else
                {
                    liquids.Dequeue();
                    int topElement = ingredients.Pop();
                    ingredients.Push(topElement + 3);
                }
            }

            //Printing:

            if(breads >= 1 && cakes >= 1 && pastrys >= 1 && fruitPies >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }


            if(liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", liquids));
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine("Ingredients left: " + string.Join(", ", ingredients));
            }


            Console.WriteLine($"Bread: {breads}");
            Console.WriteLine($"Cake: {cakes}");
            Console.WriteLine($"Fruit Pie: {fruitPies}");
            Console.WriteLine($"Pastry: {pastrys}");



        }
    }
}
