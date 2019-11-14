using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong number;

            // Также проверяем, что оно не только целое, но и натуральное
            if (!ulong.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("wrong");
                return;
            }

            Console.WriteLine(FindBinPower(number) ? "YES" : "NO");
        }

        /// <summary>
        /// Проверка, является ли число точной степенью двойки
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <returns>true если является точной степенью двойки, иначе false.</returns>
        private static bool FindBinPower(ulong number)
        {
            // Пока делится на 2, делим
            while (number % 2 == 0 && number > 1)
                number /= 2;
            // Если number - степень двойки, останется 1, иначе другое число.
            return number == 1;
        }
    }
}