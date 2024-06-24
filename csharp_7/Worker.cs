
namespace csharp_7
{
    struct Worker
    {
        /// <summary>
        /// Номер работника
        /// </summary>
        public int Id {  get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }

        /// <summary>
        /// Имя работника
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Возраст работника
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Рост работника
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Дата рождения работника
        /// </summary>
        public string Birth { get; set; }

        /// <summary>
        /// Место рождения работника
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// Вывод данных о работнике
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return
                $"ID: {Id}. Дата добавления: {DateAdd.ToString("g")}, Имя: {FIO}, Возраст: {Age}, Рост: {Height}, Дата рождения: {Birth}, Место рождения: {City}";
        }

        public string PrintDefault()
        {
            return
                $"{DateAdd.ToString("g")}#{FIO}#{Age}#{Height}#{Birth}#{City}";
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DateAdd"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="Birth"></param>
        /// <param name="City"></param>
        public Worker(int Id, DateTime DateAdd, string FIO, string Age, string Height, string Birth, string City)
        {
            this.Id = Id;
            this.DateAdd = DateAdd;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.Birth = Birth;
            this.City = City;
        }

        /// <summary>
        /// 6 параметров
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DateAdd"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="Birth"></param>
        public Worker(int Id, DateTime DateAdd, string FIO, string Age, string Height, string Birth) :
            this(Id, DateAdd, FIO, Age, Height, Birth, String.Empty)
        {

        }

        /// <summary>
        /// 5 параметров
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DateAdd"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        public Worker(int Id, DateTime DateAdd, string FIO, string Age, string Height) :
           this(Id, DateAdd, FIO, Age, Height, String.Empty, String.Empty)
        {

        }

        /// <summary>
        /// 4 параметра
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DateAdd"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        public Worker(int Id, DateTime DateAdd, string FIO, string Age) :
          this(Id, DateAdd, FIO, Age, String.Empty, String.Empty, String.Empty)
        {

        }

        /// <summary>
        /// 3 параметра
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DateAdd"></param>
        /// <param name="FIO"></param>
        public Worker(int Id, DateTime DateAdd, string FIO) :
          this(Id, DateAdd, FIO, String.Empty, String.Empty, String.Empty, String.Empty)
        {

        }
    }
}
