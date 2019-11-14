using System;
using System.Numerics;

namespace TaskD
{
    static class Program
    {
        static void Main(string[] args)
        {
            double x;
            int n;

            if (!double.TryParse(Console.ReadLine(), out x) || x < -1000 | x > 1000)
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 1000)
            {
                Console.WriteLine("wrong");
                return;
            }

            Console.WriteLine("{0:f3}", Sin(x, n));
        }

        /// <summary>
        /// Вычислить синус угла <paramref name="x"/> по ряду Тейлора с числом слагаемых <paramref name="n"/>. 
        /// </summary>
        /// <param name="x">Угол в радианах</param>
        /// <param name="n">Количество слагаемых</param>
        /// <returns>sin(<paramref name="x"/>)</returns>
        private static double Sin(double x, int n)
        {
            // Приводим x в адекватные рамки (от -2pi до +2pi)
            x = Math.Abs(x) % (2 * Math.PI) * Math.Sign(x);

            double sin = 0;
            for (int i = 0; i <= n; i++)
            {
                var factorial = Factorial(2 * i + 1);

                // Переполнение double
                if (Math.Abs(factorial) < double.Epsilon)
                    break;

                // Формула ряда Тейлора
                sin += Math.Pow(-1, i) * (Math.Pow(x, 2 * i + 1) / (double) factorial);
            }

            return sin;
        }

        /// <summary>
        /// Найти факториал числа <paramref name="n"/>
        /// </summary>
        /// <returns><paramref name="n"/>!, но при переполнении <b>double</b> - 0.</returns>
        private static double Factorial(int n)
        {
            BigInteger res = 1;
            for (int i = 2; i <= n; i++)
            {
                res *= i;
            }

            // Если полученный факториал не помещается в double, возвращаем 0.
            return res < (BigInteger) double.MaxValue ? (double) res : 0;
        }
    }
}
