using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lesson_3
{
    class Class2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать номер упражнения:");
            Console.WriteLine("1.Элементы по диагонали (упр.№1)\n2.Телефонный справочник (упр.№2)\n3.Слово наоборот (упр №3) \n4.\"Морской бой\" \n5.Доп ДЗ (упр.№4)");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    lesson_3_1();
                    break;
                case 2:
                    lesson_3_2();
                    break;
                case 3:
                    lesson_3_3();
                    break;
                case 4:
                    lesson_3_4();
                    break;
                case 5:
                    lesson_3_5();
                    break;
            }

            void lesson_3_1()
            {
                char c1 = '.';
                char c2 = 'X';
                string[,] arr = new string[50, 50];
                int columns = arr.GetLength(0);
                int rows = arr.GetLength(1);

                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (i == j)
                        {
                            arr[i, j] = Convert.ToString(c2);
                        }
                        else if (rows - j - 1 == i)
                        {
                            arr[i, j] = Convert.ToString(c2);
                        }
                        else
                        {
                            arr[i, j] = Convert.ToString(c1);
                        }
                    }
                }
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Console.Write($"{arr[i, j]}");
                    }
                    Console.WriteLine();
                }
            }


            void lesson_3_2()
            {
                string[,] arr = new string[5, 2];
                int columns = arr.GetLength(0);
                int rows = arr.GetLength(1);
                arr[0, 0] = "Name";
                arr[0, 1] = "email";
                for (int i = 1; i < columns; i++)
                {
                    Console.WriteLine("Ввести имя");
                    arr[i, 0] = Console.ReadLine();

                    for (int j = 1; j < rows; j++)
                    {
                        Console.WriteLine("Ввести email");
                        arr[i, j] = Console.ReadLine();
                    }
                }
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Console.Write($"{arr[i, j]} \t");
                    }
                    Console.WriteLine();                    
                }
            }


            void lesson_3_3()
            {
                Console.WriteLine("Ввести слово:");
                string word = Console.ReadLine();
                char[] arr = word.ToCharArray();
                for (int i = arr.Length; i > 0; i--)
                {
                    Console.Write(arr[i - 1]);
                }
                Console.ReadKey();
            }


            void lesson_3_4()
            {
                char c1 = 'O';
                char c2 = 'X';
                Random rnd = new Random();

                char[,] arr = new char[10, 15];

                int columns = arr.GetLength(0);
                int rows = arr.GetLength(1);

                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        int x = rnd.Next(3);
                        if (x == 1)
                        {
                            arr[i, j] = c2;
                        }
                        else
                        {
                            arr[i, j] = c1;
                        }
                    }
                }
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Console.Write($"{arr[i, j]}");
                    }
                    Console.WriteLine();
                }
            }


            void lesson_3_5()
            {
                Console.WriteLine("Ввести массив");
                char[] arr = Console.ReadLine().ToCharArray();
                Console.WriteLine("Ввести n");
                int n = Convert.ToInt32(Console.ReadLine());
                int rows = arr.Length;

                if (n > 0 && n != 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        char temp = arr[rows - 1];
                        for (int i = rows - 1; i > 0; i--)
                        {
                            arr[i] = arr[i - 1];
                        }
                        arr[0] = temp;
                    }
                    Console.WriteLine(string.Join(", ", arr));
                }
                if (n < 0 && n != 0)
                {
                    for (int j = 0; j > n; j--)
                    {
                        char temp = arr[0];
                        for (int i = 0; i < rows - 1; i++)
                        {
                            arr[i] = arr[i + 1];
                        }
                        arr[rows - 1] = temp;
                    }
                    Console.WriteLine(string.Join(", ", arr));
                }
                if (n == 0)
                {
                    Console.WriteLine(string.Join(", ", arr));
                }
            }


        }
    }
}

