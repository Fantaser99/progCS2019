using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            long a, b, c;

            if (!Input(out a, out b, out c))
                return;

            int counter = 0;

            // Находим совпадение. Если совпадают все, counter будет 3, если ни одно - 0,
            // а если совпадают два числа, то counter гарантированно будет 1. Чтобы получить правильный ответ, прибавляем 1. 
            if (a == b)
                counter++;
            if (a == c)
                counter++;
            if (b == c)
                counter++;

            if (counter == 1)
                counter++;

            Console.WriteLine(counter);
        }

        private static bool Input(out long a, out long b, out long c)
        {
            a = 0;
            b = 0;
            c = 0;

            if (!long.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("wrong");
                return false;
            }

            if (!long.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("wrong");
                return false;
            }

            if (!long.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("wrong");
                return false;
            }

            return true;
        }
    }
}