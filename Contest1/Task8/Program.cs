using System;

namespace Task8
{
    static class Program
    {
        static void Main(string[] args)
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("wrong");
                return;
            }

            int first, second;

            // Ищем кубы и выводим. Если не нашлись - impossible.
            if (FindCubes(n, out first, out second))
            {
                Console.WriteLine("{0} {1}", first, second);
            }
            else
            {
                Console.WriteLine("impossible");
            }
        }

        /// <summary>
        /// Найти 2 числа, сумма кубов которых равняется переданному числу n.
        /// </summary>
        /// <param name="n">Искомая сумма кубов</param>
        /// <param name="first">Здесь будет большее число</param>
        /// <param name="second">А здесь меньшее</param>
        /// <returns>Нашлись ли искомые кубы</returns>
        private static bool FindCubes(int n, out int first, out int second)
        {
            first = 0;
            second = 0;

            
            // Ищем максимальное число, куб которого помещается в n.
            while (first * first * first < n)
            {
                first++;
            }

            int max = first;

            // Перебираем все пары, пока не найдем нужную 
            // т.к. first и second передаются через out, при выходе в них останутся нужные значения
            for (first = max; first > 0; first--)
            {
                for (second = 0; second < max; second++)
                {
                    if ((first * first * first + second * second * second) == n) // Нашли
                        return true;
                }
            }

            // Если не нашли, возвращаем false

            return false;
        }
    }
}