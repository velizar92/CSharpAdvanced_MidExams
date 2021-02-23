using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int shoperRow = -1;
            int shoperCol = -1;
            int firstPillarRow = -1;
            int firstPillarCol =  -1;


            int seconPillarRow = -1;
            int seconPillarCol =  -1;

            int priceSum = 0;


            for (int row = 0; row < matrixSize; row++)
            {
                char[] lineSymbols = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lineSymbols.Length; col++)
                {
                    matrix[row, col] = lineSymbols[col];
                    if (matrix[row, col] == 'S')
                    {
                        shoperRow = row;
                        shoperCol = col;
                    }

                    else if(matrix[row, col] == 'O' && firstPillarRow == -1 && firstPillarCol == -1)
                    {
                        firstPillarRow = row;
                        firstPillarCol = col;
                    }

                    else if(matrix[row, col] == 'O' && firstPillarRow != -1 && firstPillarCol != -1)
                    {
                        seconPillarRow = row;
                        seconPillarCol = col;
                    }
                }
            }

           
            while(true)
            {

                matrix[shoperRow, shoperCol] = '-';
                string command = Console.ReadLine();

                if(command == "up")
                {
                    shoperRow--;
                }
                else if(command == "down")
                {
                    shoperRow++;
                }
                else if (command == "left")
                {
                    shoperCol--;
                }
                else if (command == "right")
                {
                    shoperCol++;
                }

                if(!IsValidCoordinate(matrixSize, shoperRow, shoperCol))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

               
                if (Char.IsDigit(matrix[shoperRow, shoperCol]))
                {
                    int clientPrice = (int)Char.GetNumericValue(matrix[shoperRow, shoperCol]);
                    priceSum = priceSum + clientPrice;
                    matrix[shoperRow, shoperCol] = '-';
                    if(priceSum >= 50)
                    {
                        matrix[shoperRow, shoperCol] = 'S';
                        Console.WriteLine("Good news! You succeeded in collecting enough money!");
                        break;
                    }
                    
                }

                if(matrix[shoperRow, shoperCol] == 'O')
                {
                    if(shoperRow == firstPillarRow && shoperCol == firstPillarCol)
                    {
                        matrix[firstPillarRow, firstPillarCol] = '-';
                        shoperRow = seconPillarRow;
                        shoperCol = seconPillarCol;                     
                    }
                    else if(shoperRow == seconPillarRow && shoperCol == seconPillarCol)
                    {
                        matrix[seconPillarRow, seconPillarCol] = '-';
                        shoperRow = firstPillarRow;
                        shoperCol = firstPillarCol;
                    }
                }

                matrix[shoperRow, shoperCol] = 'S';

            }


            //Printing:

            Console.WriteLine($"Money: {priceSum}");
            PrintMatrix(matrix);

           
           // PrintMatrix(matrix);



        }



        static bool IsValidCoordinate(int matrixSize, int row, int col)
        {
            if(row > matrixSize - 1 || row < 0 || col > matrixSize - 1 || col < 0)
            {
                return false;
            }

            return true;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }



    }
}
