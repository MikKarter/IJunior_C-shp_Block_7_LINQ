using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Armies armies = new Armies();
            armies.ShowSquadsInfo();
            armies.Transfer();
            armies.ShowSquadsInfo();
        }
    }

    class Armies
    {
        private List<Soldier> _firstSquad = new List<Soldier>();
        private List<Soldier> _secondSquad = new List<Soldier>();

        public Armies()
        {
            _firstSquad.Add(new Soldier("Петров", "Рядовой"));
            _firstSquad.Add(new Soldier("Бляшкин", "Рядовой"));
            _firstSquad.Add(new Soldier("Сидоров", "Сержант"));
            _firstSquad.Add(new Soldier("Белый", "Сержант"));
            _firstSquad.Add(new Soldier("Носков", "Старший сержант"));
            _secondSquad.Add(new Soldier("Соболев", "Рядовой"));
            _secondSquad.Add(new Soldier("Кудрявцев", "Рядовой"));
        }


        public void Transfer()
        {
            var transferList = _firstSquad.Where(soldier => soldier.Name.StartsWith("Б"));
            _secondSquad =_secondSquad.Union(transferList).ToList();
            _firstSquad = _firstSquad.Except(transferList).ToList();
        }

        public void ShowSquadsInfo()
        {
            Console.WriteLine("Отряд 1:");
            ShowSoldiersInfo(_firstSquad);
            Console.WriteLine();
            Console.WriteLine("Отряд 2:");
            ShowSoldiersInfo(_secondSquad);
            Console.WriteLine();
        }

        private void ShowSoldiersInfo(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowSolider();
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string title)
        {
            Name = name;
            Title = title;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }

        public void ShowSolider()
        {
            Console.WriteLine($"Name: {Name}. Title {Title}.");
        }
    }
}
