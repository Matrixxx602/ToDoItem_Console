namespace ToDoItem_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuOptions.LoadTasks();

            while (true)
            {
                Console.WriteLine("ToDo List:");
                MenuOptions.ShowTasks();
                Console.WriteLine("Wybierz opcję: 1 <- Dodaj zadanie, 2 <- Zakończ zadanie..., 3 <- Usuń zadanie,");
                Console.WriteLine("4 <- Uporządkuj zadania..., 5 <- Zapisz i Wyjdź");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MenuOptions.AddTask();
                        break;
                    case "2":
                        MenuOptions.CompleteTask();
                        break;
                    case "3":
                        MenuOptions.RemoveTask();
                        break;
                    case "4":
                        MenuOptions.OrderBy();
                        break;
                    case "5":
                        MenuOptions.SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }
    }
}

//Interfejs graficzny: Rozważ użycie Windows Forms lub WPF do stworzenia interfejsu użytkownika.

//Sortowanie i filtrowanie: Dodaj opcje sortowania i filtrowania zadań według daty lub statusu.