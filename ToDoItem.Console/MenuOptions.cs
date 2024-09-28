using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItem_Console
{
    public static class MenuOptions
    {
        public static List<ToDoItem> toDoList = new List<ToDoItem>();
        public static void ShowTasks()
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("Brak zaplanowanych zadań.");
            }
            else
            {
                for (int i = 0; i < toDoList.Count; i++)
                {
                    string status = toDoList[i].IsCompleted ? "[X]" : "[ ]";
                    Console.WriteLine($"{i + 1}. {status} {toDoList[i].Task}");
                }
            }
        }

        public static void AddTask()
        {
            Console.WriteLine("Wpisz zadanie:");
            string task = Console.ReadLine();
            toDoList.Add(new ToDoItem(task));
        }

        public static void CompleteTask()
        {
            Console.WriteLine("Wybierz numer zadania do zakończenia:");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < toDoList.Count)
            {
                toDoList[index].IsCompleted = true;
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer zadania.");
            }
        }

        public static void RemoveTask()
        {
            Console.WriteLine("Wybierz numer zadania do usunięcia:");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < toDoList.Count)
            {
                toDoList.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer zadania.");
            }
        }
        public static void SaveTasks()
        {
            using (StreamWriter writer = new StreamWriter("Tasks.txt"))
            {
                foreach (var item in toDoList)
                {
                    writer.WriteLine($"{item.Task}|{item.IsCompleted}");
                }
            }
            Console.WriteLine("Zadania zostały zapisane.");
        }
        public static void LoadTasks()
        {
            if (File.Exists("Tasks.txt"))
            {
                using (StreamReader reader = new StreamReader("Tasks.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            var task = parts[0];
                            var isCompleted = bool.Parse(parts[1]);
                            toDoList.Add(new ToDoItem(task) { IsCompleted = isCompleted });
                        }
                    }
                }
                Console.WriteLine("Zadania zostały załadowane.");
            }
        }
    }
}
