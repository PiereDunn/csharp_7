using csharp_7;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Programm
{
    static void Main(string[] args)
    {

        string path = "emp.csv";

        Repository rep = new Repository(path);

        rep.GetAllWorkers();
        Console.WriteLine(rep.Count);
        

        char main_key;

        Console.Write(
            " 1 - показать данные." +
            " 2 - заполнить таблицу." +
            " 3 - найти рабочего." +
            " 4 - удалить рабочего." +
            " 5 - сотрудники из диапазона дат. \n");
        main_key = Console.ReadKey(true).KeyChar;

        

        if (char.ToLower(main_key) == '1')       // 1 Отображение данных всей таблицы
        {
            rep.PrintDbToConsole();
        }
        else if (char.ToLower(main_key) == '2')  // 2 Заполнение таблицы
        {
            rep.AddWorker();
        }
        else if(char.ToLower(main_key) == '3')   // 3 Выбор по ID рабочего
        {
            Console.Write("Введите ID рабочего. \n");

            string workerID = Console.ReadLine();

            int number = rep.Count + 1;

            if (int.TryParse(workerID, out number))
            {
                rep.GetWorkerById(Convert.ToInt32(workerID));
            }
            else
            {
                Console.Write("ID введен неверно");
            }
        }
        else if (char.ToLower(main_key) == '4')   // 4 Удаление рабочего
        {
            Console.Write("Введите ID удаляемого рабочего. \n");

            string workerID = Console.ReadLine();

            int number = rep.Count;

            if(!int.TryParse(workerID, out number) || Convert.ToInt32(workerID) > number || Convert.ToInt32(workerID) <= 0)
            {
                Console.Write("ID введен неверно");
            }
            else if (int.TryParse(workerID, out number))
            {
                rep.DeleteWorker(Convert.ToInt32(workerID));
            }
        }
        else if (char.ToLower(main_key) == '5')   // 5 Рабочие из диапазона дат
        {
            string dateFrom = string.Empty;
            string dateTo = string.Empty;

            Console.Write("\nВведите первую дату по примеру: 01.01.2024\n");
            dateFrom += $"{Console.ReadLine()}";

            Console.Write("\nВведите время первой даты по примеру: 10:10\n");
            dateFrom += $" {Console.ReadLine()}";


            Console.Write("\nВведите вторую дату по примеру: 01.01.2024\n");
            dateTo += $"{Console.ReadLine()}";

            Console.Write("\nВведите время второй даты по примеру: 10:10\n");
            dateTo += $" {Console.ReadLine()}";

            if (DateTime.TryParse(dateFrom, out DateTime date))
            {
                rep.GetWorkersBetweenTwoDates(Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo));
            }
            else
            {
                Console.WriteLine("Дата введена не корректно");
            }
        }
    }
}