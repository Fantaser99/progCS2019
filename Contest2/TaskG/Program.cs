using System;

namespace TaskG
{
    internal static class Program
    {
        /// <summary>
        /// Вывести "wrong" и завершить работу
        /// </summary>
        private static void ExitWrong()
        {
            Console.WriteLine("wrong");
            Environment.Exit(0);
        }

        private static void Main(string[] args)
        {
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 255)
                ExitWrong();

            var res = Check(n);
            Console.WriteLine(res == -1 ? "yes" : (n - res).ToString());
        }

        /// <summary>
        /// Рекурсивный цикл для проверки, помещается ли троичное число в диапазон, указанный в условии.
        ///
        /// (Посчитано на бумаге)
        /// Диапазон, указанный в условии это [0.5; 0.5] ([0.(1); 0.(1)] в троичной системе счисления)
        /// http://decimal-to-binary.com/decimal-to-binary-converter-online.html?id=16767
        /// </summary>
        /// <param name="depth">Оставшееся количество знаков</param>
        /// <returns>общее количество знаков минус номер знака, на котором число перестало попадать в диапазон.</returns>
        private static int Check(int depth)
        {
            depth--;

            int x;

            if (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x > 2)
            {
                ExitWrong();
            }

            if (x != 1)
                return depth;

            if (depth == 0)
                return -1;
            return Check(depth);
        }
    }
}