using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public delegate int c(int x);

        static int a(int x)
        {
            Console.WriteLine($"X + 1 = {x + 1}");
            return x + 1;
        }

        static int b(int x)
        {
            Console.WriteLine($"X - 1 = {x - 1}");
            return x - 1;
        }

        public static void Main(string[] args)
        {
            c d = new c(b);
//            d += a;
            d -= b;

            Console.WriteLine(d(1));
        }
    }
}