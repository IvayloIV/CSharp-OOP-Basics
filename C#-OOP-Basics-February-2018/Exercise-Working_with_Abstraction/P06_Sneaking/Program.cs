using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] jagged;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            jagged = new char[n][];
            FillJagged(n);

            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];
            FindSamPosition(samPosition);
            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies();
                int[] enemyPosition = new int[2];
                FindEnemyPosition(samPosition, enemyPosition);

                var samDead = IsSamDie(samPosition, enemyPosition);
                if (samDead) return;
                MoveSam(moves, samPosition, i);

                FindEnemyPosition(samPosition, enemyPosition);
                bool nikoDead = IsNikoDie(samPosition, enemyPosition);
                if (nikoDead) return;
            }
        }

        private static bool IsNikoDie(int[] samPosition, int[] getEnemy)
        {
            if (jagged[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                PrintNikoIsDead(getEnemy);
                return true;
            }
            return false;
        }

        private static void PrintNikoIsDead(int[] getEnemy)
        {
            jagged[getEnemy[0]][getEnemy[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveSam(char[] moves, int[] samPosition, int i)
        {
            jagged[samPosition[0]][samPosition[1]] = '.';
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            jagged[samPosition[0]][samPosition[1]] = 'S';
        }

        private static bool IsSamDie(int[] samPosition, int[] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && jagged[getEnemy[0]][getEnemy[1]] == 'd'
                && getEnemy[0] == samPosition[0])
            {
                PrintSamIsDie(samPosition);
                return true;
            }
            else if (getEnemy[1] < samPosition[1] && jagged[getEnemy[0]][getEnemy[1]] == 'b'
                && getEnemy[0] == samPosition[0])
            {
                PrintSamIsDie(samPosition);
                return true;
            }
            return false;
        }

        private static void PrintSamIsDie(int[] samPosition)
        {
            jagged[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void FindEnemyPosition(int[] samPosition, int[] getEnemy)
        {
            for (int col = 0; col < jagged[samPosition[0]].Length; col++)
            {
                if (jagged[samPosition[0]][col] != '.' && jagged[samPosition[0]][col] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = col;
                }
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'b')
                    {
                        col = MoveToRightEnemy(row, col);
                    }
                    else if (jagged[row][col] == 'd')
                    {
                        MoveToLeftEnemy(row, col);
                    }
                }
            }
        }

        private static void MoveToLeftEnemy(int row, int col)
        {
            if (row >= 0 && row < jagged.Length && col - 1 >= 0 && col - 1 < jagged[row].Length)
            {
                jagged[row][col] = '.';
                jagged[row][col - 1] = 'd';
            }
            else
            {
                jagged[row][col] = 'b';
            }
        }

        private static int MoveToRightEnemy(int row, int col)
        {
            if (row >= 0 && row < jagged.Length && col + 1 >= 0 && col + 1 < jagged[row].Length)
            {
                jagged[row][col] = '.';
                jagged[row][col + 1] = 'b';
                col++;
            }
            else
            {
                jagged[row][col] = 'd';
            }

            return col;
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < jagged.Length && col + 1 >= 0 && col + 1 < jagged[row].Length;
        }

        private static void FindSamPosition(int[] samPosition)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void FillJagged(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                jagged[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jagged[row][col] = input[col];
                }
            }
        }
    }
}