using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Queue<int[]> validCoordinates = new Queue<int[]>();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            int[,] matrix = InitMatrix(rows, cols);


            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {

                int[] cmdLineArgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int rowCoordinate = cmdLineArgs[0];
                int colCoordinate = cmdLineArgs[1];

                if (rowCoordinate < 0 || rowCoordinate > rows || colCoordinate < 0 || colCoordinate > cols)
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                else
                {
                    matrix[rowCoordinate, colCoordinate] += 1;
                    validCoordinates.Enqueue(new int[] { rowCoordinate, colCoordinate });
                }

                command = Console.ReadLine();

            }

            foreach (int[] coord in validCoordinates)
            {

                BloomFlowers(matrix, coord[0], coord[1]);
            }



            //For debugging
            PrintMatrix(matrix);

        }



        static int[,] InitMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            return matrix;
        }



        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }


        static void BloomFlowers(int[,] matrix, int rowCoordinate, int colCoordinate)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == rowCoordinate)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (col != colCoordinate)
                        {
                            matrix[row, col] += 1;
                        }
                    }
                }
                else
                {
                    continue;
                }

            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == colCoordinate && row != rowCoordinate)
                    {
                        matrix[row, col] += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

           

        }






    }
}
