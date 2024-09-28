using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItem_Console
{
    public class Program
    {
        static List<ToDoItem> toDoList = new List<ToDoItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("ToDo List:");
                ShowTasks();
                Console.WriteLine("Wybierz opcję: 1 - Dodaj zadanie, 2 - Zakończ zadanie, 3 - Usuń zadanie, 4 - Wyjdź");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        CompleteTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void ShowTasks()
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

        static void AddTask()
        {
            Console.WriteLine("Wpisz zadanie:");
            string task = Console.ReadLine();
            toDoList.Add(new ToDoItem(task));
        }

        static void CompleteTask()
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

        static void RemoveTask()
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
    }
}
