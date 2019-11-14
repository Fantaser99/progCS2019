using System;

namespace TaskI
{
    class Program
    {
        /// <summary>
        /// Вывести "wrong" и завершить работу
        /// </summary>
        private static void ExitWrong()
        {
            Console.WriteLine("wrong");
            Environment.Exit(0);
        }

        /// <summary>
        /// Вводит целое число с клавиатуры и проверяет значение
        /// на принадлежность к <br/>[<paramref name="leftConstraint"/>; <paramref name="rightConstraint"/>. <br/>
        /// Если что-то не так - вызывает <see cref="ExitWrong"/> 
        /// </summary>
        /// <param name="variable">Сюда будет записано введённое с клавиатуры число</param>
        /// <param name="leftConstraint">Левая граница</param>
        /// <param name="rightConstraint">Правая граница</param>
        private static void InputAndCheck(out double variable, int leftConstraint, int rightConstraint)
        {
            string input = Console.ReadLine();
            int tmp;
            if (!int.TryParse(input, out tmp))
                ExitWrong();

            if (tmp < leftConstraint || tmp > rightConstraint)
                ExitWrong();

            variable = tmp;
        }

        static void Main(string[] args)
        {
            double n, k, r, m, t;

            InputAndCheck(out n, 10, 100);
            InputAndCheck(out k, 50, 100);
            InputAndCheck(out r, 1, 200);
            InputAndCheck(out m, 2, 10);
            InputAndCheck(out t, 5, 30);

            double perDay;

            var diff = n > r ? 0.5 : 1.25;

            perDay = Math.Min(r, n) * k + (r - n) * diff * k;

            /*
             * n > r:
             *     diff = 0.5
             *     salary = r * k
             *     penalty = (n - r) * diff
             *     sum = r * k - (n - r) * 0.5 * k
             *
             * n == r:
             *     diff = 1.25
             *     salary = r * k;
             *     penalty = 0 * diff
             *     sum = r * k;
             *
             * n < r:
             *     diff = 1.25
             *     salary = n * k
             *     bonus = (r - n) * diff
             *     sum = n * k + (r - n) * 1.25 * k
             * 
             */

            Console.WriteLine("{0:f3}", perDay * m * t);
        }
    }
}