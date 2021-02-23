using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int beeRowPos = -1;
            int beeColPos = -1;          
            int polinateFlowers = 0; //counter
          
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] lineSymbols = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lineSymbols.Length; col++)
                {
                    matrix[row, col] = lineSymbols[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRowPos = row;
                        beeColPos = col;
                    }
                  
                }
            }

           

            string movement = Console.ReadLine();

            //Movements
            while (movement != "End")
            {
                
                matrix[beeRowPos, beeColPos] = '.';

                //Gets the new bee position according to used command:
                //Handling of movements:
                beeRowPos = MoveRow(movement, beeRowPos);
                beeColPos = MoveCol(movement, beeColPos);

                //Check for valid coordinate:s
                if(!IsValidCoordinate(beeRowPos, beeColPos, matrixSize, matrixSize))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                //Covering different cases:
                if(matrix[beeRowPos, beeColPos] == 'f')
                {
                    polinateFlowers++;                 
                }


                if(matrix[beeRowPos, beeColPos] == 'O')
                {
                    matrix[beeRowPos, beeColPos] = '.';
                    beeRowPos = MoveRow(movement, beeRowPos);
                    beeColPos = MoveCol(movement, beeColPos);
                    if (!IsValidCoordinate(beeRowPos, beeColPos, matrixSize, matrixSize))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    else if(matrix[beeRowPos, beeColPos] == 'f')
                    {
                        polinateFlowers++;
                    }                
                }

                matrix[beeRowPos, beeColPos] = 'B';
                movement = Console.ReadLine();
            }


            //Printing:

            if (polinateFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinateFlowers} flowers!");
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinateFlowers} flowers more");
                PrintMatrix(matrix);
            }


            //For DEBUG purpose
            // PrintMatrix(matrix);
        }




        public static int MoveRow(string movement, int row)
        {
            if(movement == "up")
            {
                return row - 1;
            }
            else if(movement == "down")
            {
                return row + 1;
            }

            return row;
        }



        public static int MoveCol(string movement, int col)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            else if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }




        static bool IsValidCoordinate(int row, int col, int rows, int cols)
        {
            if (row < rows && row >= 0 && col < cols && col >= 0)
            {
                return true;
            }
               
            return false;
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
