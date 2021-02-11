using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();
            DateTime date = DateTime.Now;
            Console.WriteLine($"Привет {name} сегодня {date.ToShortDateString()} и время {date.ToShortTimeString()}");
            Console.ReadKey();
         
        }
    }
}
