using System;
using System.Collections.Generic;
using System.Text;

namespace Level_1.Lesson_7
{
    class Class6
    {
        static int SIZE_X = 5;
        static int SIZE_Y = 5;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();

        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-----------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void PlayerStep()
        {
            int x;
            int y;
            do
            {
                Console.WriteLine($"Введите координаты X Y (1-{SIZE_X})");
                x = Int32.Parse(Console.ReadLine()) - 1;
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiStep()
        {
            int x;
            int y;
            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }

        private static bool CheckWin(char sym)
        {
            int win = 4;
            
            if (sym == PLAYER_DOT)
            {
                //горизонтальная
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        int userCount = 0;
                        if (field[i,j]==sym)
                        {
                            for (int n = 0; n < field.GetLength(0); n++)
                            {
                                if (field[i,n]==sym)
                                {
                                    userCount++;
                                }
                                if (field[i, n] == AI_DOT && userCount != win)
                                {
                                    userCount = 0;
                                }
                                if (userCount == win)
                                {
                                    return true;
                                }
                            }
                        }                        
                    }                        
                }
                //вертикальная
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        int userCount = 0;
                        if (field[i, j] == sym)
                        {
                            for (int n = 0; n < field.GetLength(1); n++)
                            {
                                if (field[n, j] == sym)
                                {
                                    userCount++;
                                }
                                if (field[n, j] == AI_DOT && userCount != win)
                                {
                                    userCount = 0;
                                }
                                if (userCount == win)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                // *\*
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        int userCount = 0;
                        if (field[i, j] == sym)
                        {
                                for (int n = i; n < field.GetLength(0); n++)
                                {
                                for (int h = j; h < field.GetLength(1); h++)
                                {
                                    if (field[n, h] == sym)
                                    {
                                        userCount++;
                                    }
                                    if (field[n, h] == AI_DOT && userCount != win)
                                    {
                                        userCount = 0;
                                    }
                                    if (userCount == win)
                                    {
                                        return true;
                                    }
                                }                               
                            }
                            
                        }
                    }
                }
                // */*
                for (int i = field.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = field.GetLength(1) - 1; j >= 0; j--)
                    {
                        int userCount = 0;
                        if (field[i, j] == sym)
                        {
                            for (int n = i; field.GetLength(0) > n; n--)
                            {
                                for (int h = j; h > 1; h--)
                                {
                                    if (field[n, h] == sym)
                                    {
                                        userCount++;
                                    }
                                    if (field[n, h] == AI_DOT && userCount != win)
                                    {
                                        userCount = 0;
                                    }
                                    if (userCount == win)
                                    {
                                        return true;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return false;         
        }

        static void Main(string[] args)
        {
            InitField();
            PrintField();

            while (true)
            {
                PlayerStep();
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
                AiStep();
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("SkyNet Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
            }
        }
    }
}
