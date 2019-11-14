using System;

namespace Test10
{
    static class Program
    {
        static void Main(string[] args)
        {
            int A;

            // Также проверяем, натуральное ли это число.
            if (!int.TryParse(Console.ReadLine(), out A) || A <= 0)
            {
                Console.WriteLine("wrong");
                return;
            }

            // Находим номер и выводим на экран.
            Console.WriteLine(FindFibonacciIndex(A));
        }

        /// <summary>
        /// Для предоставленного числа найти его номер в последовательности Фибоначчи, иначе -1.
        /// </summary>
        /// <param name="number">Искомое число</param>
        /// <returns>Номер числа в последовательности Фибоначчи. Если не состоит там, -1</returns>
        private static int FindFibonacciIndex(int number)
        {
            if (number == 1)
                return 1; // Первые 2 числа Фибоначчи = 1, номер такого принимаем за 1.

            int index = 2;

            // Так как нам не нужно знать всю последовательность, оставляем себе "окошко" из двух элементов
            int fib1 = 1, fib2 = 1;

            while (fib2 < number)
            {
                // Пока не найдем нужное число или не превысим искомое значение,
                // смещаемся вперед по последовательности Фибоначчи.
                FibonacciTick(ref fib1, ref fib2);
                index++;
            }

            if (fib2 != number)
                index = -1;

            return index;
        }

        /// <summary>
        /// По введённым двум соседним элементам последовательности Фибоначчи вычисляет следующее и "смещает"
        /// две предоставленные переменные вперед по этой последовательности
        /// </summary>
        /// <param name="fib1">Первое из двух соседних элементов последовательности</param>
        /// <param name="fib2">Второе из двух соседних элементов последовательности</param>
        private static void FibonacciTick(ref int fib1, ref int fib2)
        {
            int next = fib1 + fib2; // Вычисляем следующий элемент
            fib1 = fib2; // Сдвигаем "окошко" вперед на 1.
            fib2 = next;
        }
    }
}