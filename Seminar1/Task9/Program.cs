using System;

namespace Task9
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            double a, b;
            Console.WriteLine("Enter 2 float numbers, one on a line:\n");
            if (double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Sum of fractions = {0:f3}", (a % 1) + (b % 1));
            }
            else
            {
                Console.WriteLine("Parse error! Required format: \"[0-9]*(\\.[0-9]+)?\" (aka double)");
            }
        }
    }
}