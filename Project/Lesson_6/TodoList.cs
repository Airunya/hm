using System;
using System.IO;
using System.Xml.Serialization;

namespace Project.Lesson_6
{

    [Serializable]
    public class ToDo
    {
        public string[] Title { get; set; }
        public string[] IsDone { get; set; }

        public ToDo(string title, string isDone)
        {
            for (int i = 0; i < Title.Length; i++)
            {
                Title[i] = title;
            }
            for (int i = 0; i < IsDone.Length; i++)
            {
                IsDone[i] = isDone;
            }

        }
        public ToDo()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ToDo todo = new ToDo();

            if (File.Exists("work.xml"))
            {
                Deserized();
            }
            else
            {
                CreateWorkList();
            }


            void CreateWorkList()
            {
                Console.WriteLine("Ввести задачи через пробел:");
                Console.WriteLine();
                string work = Console.ReadLine();
                todo.Title = work.Split(' ');
                todo.IsDone = new string[todo.Title.Length];
                for (int i = 0; i < todo.Title.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {todo.Title[i]}");
                    todo.IsDone[i] = "";
                }
                QuestionCycle(todo.Title, todo.IsDone);
            }

            void QuestionCycle(string[] title, string[] done)
            {
                try
                {
                    Console.WriteLine($"Сериализация, ввести значение больше {title.Length}");
                    int count = Convert.ToInt32(Console.ReadLine());

                    if (count <= title.Length && count > 0)
                    {
                        Change(title, done, count);
                    }
                    Serialized();
                }
                catch
                {
                    Console.WriteLine("Введите число.");
                    QuestionCycle(todo.Title, todo.IsDone);
                }
            }


            void Change(string[] title, string[] done, int count)
            {
                for (int i = 0; i < title.Length; i++)
                {
                    if (i + 1 == count)
                    {
                        if (done[i] != "X")
                        {
                            done[i] = "X";
                        }
                        else
                        {
                            done[i] = "";
                        }
                    }
                }
                for (int i = 0; i < title.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {title[i]} {done[i]}");
                }
                QuestionCycle(title, done);
            }


            void Pars(string[] title, string[] done)
            {
                todo.Title = new string[title.Length];
                todo.IsDone = new string[done.Length];

                for (int i = 0; i < title.Length; i++)
                {
                    todo.Title[i] = title[i];
                    todo.IsDone[i] = done[i];
                }
                QuestionCycle(todo.Title, todo.IsDone);
            }


            void Deserized()
            {
                string xmlText = File.ReadAllText("work.xml");
                StringReader stringReader = new StringReader(xmlText);
                XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
                ToDo toDo = (ToDo)serializer.Deserialize(stringReader);
                for (int i = 0; i < toDo.Title.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {toDo.Title[i]} {toDo.IsDone[i]}");
                }
                Pars(toDo.Title, toDo.IsDone);
            }


            void Serialized()
            {
                StringWriter stringWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
                serializer.Serialize(stringWriter, todo);
                string xml = stringWriter.ToString();
                File.WriteAllText("work.xml", xml);

            }
        }
    }
}
