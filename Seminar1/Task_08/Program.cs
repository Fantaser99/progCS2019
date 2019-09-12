using System;

namespace Task_08
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int x, y;
            
            Console.Write("Enter X: ");
            var input = Console.ReadLine();
            int.TryParse(input, out x);

            Console.Write("Enter Y: ");
            input = Console.ReadLine();
            int.TryParse(input, out y);

            Console.WriteLine("(X - Y) = {0}", x - y);
            Console.WriteLine("(X * Y) = {0}", x * y);
            Console.WriteLine("(X / Y) = {0}", x / y);
            Console.WriteLine("(X % Y) = {0}", x % y);
            Console.WriteLine("(X << Y) = {0}", x << y);
            Console.WriteLine("(X >> Y) = {0}", x >> y);
        }
    }
}