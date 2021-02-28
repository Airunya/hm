using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lesson_4
{
    class Class3
    {
        enum SesonsYear
        {
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Autumn = 4,
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать номер упражнения:");
            Console.WriteLine("1.Вывести ФИО (упр.№1)\n2.Сумма чисел (упр.№2)\n3.Времена года (упр №3)\n4.Фибоначи (доп упр.)");
            int practice = Convert.ToInt32(Console.ReadLine());
            switch (practice)
            {                
                case 1:
                    GetFullName("Imya_1 ", "Familia_1 ", "Otchestvo_1");
                    GetFullName("Imya_2 ", "Familia_2 ", "Otchestvo_2");
                    GetFullName("Imya_3 ", "Familia_3 ", "Otchestvo_3");
                    GetFullName("Imya_4 ", "Familia_4 ", "Otchestvo_4");
                    break;
                case 2:
                    Console.WriteLine("Ввести цифры через пробел");
                    string num = Console.ReadLine();
                    SumNumber(num);
                    break;
                case 3:                    
                    Сheck();                                   
                    break;
                case 4:
                    Console.WriteLine("Ввести число n");
                    long n = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine(Fib(n));
                    break;


            }

            void GetFullName(string firstName, string lastName, string patronymic)
            {
                Console.WriteLine(firstName + lastName + patronymic);
                return;
            }

            void SumNumber(string number)
            {
                string[] arrstr = number.Split(' ');
                int rows = arrstr.Length;
                int[] arrint = new int[rows];
                int summ = 0;
                for (int i = 0; i < rows; i++)
                {
                    arrint[i] = Convert.ToInt32(arrstr[i]);
                    summ = arrint[i] + summ;
                }
                Console.WriteLine(summ.ToString());
                return;

            }

            void Сheck()
            {
                Console.Write("Ввести номер месяца:");
                try
                {
                    int numMonth = Convert.ToInt32(Console.ReadLine());
                    if (numMonth>0 && numMonth <=12)
                    {
                        Season(numMonth);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите число от 1 до 12");
                        Сheck();
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                    Сheck();
                }
                
                Console.Write(" ");
                return;
                
            }
            void Season(int numMonth)
            {
                if (numMonth > 0 && numMonth <= 3)
                {
                    GetNameSeasons((SesonsYear)1);
                    return;
                }
                if (numMonth > 3 && numMonth <= 6)
                {
                    GetNameSeasons((SesonsYear)2);
                    return;
                }
                if (numMonth > 6 && numMonth <= 9)
                {
                    GetNameSeasons((SesonsYear)3);
                    return;
                }
                if (numMonth > 9 && numMonth <= 12)
                {
                    GetNameSeasons((SesonsYear)4);
                    return;
                }

                void GetNameSeasons(object nameSeasons)
                {
                    switch (nameSeasons)
                    {
                        case SesonsYear.Winter:
                            Console.WriteLine("Зима");
                            break;
                        case SesonsYear.Spring:
                            Console.WriteLine("Весна");
                            break;
                        case SesonsYear.Summer:
                            Console.WriteLine("Лето");
                            break;
                        case SesonsYear.Autumn:
                            Console.WriteLine("Осень");
                            break;
                    }
                }
                
            }
            long Fib(long n)
            {
                if (n == 1 || n == 2)
                {
                    return 1;
                }
                else
                {
                    return Fib(n - 1) + Fib(n - 2);
                }
            }
        }
    }
}




