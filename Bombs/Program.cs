using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> effects = new Queue<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> casings = new Stack<int>(
               Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeBombs = 0;

            while(effects.Count > 0 && casings.Count > 0)
            {

                int combined = effects.Peek() + casings.Peek();
                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    break;
                }
                    

                if (combined == 40)
                {
                    daturaBombs++;
                    effects.Dequeue();
                    casings.Pop();
                }

                else if(combined == 60)
                {
                    cherryBombs++;
                    effects.Dequeue();
                    casings.Pop();
                }

                else if(combined == 120)
                {
                    smokeBombs++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    int prevCasingValue = casings.Peek();
                    int nextCasingValue = prevCasingValue - 5;
                    casings.Pop();
                    casings.Push(nextCasingValue);
                }

            }

            //Printing: (There are not used curly braces for if/else statements for more clear view during the solution process)

            if(daturaBombs < 3 || cherryBombs < 3 || smokeBombs < 3)                                  
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
           
            if(effects.Count == 0)
                Console.WriteLine("Bomb Effects: empty");           
            else           
                Console.WriteLine("Bomb Effects: " + string.Join(", ", effects));


            if (casings.Count == 0)
                Console.WriteLine("Bomb Casings: empty");
            else
                Console.WriteLine("Bomb Casings: " + string.Join(", ", casings));

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombs}");



        }
    }
}
