using System;

namespace Project1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            uint n;
            string line;
            do
            {
                Console.Write("Enter fibonacci's number index: ");
                line = Console.ReadLine();
            } while (!uint.TryParse(line, out n));

            Console.WriteLine("fib({0}) = {1}", n, GetFibNumber(n));
        }

        private static uint GetFibNumber(uint n)
        {
            double b = Math.Pow((1 + Math.Sqrt(5)) / 2, n) - Math.Pow((1 - Math.Sqrt(5)) / 2, n);
            return (uint) (b / Math.Sqrt(5) + 0.5);
        }
    }
}