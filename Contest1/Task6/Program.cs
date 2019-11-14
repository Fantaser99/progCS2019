using System;

namespace Task6
{
    static class Program
    {
        static void Main(string[] args)
        {
            double a;
            int n;

            if (!Input(out a, out n))
                return;

            double res = 1;
            double currentItem = 1; // a[i]

            for (int i = 0; i < n; i++)  // res += a[i]
            {
                currentItem *= a;
                res += currentItem;
            }

            Console.WriteLine("{0:f3}", res);
        }
        
        private static bool Input(out double a, out int n)
        {
            a = 0;
            n = 0;

            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("wrong");
                return false;
            }

            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("wrong");
                return false;
            }

            return true;
        }
    }
}