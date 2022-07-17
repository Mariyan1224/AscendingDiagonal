using System;

namespace M2MServices_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAscending = false;
            int[,] matrix = new int[5, 5];
            Init(matrix);
            Console.WriteLine("Generated matrix: ");
            ShowMatrix(matrix);
            Console.WriteLine("All matrices with ascending main diagonal: ");
            DoPermute(matrix, 0, 3,ref isAscending);
            if (!isAscending)
                Console.WriteLine("NO RESULT.");
            Console.ReadKey();
        }
        static void Init(int[,] matrix)
        {
            var random = new Random();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = random.Next(1, 10);
                }
            }
        }

        static void ShowMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void SwapLines(int[,] matrix, int currentLine, int wantedLine)
        {
            int swap = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                swap = matrix[currentLine, col];
                matrix[currentLine, col] = matrix[wantedLine, col];
                matrix[wantedLine, col] = swap;
            }
        }

        static bool IsDiagonalAscending(int[,] matrix)
        {
            for (int index = 0; index < matrix.GetLength(0) - 1; index++)
            {
                if (matrix[index, index] > matrix[index + 1, index + 1])
                    return false;
            }
            return true;
        }
       
        static void DoPermute(int[,] matrix, int startRow, int endRow,ref bool isAscending)
        {
            if (startRow == endRow)
            {
                if (IsDiagonalAscending(matrix)) // Checks if main diagonal is ascending
                {
                    ShowMatrix(matrix);
                    isAscending = true;
                }
            }
            else
            {
                for (int indexRow = startRow; indexRow <= endRow; indexRow++)
                {
                    SwapLines(matrix, startRow, indexRow);
                    DoPermute(matrix, startRow + 1, endRow, ref isAscending);
                    SwapLines(matrix, startRow, indexRow);
                }
            }
            return;
        }
    }
}

