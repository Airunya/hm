using System;
using System.IO;
using System.Xml.Serialization;

namespace Project.Lesson_6
{

    class Class5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать номер упражнения:");
            Console.WriteLine("1.Перебор через рекурсию (упр.№1)\n2.Перебор через цикл (упр.№1)");

            string workDir = @"C:\Users\i.serednikov\Desktop\vs\hm\Project\bin\Debug";
            string filename = "gusi.txt";

            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    DirSearch(workDir);
                    break;
                case 2:
                    DirSearchCycle();
                    break;
                //case 3:
                //    try
                //    {
                //        Console.WriteLine("Ввести y:");
                //        int y = Convert.ToInt32(Console.ReadLine());

                //        Console.WriteLine("Ввести x:");
                //        int x = Convert.ToInt32(Console.ReadLine());

                //        string[,] strArr = new string[y, x];

                //        MyArraySizeException(strArr);
                //    }
                //    catch (IndexOutOfRangeException e)
                //    {
                //        Console.WriteLine(e.Message);
                //    }
                    break;
            }
            //через рекурсию
            void DirSearch(string sDir)
            {
                try
                {
                    File.AppendAllText(filename, "_______" + sDir + "\n");

                    string[] dirs = Directory.GetDirectories(sDir);

                    File.AppendAllLines(filename, dirs);

                    string[] files = Directory.GetFiles(sDir);

                    File.AppendAllLines(filename, files);

                    if (Directory.GetParent(sDir) != null)
                    {
                        DirSearch(Directory.GetParent(sDir).ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
            }

            //церез цикл
            void DirSearchCycle()
            {
                Console.WriteLine(Directory.Exists(workDir));
                string[] initialDir = workDir.Split('\\');
                string temp = "";
                for (int i = 0; i < initialDir.Length; i++)
                {
                    temp = temp + initialDir[i] + '\\';

                    File.AppendAllText(filename, "_____" + temp + "_____\n");

                    string[] dirs = Directory.GetDirectories(temp);

                    File.AppendAllLines(filename, dirs);

                    string[] files = Directory.GetFiles(temp);

                    File.AppendAllLines(filename, files);
                }
            }


            void MyArraySizeException(string[,] arr)
            {
                if (arr.GetLength(0) != 4 || arr.GetLength(1) != 4)
                {
                    throw new IndexOutOfRangeException("Ошибка размера массива, не равен 4x4");
                }
                FourFourArray(arr);
            }

            void MyArrayDataException(string item)
            {
                int num;
                bool isNum = int.TryParse(item, out num);
                if (isNum == true)
                {
                    throw new Exception($"Неверные данные {item}");
                }
                return;

            }


            void FourFourArray(string[,] strArr)
            {
                Console.WriteLine("Ввод массива:");

                int summ = 0;

                int y = strArr.GetLength(0);
                int x = strArr.GetLength(1);

                string[,] arrInt = new string[y, x];

                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        strArr[i, j] = Console.ReadLine();
                    }
                }

                try
                {
                    for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {                        
                      MyArrayDataException(arrInt[i, j]);                 
                      summ += Convert.ToInt32(strArr[i, j]);
                    }
                }
                Console.WriteLine($"\t {summ}");
                }
                catch (Exception expt)
                {
                    Console.WriteLine($"{expt.Message}");
                }


                for (int i = 0; i < y; i++)
                {
                    Console.WriteLine("\t");
                    for (int j = 0; j < x; j++)
                    {
                        Console.Write($"  {arrInt[i, j]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

