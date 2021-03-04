using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lesson_5
{
    class Class4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать номер упражнения:");
            Console.WriteLine("1.Заполнить txt (упр.№1)\n2.Заполняет дату время (упр.№2)\n3.Бинарный фаил (упр №3)");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    lesson_5_1();
                    break;
                case 2:
                    lesson_5_2();
                    break;
                case 3:
                    lesson_5_3();
                    break;
            }
            void lesson_5_1()
            {
                Console.WriteLine("Рандомный текст:");
                string filename = "text.txt";
                string[] stringArr = new string[3];
                for (int i = 0; i < stringArr.Length; i++)
                {
                    stringArr[i] = Console.ReadLine();
                }
                File.WriteAllLines(filename, stringArr);
                string fileText = File.ReadAllText(filename);
                Console.WriteLine(fileText);
            }

            void lesson_5_2()
            {
                Console.WriteLine("Дата время:");
                string filename = "startup.txt";
                File.AppendAllText(filename, DateTime.Now.ToString());
                File.AppendAllText(filename, Environment.NewLine);
                string fileText = File.ReadAllText(filename);
                Console.WriteLine(fileText);
            }

            void lesson_5_3()
            {
                Console.WriteLine("Ввести от 0 до 255 через пробел");
                string num = Console.ReadLine();
                //string filename = "binarnik.bin";
                string[] arrStr = num.Split(' ');
                byte[] arrByte = new byte[arrStr.Length];
                for (int i = 0; i < arrStr.Length; i++)
                {
                    arrByte[i] = Byte.Parse(arrStr[i]);
                }
                File.WriteAllBytes("binarnik.bin", arrByte);
                for (int i = 0; i < arrByte.Length; i++)
                {
                    Console.WriteLine(arrByte[i]);
                }




                //Console.WriteLine("Ввести от 0 до 255 через пробел");
                //string num = Console.ReadLine();
                //string filename = "binarnik.bin";
                //string[] arrStr = num.Split(' ');
                //File.WriteAllLines(filename, arrStr);
                //File.AppendAllText(filename, Environment.NewLine);
                //string fileText = File.ReadAllText(filename);
                //Console.WriteLine(fileText);
            }
        }
    }
}
