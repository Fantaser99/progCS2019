using System;

namespace Task11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] arr = new string[3]; 
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter a line of text: ");
                arr[i] = Console.ReadLine();
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-{0}-", arr[i]);
            }
        }
    }
}