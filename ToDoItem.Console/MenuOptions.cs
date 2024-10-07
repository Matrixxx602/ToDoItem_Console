using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Console.WriteLine("...: 1 <- po numerze zadania, 2 <- po nazwie zadania");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Wybierz numer zadania do zakończenia:");
                    int index = int.Parse(Console.ReadLine()) - 1;

                    if ((index >= 0 && index < toDoList.Count))
                    {
                        toDoList[index].IsCompleted = true;
                    }

                    else
                    {
                        Console.WriteLine("Nieprawidłowy numer zadania.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Wybierz zadanie do zakończenia:");
                    string taskName = Console.ReadLine();
                    var item = toDoList.Find(t => t.Task.Equals(taskName, StringComparison.OrdinalIgnoreCase));

                    if (item != null)
                    {
                        item.IsCompleted = true;
                    }

                    else
                    {
                        Console.WriteLine("Nieprawidłowy numer zadania.");
                    }
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
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

        public static void OrderBy()
        {
            Console.WriteLine("... według: 1 <- Statusu zadań, 2 <- Alfabetycznie, 3 <- Wróć do menu głownego");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    OrderByStatus();
                    break;
                case "2":
                    OrderByName();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }

        private static void OrderByName()
        {
            List<ToDoItem> orderedList = new List<ToDoItem>();
            orderedList = toDoList.OrderBy(x => x.Task).ToList();

            foreach (ToDoItem item in orderedList)
            {
                string status = item.IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{item.Task} {status}");
            }

            toDoList = orderedList;
        }

        private static void OrderByStatus()
        {
            List<ToDoItem> orderedList = new List<ToDoItem>();
            orderedList = toDoList.OrderBy(x => x.IsCompleted).ToList();

            foreach (var item in orderedList)
            {
                string status = item.IsCompleted ? "[x]" : "[ ]";
                Console.WriteLine($"{status} {item.Task}");
            }

            toDoList =orderedList;
        }
    }
}
