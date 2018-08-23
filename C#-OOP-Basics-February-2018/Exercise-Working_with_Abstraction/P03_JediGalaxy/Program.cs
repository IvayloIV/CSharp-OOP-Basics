using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = ReadNewRow();
            int rowCount = dimestions[0];
            int cowCount = dimestions[1];

            int[,] matrix = new int[rowCount, cowCount];
            FillMatrix(rowCount, cowCount, matrix);

            string command;
            long sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoTokens = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evilTokens = ReadNewRow();

                var evilPoint = new Point(evilTokens[0], evilTokens[1]);
                ResizeEvilPoints(matrix, evilPoint);
                MoveEvil(matrix, evilPoint);

                var ivoPoint = new Point(ivoTokens[0], ivoTokens[1]);
                ResizeEvilPosints(matrix, ivoPoint);
                sum = CalculateIvoSum(matrix, sum, ivoPoint);
            }
            Console.WriteLine(sum);
        }

        private static int[] ReadNewRow()
        {
            return Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }

        private static long CalculateIvoSum(int[,] matrix, long sum, Point ivoPoint)
        {
            while (ivoPoint.Row >= 0 && ivoPoint.Cow < matrix.GetLength(1))
            {
                if (InInsideMatrixIvo(ivoPoint, matrix))
                {
                    sum = AddToSum(matrix, sum, ivoPoint.Row, ivoPoint.Cow);
                }

                ivoPoint.Cow++;
                ivoPoint.Row--;
            }

            return sum;
        }

        private static bool InInsideMatrixIvo(Point ivoPoint, int[,] matrix)
        {
            return ivoPoint.Row >= 0 && ivoPoint.Row < matrix.GetLength(0) && ivoPoint.Cow >= 0 
                && ivoPoint.Cow < matrix.GetLength(1);
        }

        private static void ResizeEvilPosints(int[,] matrix, Point ivoPoint)
        {
            var diffIvoRows = ivoPoint.Row - (matrix.GetLength(0) - 1);
            if (diffIvoRows > 0)
            {
                ivoPoint.Row -= diffIvoRows;
                ivoPoint.Cow += diffIvoRows;
            }
        }

        private static void MoveEvil(int[,] matrix, Point evilPoint)
        {
            while (evilPoint.Row >= 0 && evilPoint.Cow >= 0)
            {
                if (IsInsideEvil(evilPoint.Row, evilPoint.Cow, matrix))
                {
                    matrix[evilPoint.Row, evilPoint.Cow] = 0;
                }
                evilPoint.Row--;
                evilPoint.Cow--;
            }
        }

        private static void ResizeEvilPoints(int[,] matrix, Point evilPoint)
        {
            var diffEvilRows = evilPoint.Row - (matrix.GetLength(0) - 1);
            if (diffEvilRows > 0)
            {
                evilPoint.Row -= diffEvilRows;
                evilPoint.Cow -= diffEvilRows;
            }
        }

        private static long AddToSum(int[,] matrix, long sum, int ivoRow, int ivoCow)
        {
            sum += matrix[ivoRow, ivoCow];
            return sum;
        }

        private static bool IsInsideEvil(int evilRow, int evilCow, int[,] matrix)
        {
            return evilRow >= 0 && evilRow < matrix.GetLength(0) 
                && evilCow >= 0 && evilCow < matrix.GetLength(1);
        }

        private static void FillMatrix(int rowCount, int cowCount, int[,] matrix)
        {
            int counter = 0;
            for (int row = 0; row < rowCount; row++)
            {
                for (int cow = 0; cow < cowCount; cow++)
                {
                    matrix[row, cow] = counter++;
                }
            }
        }
    }
}