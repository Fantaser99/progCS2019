using System;

namespace Task4
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            long a, b, c;

            if (!Input(out a, out b, out c))
                return;

            string result = CheckTriangleType(a, b, c);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Проверяет тип треугольника - остроугольный, тупоугольный, прямой или невозможный
        /// </summary>
        /// <param name="a">Сторона треугольника</param>
        /// <param name="b">Сторона треугольника</param>
        /// <param name="c">Сторона треугольника</param>
        /// <returns>Тип треугольника: impossible/obtuse/acute/right.</returns>
        private static string CheckTriangleType(long a, long b, long c)
        {
            // sort max >= mid >= min

            double max, mid, min;

            max = (a >= b && a >= c) ? a : (b >= c ? b : c);
            mid = (a <= b && a >= c || a >= b && a <= c) ? a : (b <= a && b >= c || b >= a && b <= c ? b : c);
            min = (a <= b && a <= c) ? a : (b <= c ? b : c);

            // max^2 = mid^2 + min^2 - 2 * mid * min * cos(d)
            // cos(d) = (max^2 - mid^2 - min^2) / (-2 * mid * min)

            double cosD = (max * max - mid * mid - min * min) / (-2 * mid * min);

            return (min + mid > max)
                ? (cosD < 0 ? "obtuse" : (cosD > 0 ? "acute" : "right")
                )
                : "impossible";
        }

        private static bool Input(out long a, out long b, out long c)
        {
            a = 0;
            b = 0;
            c = 0;

            // При вводе проверяем, является ли число натуральным
            
            if (!long.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.WriteLine("wrong");
                return false;
            }

            if (!long.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.WriteLine("wrong");
                return false;
            }

            if (!long.TryParse(Console.ReadLine(), out c) || c <= 0)
            {
                Console.WriteLine("wrong");
                return false;
            }

            return true;
        }
    }
}