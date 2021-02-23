using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {


            Stack<int> lilies = new Stack<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> sums = new List<int>();
            int countWreaths = 0;


            while (true)
            {
                if(lilies.Count == 0 || roses.Count == 0)
                {
                    break;
                }

                if (lilies.Peek() + roses.Peek() == 15)
                {
                    countWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }

                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    int decreasedLilie = lilies.Peek() - 2;
                    lilies.Pop();
                    lilies.Push(decreasedLilie);
                }

                else if (lilies.Peek() + roses.Peek() < 15)
                {
                    int sum = lilies.Peek() + roses.Peek();
                    sums.Add(sum);
                    lilies.Pop();
                    roses.Dequeue();
                }     
            }


            countWreaths += sums.Sum() / 15;


            //Printing:
            if (countWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countWreaths} wreaths more!");
            }


        }
    }
}
