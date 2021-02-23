using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());
            int threadKiller = 0;

            //1. Tasks...
            //2. Threads...

            while(true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if(currentThread >= currentTask)
                {
                    if(currentTask == taskToBeKilled)
                    {
                        threadKiller = currentThread;
                        break;
                    }
                    else
                    {
                        tasks.Pop();
                        threads.Dequeue();
                    }            
                }
                else
                {
                    if (currentTask == taskToBeKilled)
                    {
                        threadKiller = currentThread;
                        break;
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                    
                }
            }


            //Printing:
            Console.WriteLine($"Thread with value {threadKiller} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));

        }
    }
}
