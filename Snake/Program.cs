using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];  //Square matrix

            int snakeRow = -1;
            int snakeCol = -1;

            int firstBurrowRow = -1;
            int firstBurrowCol = -1;

            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            int foodQuantity = 0;
            int lastSnakePos = -1;


            //I part:
            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                string inputLine = Console.ReadLine();

                for (int colIndex = 0; colIndex < inputLine.Length; colIndex++)
                {
                    matrix[rowIndex, colIndex] = inputLine[colIndex];
                    if (matrix[rowIndex, colIndex] == 'S')
                    {
                        snakeRow = rowIndex;
                        snakeCol = colIndex;
                    }
                    else if (matrix[rowIndex, colIndex] == 'B' && firstBurrowRow == -1 && firstBurrowCol == -1)
                    {
                        firstBurrowRow = rowIndex;
                        firstBurrowCol = colIndex;
                    }
                    else if (matrix[rowIndex, colIndex] == 'B' && firstBurrowRow != -1 && firstBurrowCol != -1)
                    {
                        secondBurrowRow = rowIndex;
                        secondBurrowCol = colIndex;
                    }
                }
            }




            //II part:
            string command = Console.ReadLine();


            matrix[snakeRow, snakeCol] = '.';

            while (true)
            {
                          
                if (command == "up")
                {
                    snakeRow--;            
                }

                else if (command == "down")
                {
                    snakeRow++;                  
                }

                else if (command == "left")
                {
                    snakeCol--;             
                }

                else if (command == "right")
                {
                    snakeCol++;                 
                }


                if(!IsValidCoordinate(snakeRow, snakeCol, matrixSize))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if(matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }

                if (foodQuantity >= 10)
                {
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }


                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;                     
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;                      
                    }
                }

                matrix[snakeRow, snakeCol] = '.';

                command = Console.ReadLine();
            }


            //Printing:

            if (foodQuantity == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodQuantity}");
            }
            else
            {
                Console.WriteLine($"Food eaten: {foodQuantity}");
            }

            PrintMatrix(matrix);

        }




        static bool IsValidCoordinate(int snakeRow, int snakeCol, int matrixSize)
        {
            if (snakeRow < matrixSize && snakeRow >= 0 && snakeCol < matrixSize && snakeCol >= 0)
                return true;

            return false;
        }






        static void PrintMatrix(char[,] martrix)
        {
            for (int row = 0; row < martrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < martrix.GetLongLength(1); col++)
                {
                    Console.Write(martrix[row, col]);
                }
                Console.WriteLine();
            }
        }



    }
}
