using System;

namespace Task10
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string a, b, c;
            Console.WriteLine("Enter 3 lines of text:\n");  // Without \n it was breaking
            a = Console.ReadLine();
            b = Console.ReadLine(); 
            c = Console.ReadLine();
            Console.WriteLine("{0}!{1}!{2}", a, b, c);
        }
    }
}