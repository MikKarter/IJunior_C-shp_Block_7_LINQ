using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            _patients.Add(new Patient("Хабибов Хабиб Хабибович ", 20, "Ангина"));
            _patients.Add(new Patient("Колбасин Вова Викторович ", 30, "Коронавирус"));
            _patients.Add(new Patient("Хлебкин Вадим Петрович ", 16, "Ангина"));
            _patients.Add(new Patient("Абахин Алам Алимович ", 17, "Насморк"));
            _patients.Add(new Patient("Федоров Сергей Алексеевич ", 18, "Коронавирус"));
            _patients.Add(new Patient("Соловьёв Виктор Сергеевич ", 34, "Насморк"));
            _patients.Add(new Patient("Носков Султан Никитович ", 70, "Ангина"));
            _patients.Add(new Patient("Юдин Кирилл Николаевич ", 43, "Ангина"));
            _patients.Add(new Patient("Папонин Алексей Викторович ", 10, "Коронавирус"));
            _patients.Add(new Patient("Алахич Алах Аламович ", 11, "Насморк"));
            _patients.Add(new Patient("Аринян Армен Арменович ", 100, "Коронавирус"));
            _patients.Add(new Patient("Гарбов Александр Тимурович ", 50, "Насморк"));
            _patients.Add(new Patient("Головач Пётр Александрович ", 29, "Ангина"));
        }

        public void Work()
        {
            const int ShowPatientsBySurname = 1;
            const int ShowPatientsByAge = 2;
            const int FindPatientByDisease = 3;
            const int FinishProgramm = 4;

            bool isWork = true;

            while (isWork == true)
            {
                Console.WriteLine($"{ShowPatientsBySurname} - Отсортировать по фамилии");
                Console.WriteLine($"{ShowPatientsByAge} - Отсортировать по возрасту");
                Console.WriteLine($"{FindPatientByDisease} - Поиск по заболеванию");
                Console.WriteLine($"{FinishProgramm} - Завершение работы программы");
                int.TryParse(Console.ReadLine(), out int userInput);

                switch (userInput)
                {
                    case ShowPatientsBySurname:
                        ShowListPatientsSortBySurname();
                        break;
                    case ShowPatientsByAge:
                        ShowListPatientsSortByAge();
                        break;
                    case FindPatientByDisease:
                        this.FindPatientByDisease();
                        break;
                    case FinishProgramm:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Нет такой команды");
                        break;
                }
            }
        }

        private void ShowListPatientsSortBySurname()
        {
            var patientBySurname = _patients.OrderBy(_patients => _patients.Initials);

            foreach (var patient in patientBySurname)
            {
                patient.ShowDetails();
            }
        }

        private void ShowListPatientsSortByAge()
        {
            var patientByAge = _patients.OrderBy(_patients => _patients.Age);

            foreach (var patient in patientByAge)
            {
                patient.ShowDetails();
            }
        }

        private void FindPatientByDisease()
        {
            string disease;
            Console.WriteLine("Введите заболевание:");
            disease = Console.ReadLine();

            var patientByAge = _patients.Where(patient => patient.Disease == disease);

            foreach (var patient in patientByAge)
            {
                patient.ShowDetails();
            }
        }
    }

    class Patient
    {
        public Patient(string initials, int age, string disease)
        {
            Initials = initials;
            Age = age;
            Disease = disease;
        }

        public string Initials { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public void ShowDetails()
        {
            Console.WriteLine($"{Initials}, возраст  - {Age} лет, заболевание - {Disease}.");
        }
    }
}
