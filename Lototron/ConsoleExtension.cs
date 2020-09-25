using System;

namespace SimLoto
{
    public static partial class ConsoleExtension
    {
        public static void WriteLine(ConsoleColor color, string format, params object[] arg)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg);
            Console.ForegroundColor = tempColor;
        }

        public static bool BooleanQuestion(string question, ConsoleColor color = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(question);
            Console.ForegroundColor = tempColor;
            var firstSymbol = (char)Console.ReadKey().KeyChar;

            if (firstSymbol.Equals('Д') || firstSymbol.Equals('д') || firstSymbol.Equals('Y') || firstSymbol.Equals('y')|| firstSymbol.Equals('l')
                || firstSymbol.Equals('L'))
            {
                return true;
            }

            return false;
        }
    }
}