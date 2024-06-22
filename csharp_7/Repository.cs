using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csharp_7
{
    class Repository
    {
        int ID = 1;
        private Worker[] workers;
        int index;
        private string path;
        


        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            int firstID;
            int secondID;
            DateTime firstDateTime;
            DateTime secondDateTime;

            if (dateFrom <= dateTo) //Определение наименьшей и наибольшей дат для уменьшения кол-ва кода в 2 раза
            {
                firstDateTime = dateFrom;
                secondDateTime = dateTo;
            }
            else
            {
                firstDateTime = dateTo;
                secondDateTime = dateFrom;
            }

            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DateAdd == firstDateTime)
                {
                    firstID = i + 1;

                    for (int j = 0; j < workers.Length; j++)
                    {
                        if (workers[j].DateAdd == secondDateTime)
                        {
                            secondID = j + 1;

                            for (int k = 0; k < workers.Length; k++)
                            {
                                if (firstID <= workers[k].Id && workers[k].Id <= secondID)
                                {
                                    Console.WriteLine(workers[k].Print());
                                }
                            }
                        }
                    }
                }
            }
            return workers;
        }


        /// <summary>
        /// Добавление в файл нового рабочего
        /// </summary>
        public void AddWorker()
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                char key;

                do
                {
                    string note = string.Empty;

                    string nowDate = DateTime.Now.ToString();
                    note += $"{nowDate}#";

                    Console.Write("\nВведите Ф.И.О. сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите возраст сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите рост сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите Дату Рождения сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите Место рождения сотрудника: ");
                    note += $"{Console.ReadLine()}";

                    sw.WriteLine(note);
                    Console.Write("Продолжить д/н"); key = Console.ReadKey(true).KeyChar;

                } while (char.ToLower(key) == 'д');
            }
        }


        /// <summary>
        /// Чтение всего файла с рабочими и возврат массива данных
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] lines = sr.ReadToEnd().Split('\n');    //Массив строк

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != string.Empty)
                        {
                            string[] words = lines[i].Split('#');       //Массив слов

                            AddWorkerToArray(new Worker(
                                ID,                            //ID
                                Convert.ToDateTime(words[0]),  //Дата добавления
                                words[1],                      //Имя
                                words[2],                      //Возраст
                                words[3],                      //Рост
                                words[4],                      //Дата рождения
                                words[5]));                    //Город
                            ID++;
                        }
                    }
                }
            }
            return workers;
        }


        /// <summary>
        /// Поиск рабочего по ID
        /// </summary>
        /// <param name="id"></param>
        public void GetWorkerById(int id)
        {
            if (id < workers.Length + 1 && id > 0)
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    if (workers[i].Id == id)
                    {
                        Console.WriteLine(workers[i].Print());
                    }
                }
            }
            else
            {
                Console.WriteLine("ID не найден");
            }
        }


        /// <summary>
        /// Удаление рабочего
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode))
            {
                if (id < workers.Length + 1 && id > 0)
                {
                    for (int i = 0; i < workers.Length; i++)  //Прочесывание массива рабочих для нахождения нужного
                    {
                        if (workers[i].Id == id)
                        {
                            for(int j = 0; j < Count; j++) //Добавление всех рабочих, кроме нужного (workers.Length < workers.Length - 1 < Count)
                            {
                                if (workers[j].Id != id)   //Count - сумма всех сотруников
                                {
                                    sw.WriteLine(workers[j].PrintDefault().TrimEnd());
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ID не найден");
                }
            }
        }





        /// <summary>
        /// Ну, репозиторий
        /// </summary>
        /// <param name="Path"></param>
        public Repository(string Path)
        {
            path = Path;
            index = 0;
            workers = new Worker[2];
        }


        /// <summary>
        /// Увеличение размера массива рабочих
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if(Flag)
            {
                Array.Resize(ref workers, workers.Length * 2);
            }
        }


        /// <summary>
        /// Добавление нового рабочего в массив
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorkerToArray(Worker worker)
        {
            Resize(index >= workers.Length);
            workers[index] = worker;
            index++;
        }


        /// <summary>
        /// Возвращение суммы всех сотрудников
        /// </summary>
        public int Count {  get { return index; } }


        /// <summary>
        /// Печать в консоль массива рабочих
        /// </summary>
        public void PrintDbToConsole()
        {
            for(int i = 0; i < index; i++)
            {
                Console.WriteLine(workers[i].Print());
            }
        }


        /// <summary>
        /// База данных сотрудников
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Worker this[int index]
        {
            get { return workers[index]; }
            set { workers[index] = value; }
        }
    }
}