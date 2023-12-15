using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//У нас есть список всех преступников.
//В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность.
//Вашей программой будут пользоваться детективы.
//У детектива запрашиваются данные (рост, вес, национальность), и детективу выводятся все преступники, которые подходят под эти параметры, но уже заключенные под стражу выводиться не должны.

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DetectiveSoft prog = new DetectiveSoft();
        }
    }

    class DetectiveSoft
    {
        private List<Criminal> _criminals = new List<Criminal>
        {
            new Criminal("Vasya", 190, 90, "Russian", true),
            new Criminal("Petya", 190, 100, "Russian", false),
            new Criminal("Masha", 180, 85, "Russian", true),
            new Criminal("Natasha", 192, 89, "Russian", false),
            new Criminal("Kostya", 191, 101, "Russian", false),
            new Criminal("Misha", 175, 77, "Russian", true),
            new Criminal("Dima", 201, 110, "Russian", false)
        };

        public DetectiveSoft() 
        {
            SortCriminals();
        }

        public void SortCriminals()
        {
            bool isWorked = true;

            while (isWorked)
            {
                Console.WriteLine("Pls, input height:");
                int.TryParse(Console.ReadLine(), out int height);
                Console.WriteLine("Pls, input weight:");
                int.TryParse(Console.ReadLine(), out int weight);
                Console.WriteLine("Pls, input nationality:");
                string nationality = Console.ReadLine().ToLower();

                var filteredCriminals = _criminals.Where(criminal => criminal.Height > height && criminal.Weigth>weight && criminal.Nationality.ToLower() == nationality.ToLower() && criminal.IsGuadred == false);

                foreach (var criminal in filteredCriminals)
                {
                    criminal.ShowInfo();
                }
            }
        }
    }

    class Criminal
    {
        public Criminal(string name, int height, int weight, string nationality, bool isGuarded)
        {
            FullName = name;
            Height = height;
            Weigth = weight;
            Nationality = nationality;
            IsGuadred = isGuarded;
        }

        public string FullName { get; private set; }
        public int Height { get; private set; }
        public int Weigth { get; private set; }
        public string Nationality { get; private set; }
        public bool IsGuadred { get; private set; }
        
        public void ShowInfo()
        {
            Console.WriteLine(FullName);
            Console.WriteLine("Heighs:" + Height);
            Console.WriteLine("Weight:" + Weigth);
            Console.WriteLine("Nationality:" + Nationality);
            
            if (IsGuadred)
            {
                Console.WriteLine("Is Guarded\n");
            }
            else
            {
                Console.WriteLine("Hidding\n");
            }            
        }
    }
}
