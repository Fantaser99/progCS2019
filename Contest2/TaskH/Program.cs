using System;

namespace TaskH
{
    class Program
    {
        /// <summary>
        /// Вывести "wrong" и завершить работу
        /// </summary>
        static void ExitWrong()
        {
            Console.WriteLine("wrong");
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1 || n >= 2000000000)
                ExitWrong();

            Console.WriteLine(IsPrime(n) ? "prime" : "composite");
        }

        /// <summary>
        /// Проверяет число <paramref name="n"/> на простоту
        /// </summary>
        /// <param name="n">Число >= 1.</param>
        /// <returns><b>true</b> если число <paramref name="n"/> простое, иначе <b>false</b>.</returns>
        static bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0 && n != i)
                    return false;
            }

            return true;
        }
    }
}