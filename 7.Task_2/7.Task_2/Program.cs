using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();
            prison.ShowList();
            prison.Amnistia();
            Console.WriteLine("\nПроизошла амнистия!\n");
            prison.ShowList();
        }
    }

    class People
    {
        private string _fullName;
        private string _crimeName;
        public People(string fullname, char crime)
        {
            _fullName = fullname;
            CrimeType = crime;

            if (CrimeType == 'A')
            {
                _crimeName = "Антиправительственное";
            }
            else
            {
                _crimeName = "Другое";
            }
        }

        public char CrimeType { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine(_fullName + " - " + _crimeName);
        }
    }

    class Prison
    {
        private List<People> _prisons = new List<People>();

        public Prison()
        {
            _prisons.Add(new People("Иванов Иван Иванович", 'A'));
            _prisons.Add(new People("Петров Пётр Петрович", 'B'));
            _prisons.Add(new People("Евгеньев Евгений Евгеньевич", 'A'));
            _prisons.Add(new People("Фамилия Имя Отчество", 'C'));
            _prisons.Add(new People("Сидоров Сидр Сидорович", 'A'));
        }

        public void Amnistia()
        {
           _prisons = _prisons.Where(people => people.CrimeType != 'A').ToList();
        }

        public void ShowList()
        {
            for (int i = 0; i < _prisons.Count; i++)
            {
                _prisons[i].ShowInfo();
            }
        }
    }
}
