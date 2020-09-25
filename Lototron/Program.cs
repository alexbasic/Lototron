using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimLoto
{
    partial class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ConsoleExtension.WriteLine(ConsoleColor.Yellow, "========= Лото 5 из 15 =========\r\n");
                ConsoleExtension.WriteLine(ConsoleColor.Red, "Натренируй удачу!\r\n");

                Console.WriteLine("Начинаем новый розыгрыш.\r\n");

                bool isWin = false;
                bool runGame = true;
                var ticketNumber = 0;

                var loto = new Loto();

                while (!isWin && runGame)
                {
                    var ticket = InputNumbers(5);
                    ticketNumber++;

                    isWin = loto.GuessNumbers(ticket);

                    if (isWin)
                    {
                        ConsoleExtension.WriteLine(ConsoleColor.Red, "=========================");
                        ConsoleExtension.WriteLine(ConsoleColor.Yellow, "Bingo!!!");
                        ConsoleExtension.WriteLine(ConsoleColor.Green, "ВЫ ВЫИГРАЛИ !!!");
                        Console.Write("Номера: /");
                        foreach (var item in ticket) { Console.Write("{0}, ", item); }
                        Console.WriteLine("/");
                        ConsoleExtension.WriteLine(ConsoleColor.Blue, "=========================\r\n");
                        ConsoleExtension.WriteLine(ConsoleColor.White, "Для продолжения нажми любую клавишу.");
                        Console.ReadKey();
                        break;
                    }
                    else if (loto.CountIntersects(ticket) == 3)
                    {
                        ConsoleExtension.WriteLine(ConsoleColor.Yellow, "=========================");
                        ConsoleExtension.WriteLine(ConsoleColor.Yellow, "Маленький выигрыш");
                        ConsoleExtension.WriteLine(ConsoleColor.Yellow, "Совпали три");
                        ConsoleExtension.WriteLine(ConsoleColor.Yellow, "=========================\r\n");
                    }
                    else
                    {
                        Console.WriteLine("Билет не выиграл...");
                    }

                    runGame = ConsoleExtension.BooleanQuestion("\r\nПопробуй другой билет! (Да/Нет)", ConsoleColor.Yellow);
                    Console.WriteLine("\r\n");
                }
            }

            Console.ReadLine();
        }

        static IEnumerable<int> InputNumbers(int count)
        {
            Console.WriteLine("Введи 5 чисел.");
            var sequece = new List<int>();
            var isNumber = false;
            var isNotUniq = false;
            for (var i = 0; i < count; i++)
            {
                var number = 0;
                do
                {
                    Console.Write("Число {0} >", i + 1);
                    isNumber = int.TryParse(Console.ReadLine(), out number);
                    isNotUniq = sequece.Contains(number);
                    if (isNotUniq) Console.WriteLine("Это число уже введено!");
                } while (!isNumber || isNotUniq);
                sequece.Add(number);
            }

            return sequece;
        }
    }
}