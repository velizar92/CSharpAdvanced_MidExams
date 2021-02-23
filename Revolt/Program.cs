using System;

namespace Revolt
{
    class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            int playerRow = -1;
            int playerCol = -1;
            bool isWon = false;


            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] lineSymbols = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = lineSymbols[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }


            //Commands part:

            for (int i = 0; i < countCommands; i++)
            {

                matrix[playerRow, playerCol] = '-';
                string movement = Console.ReadLine();

                if (movement == "up")
                {
                    playerRow--;
                }

                else if (movement == "down")
                {
                    playerRow++;
                }

                else if (movement == "left")
                {
                    playerCol--;
                }
                else if (movement == "right")
                {
                    playerCol++;
                }


                //Validation of coordinates:
                if (!IsValidCoordinate(playerRow, playerCol, matrixSize, matrixSize))
                {
                    playerRow = GetNewRowCoordinate(movement, playerRow, matrix);
                    playerCol = GetNewColCoordinate(movement, playerCol, matrix);
                }

                //Bonus part:
                if (matrix[playerRow, playerCol] == 'B')
                {

                    playerRow = MoveRow(movement, playerRow, 'B');
                    playerCol = MoveCol(movement, playerCol, 'B');
                    if (!IsValidCoordinate(playerRow, playerCol, matrixSize, matrixSize))
                    {
                        playerRow = GetNewRowCoordinate(movement, playerRow, matrix);
                        playerCol = GetNewColCoordinate(movement, playerCol, matrix);
                    }
                }

                //Trap part:
                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = MoveRow(movement, playerRow, 'T');
                    playerCol = MoveCol(movement, playerCol, 'T');
                    if (!IsValidCoordinate(playerRow, playerCol, matrixSize, matrixSize))
                    {
                        playerRow = GetNewRowCoordinate(movement, playerRow, matrix);
                        playerCol = GetNewColCoordinate(movement, playerCol, matrix);
                    }
                }


                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    isWon = true;
                    break;
                }

                 matrix[playerRow, playerCol] = 'f';

              //  PrintMatrix(matrix);

            }

            if (isWon == false)
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);


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


        //1. Handling of up/down movement: 

        public static int GetNewRowCoordinate(string movement, int row, char[,] matrix)
        {
            if (movement == "up")
            {
                row = matrix.GetLength(0) - 1;
                return row;
            }
            else if (movement == "down")
            {
                row = 0;
                return row;
            }

            return row;
        }


        //2. Handling of left/right movement:

        public static int GetNewColCoordinate(string movement, int col, char[,] matrix)
        {
            if (movement == "left")
            {
                col = matrix.GetLength(1) - 1;
                return col;
            }
            else if (movement == "right")
            {
                col = 0;
                return col;
            }

            return col;
        }


        public static int MoveRow(string movement, int row, char _case)
        {

            if (_case == 'B')
            {
                if (movement == "up")
                {
                    return row - 1;
                }
                else if (movement == "down")
                {
                    return row + 1;
                }

                return row;
            }

            else if (_case == 'T')
            {
                if (movement == "up")
                {
                    return row + 1;
                }
                else if (movement == "down")
                {
                    return row - 1;
                }

                return row;
            }

            return row;
        }


        //2. Handling of left/right movement:

        public static int MoveCol(string movement, int col, char _case)
        {

            if (_case == 'B')
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

            if (_case == 'T')
            {
                if (movement == "left")
                {
                    return col + 1;
                }
                else if (movement == "right")
                {
                    return col - 1;
                }

                return col;
            }

            return col;
        }





    }
}
