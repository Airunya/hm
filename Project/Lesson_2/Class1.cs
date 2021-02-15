using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lesson_2
{
    class Class1
    {
        static void Main(string[] args)
        {

            try           
            {
                Console.WriteLine("Ввести минимальную температуру за сутки");
                int minTemp = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ввести максимальную температуру за сутки");
                int maxTemp = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Средняя температура " + ((minTemp + maxTemp) / 2));

                Console.WriteLine("Ввести номер месяца");
                int numMonth = Convert.ToInt32(Console.ReadLine());
                if (numMonth > 0 && numMonth <= 12)
                {                   
                    Console.WriteLine("{0:MMMM}", new DateTime(1, numMonth, 1));
                    if (numMonth % 2 == 0)
                    {
                        Console.WriteLine("четное");
                    }
                    else
                    {
                        Console.WriteLine("не четное");
                    }
                }
                else
                {
                    Console.WriteLine("некорректные данные");
                }


            } catch
            {
                Console.WriteLine("некорректные данные");
            }

            

        }

        
    }
}
