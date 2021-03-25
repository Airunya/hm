using System;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Threading.Tasks;


namespace Project.Lesson_8
{
    class Class7
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать номер упражнения:");
            Console.WriteLine("1.Процессы\n2.DLL");
            int practice = Convert.ToInt32(Console.ReadLine());
            switch (practice)
            {
                case 1:
                    ProcessName();
                    break;
                case 2:
                    DLL();
                    break;
            }
            void ProcessName()
            {
                Process[] procList = Process.GetProcesses();
                Console.WriteLine("{0, -7} | {1,-30}", "ID", "Name Process");
                Console.WriteLine("{0, -7} | {1,-30}", "_______", "____________");
                for (int i = 0; i < procList.Length; i++)
                {
                    Console.WriteLine("{0, -7} | {1,-30}", procList[i].Id, procList[i].ProcessName);
                }
                Console.WriteLine("Ввести ID или имя процесса");
                string processName = Console.ReadLine();
                if (int.TryParse(processName, out int id))
                {
                    for (int i = 0; i < procList.Length; i++)
                    {
                        if (id == procList[i].Id)
                        {
                            procList[i].Kill();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < procList.Length; i++)
                    {
                        if (processName == procList[i].ProcessName)
                        {
                            procList[i].Kill();
                        }
                    }
                }
            }
            Console.ReadLine();
            void DLL()
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\Users\i.serednikov\Desktop\vs_new\hm\ConsoleHello\bin\Debug\ConsoleHello.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.RedirectStandardOutput = false;
                process.Start();                
            }
        }
    }
}
