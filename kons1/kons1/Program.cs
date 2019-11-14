using System;
using System.Collections.Generic;
using System.Globalization;

namespace kons1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n, a, b, k;

                n = GetNumber("Введите длину массива", 1, int.MaxValue);
                a = GetNumber("Введите a", int.MinValue, int.MaxValue);
                b = GetNumber("Введите b", a, int.MaxValue);
                k = GetNumber("Введите k", int.MinValue, int.MaxValue);

                Random rnd = new Random();

                List<int> array = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    array.Add(rnd.Next(a, b));
                }

                Console.Write("Сгенерированный массив: ");
                foreach (var el in array)
                {
                    Console.Write("{0} ", el);
                }

                Console.WriteLine();

                try
                {
                    int result = GetMinGreaterThan(array, k);
                    Console.WriteLine("Найденный элемент: {0}", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static int GetMinGreaterThan(List<int> array, int constraint)
        {
            int result = int.MaxValue;
            foreach (var el in array)
            {
                if (el > constraint && el < result)
                    result = el;
            }

            if (result == int.MaxValue)
                throw new Exception("Элемент не найден.");

            return result;
        }

        private static int GetNumber(string prompt, int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write("{0}: ", prompt);
                try
                {
                    int tmp = int.Parse(Console.ReadLine() ?? throw new Exception("Некорректный ввод"));
                    if (tmp >= minValue && tmp <= maxValue)
                        return tmp;
                    else
                    {
                        throw new Exception("Введённое значение не соответствует требуемым условиям.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}