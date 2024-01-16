using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Archive archive = new Archive();
            archive.ShowNamesAndRanks();
        }
    }

    class Archive
    {
        private List<Soldier> _soldiers;

        public Archive()
        {
            _soldiers = new List<Soldier>();
            _soldiers.Add(new Soldier("Петров", "Рядовой", "Автомат", 10));
            _soldiers.Add(new Soldier("Иванов", "Рядовой", "Автомат", 11));
            _soldiers.Add(new Soldier("Сидоров", "Сержант", "Гранатомёт", 12));
            _soldiers.Add(new Soldier("Белый", "Сержант", "Пулемёт", 13));
            _soldiers.Add(new Soldier("Носков", "Старший сержант", "Пистолет", 22));
        }

        public void ShowNamesAndRanks()
        {
            var sortedSoldier = from Soldier soldier in _soldiers
                                select new
                                {
                                    name = soldier.Name,
                                    title = soldier.Title
                                };

            foreach (var soldier in sortedSoldier)
            {
                Console.WriteLine($"Фамилия: {soldier.name}. Звание: {soldier.title}.");
            }
        }
    }

    class Soldier
    {
        private string _armament;
        private int _lifespan;

        public Soldier(string name, string title, string armament, int lifespan)
        {
            Name = name;
            Title = title;
            _armament = armament;
            _lifespan = lifespan;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
    }
}
