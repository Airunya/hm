using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lesson_2
{
    class Class1

    {
        [Flags]
        public enum Office
        {
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday = 0b_1000000,
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Выбрать номер упражнения:");
            Console.WriteLine("1.Температура, месяца (упр.№1,2,3,5)\n2.Тикет (упр.№4)\n3.Расписание (упр №6)");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    temperature();
                    break;
                case 2:
                    ticket();
                    break;
                case 3:
                    mask();
                    break;
            }


            void temperature()
            {
                try
                {
                    Console.WriteLine("Введите минимальную температуру:");
                    int minTemp = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите минимальную температуру:");
                    int maxTemp = Convert.ToInt32(Console.ReadLine());
                    int averageValue = (minTemp + maxTemp) / 2;
                    Console.WriteLine("Средняя температура " + averageValue);

                    Console.WriteLine("Ввести номер месяца: ");
                    int numMonth = Convert.ToInt32(Console.ReadLine());
                    if (numMonth > 0 && numMonth <= 12)
                    {
                        Console.WriteLine("{0:MMMM}", new DateTime(1, numMonth, 1));
                        if (numMonth % 2 == 0)
                        {
                            Console.WriteLine("Четное");
                        }
                        else
                        {
                            Console.WriteLine("Нечетное");
                        }
                        if ((numMonth >= 1 && numMonth <= 3) && averageValue > 0)
                        {
                            Console.WriteLine("Дождливая зима");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные");
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректные данные");
                }
            }
            void ticket()
            {
                string company = "ООО \"ГПХ\"";
                string ofd = "ofd";
                string site = "blabla.com";
                string summ = Convert.ToString(680);
                DateTime date = DateTime.Now;
                Console.WriteLine($"|_____{company}_____|");
                Console.WriteLine($"|______Сегодня______|");
                Console.WriteLine($"|____{date.ToShortDateString()}_____|");
                Console.WriteLine($"|_______{date.ToShortTimeString()}_______|");
                Console.WriteLine($"|_{ofd}____{site}_|");
                Console.WriteLine($"|_Сумма_________{summ}_|");

            }
            void mask()
            {
                Office firstSchedule = Office.Monday | Office.Tuesday | Office.Wednesday | Office.Thursday | Office.Friday ;
                Office secondSchedule = Office.Sunday | Office.Monday | Office.Thursday | Office.Wednesday | Office.Thursday;
                                
                Office workDay = (Office)0b1111111;

                Office monday_friday = workDay & firstSchedule;
                Office sunday_thursday = workDay & secondSchedule;
                

                bool mf_shedule = firstSchedule == monday_friday;
                bool st_shedule = secondSchedule == sunday_thursday;
                

                Console.WriteLine($"Офис работает: {workDay}");
                if (mf_shedule != true)
                {
                    Console.WriteLine("Офис работает с воскресенья по четверг");
                }
                else
                {
                    Console.WriteLine("Офис работает с понедельника по пятницу");
                } 
               
                
            }
        }

    }




}
