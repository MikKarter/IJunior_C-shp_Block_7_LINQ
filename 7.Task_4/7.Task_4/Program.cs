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
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private int _maxTopPlayers = 3;

        public Database()
        {
            _players.Add(new Player("Хабибов Хабиб Хабибович ", 20, 25));
            _players.Add(new Player("Колбасин Вова Викторович ", 30, 35));
            _players.Add(new Player("Хлебкин Вадим Петрович ", 16, 21));
            _players.Add(new Player("Абахин Алам Алимович ", 17, 22));
            _players.Add(new Player("Федоров Сергей Алексеевич ", 18, 24));
            _players.Add(new Player("Соловьёв Виктор Сергеевич ", 34, 39));
            _players.Add(new Player("Носков Султан Никитович ", 70, 55));
            _players.Add(new Player("Юдин Кирилл Николаевич ", 43, 42));
            _players.Add(new Player("Папонин Алексей Викторович ", 10, 31));
            _players.Add(new Player("Алахич Алах Аламович ", 11, 4));
            _players.Add(new Player("Аринян Армен Арменович ", 100, 132));
            _players.Add(new Player("Гарбов Александр Тимурович ", 50, 77));
            _players.Add(new Player("Головач Пётр Александрович ", 29, 67));
        }

        public void Work()
        {
            const int Top3ByLevel = 1;
            const int Top3ByPower = 2;
            const int ShowPlayers = 3;
            const int FinishProgramm = 4;

            bool isWork = true;

            while (isWork == true)
            {
                Console.WriteLine($"{Top3ByLevel} - Топ 3 по уровню");
                Console.WriteLine($"{Top3ByPower} - Топ 3 по силе");
                Console.WriteLine($"{ShowPlayers} - Вывести список игроков");
                Console.WriteLine($"{FinishProgramm} - Завершение работы программы");
                int.TryParse(Console.ReadLine(), out int userInput);

                switch (userInput)
                {
                    case Top3ByLevel:
                        FindTop3ByLevel();
                        break;
                    case Top3ByPower:
                        FindTop3ByPower();
                        break;
                    case ShowPlayers:
                        ShowPlayerList();
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

        private void FindTop3ByLevel()
        {
            var playersByLevel = _players.OrderByDescending(_players => _players.Level).Take(_maxTopPlayers);

            foreach (var player in playersByLevel)
            {
                player.ShowInfo();
            }
        }

        private void FindTop3ByPower()
        {
            var playersByPower = _players.OrderByDescending(_players => _players.Power).Take(_maxTopPlayers);

            foreach (var player in playersByPower)
            {
                player.ShowInfo();
            }
        }

        private void ShowPlayerList()
        {
            foreach (var player in _players)
            {
                player.ShowInfo();
            }
        }
    }

    class Player
    {
        public Player(string nickname, int level, int power)
        {
            Nickname = nickname;
            Level = level;
            Power = power;
        }

        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }


        public void ShowInfo()
        {
            Console.WriteLine($"{Nickname}, уровень  - {Level}, сила - {Power}.");
        }
    }
}
