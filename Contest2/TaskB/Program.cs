using System;

namespace TaskB
{
    class Program
    {
        static void Main(string[] args)
        {
            int Base;
            if (!int.TryParse(Console.ReadLine(), out Base) || Base < 2 || Base > 9)
            {
                Console.WriteLine("wrong");
                return;
            }

            int number;
            if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.WriteLine("wrong");
                return;
            }

            int res = ToDecimal(number, Base);
            if (res != -1) // Некорректное число
                Console.WriteLine(res);
            else
            {
                Console.WriteLine("wrong");
            }
        }

        /// <summary>
        /// Конвертировать число <paramref name="number"/> записанное в системе счисления с основанием <paramref name="base"/> в десятичную систему
        /// </summary>
        /// <param name="number">Число в системе счисления с основанием <paramref name="base"/></param>
        /// <param name="base">Основание системы счисления</param>
        /// <returns>Число в десятичной системе счисления или -1 если число некорректно (не соответствует предоставленной системе счисления).</returns>
        private static int ToDecimal(int number, int @base)
        {
            int res = 0;
            int power = (int) Math.Log10(number);

            while (number > 0 && power >= 0)
            {
                int tmp = number / (int) Math.Pow(10, power);
                if (tmp >= @base)
                    return -1;

                number %= (int) Math.Pow(10, power);
                res += tmp * (int) Math.Pow(@base, power);
                power--;
            }

            return res;
        }
    }
}