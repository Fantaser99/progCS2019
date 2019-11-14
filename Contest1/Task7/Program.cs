using System;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;

            if (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("wrong");
                return;
            }

            double cur = 1;
            double res = 1;
            
            // Проходим по формуле

            for (int i = 1; i <= N; i++)
            {
                cur *= i;  // Домножаем на номер элемента, на каждом шагу получая i!
                res += 1 / cur;
            }

            Console.WriteLine("{0:f6}", res);
        }
    }
}