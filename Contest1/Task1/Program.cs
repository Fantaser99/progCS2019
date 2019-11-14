using System;

namespace Task1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            long a, b;

            // Ввод и проверка данных на корректность

            if (!long.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!long.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("wrong");
                return;
            }

            Swap(ref a, ref b); // Обмен значений

            Console.WriteLine("{0} {1}", a, b); // Вывод
        }

        /// <summary>
        /// Меняет местами значения двух входящих переменных
        /// </summary>
        /// <param name="first">Целое число №1</param>
        /// <param name="second">Целое число №2</param>
        public static void Swap(ref long first, ref long second)
        {
            // Меняем значения местами с использованием промежуточного элемента, чтобы избежать,
            // хоть и маловероятного, но переполнения.

            long mid = first;
            first = second;
            second = mid;
        }
    }
}