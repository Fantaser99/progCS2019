using System;

namespace TaskC
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;

            if (!CheckInput(out a))
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!CheckInput(out b))
            {
                Console.WriteLine("wrong");
                return;
            }

            Console.WriteLine("{0:f3} {1:f3}", Perimeter(a, b), Area(a, b));
        }

        /// <summary>
        /// Вводит вещественное число с клавиатуры и проверяет на корректность
        /// </summary>
        /// <param name="number">Переменная, в которую будет записано введённое число</param>
        /// <returns><b>true</b> если ввод успешен, иначе <b>false</b>.</returns>
        private static bool CheckInput(out double number)
        {
            string inputString = Console.ReadLine();
            return double.TryParse(inputString, out number) && number > 0;
        }

        /// <summary>
        /// Вычислить периметр прямоугольника по двум сторонам
        /// </summary>
        /// <param name="side1">Сторона 1</param>
        /// <param name="side2">Сторона 2</param>
        /// <returns>Периметр</returns>
        private static double Perimeter(double side1, double side2)
        {
            return 2 * (side1 + side2);
        }

        /// <summary>
        /// Вычислить площадь прямоугольника по двум сторонам
        /// </summary>
        /// <param name="side1">Сторона 1</param>
        /// <param name="side2">Сторона 2</param>
        /// <returns>Площадь</returns>
        private static double Area(double side1, double side2)
        {
            return side1 * side2;
        }
    }
}