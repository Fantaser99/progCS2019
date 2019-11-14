using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskE_new
{
    static class Program
    {
        private static List<ulong> cache; 
        
        static void Main(string[] args)
        {
            cache = new List<ulong> {0, 1, 1};
            
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("wrong");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                int idx;
                if (!int.TryParse(Console.ReadLine(), out idx)) // Try and check negative
                {
                    Console.WriteLine("wrong");
                    continue;
                }

                Console.WriteLine(Fib(idx) % Math.Pow(2, 30));
            }
        }

        public static ulong Fib(int n)
        {
            if (n < cache.Count)
                return cache[n];
            ulong tmp = Fib(n - 2) + Fib(n - 1);
            cache.Add(tmp);
            return cache[n];
        }
    }
}