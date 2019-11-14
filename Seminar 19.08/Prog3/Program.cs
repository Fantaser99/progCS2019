/* 
Дисциплина: "Программирование"
Группа: БПИ196/1
Студент: Якшибаев Арыслан Азаматович
Задача:
Вычислить площадь под графиком функции X^2 на отрезке [0;A]
при помощи метода трапеций, вещественная точка A и шаг интегрирования delta задаются с клавиатуры.
 * Чтобы организовать проверку корректности введённых данных, определите ограничения на значения А и delta.
 * Как вычисляется значение, добавляемое к интегральной сумме на каждом шаге.
 * Определите условие выхода из цикла формирования интегральной суммы.
Дата: 2019.09.19
*/

using System;

namespace Prog3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            double a, delta;

            double x = 0;
            bool ready = false;

            do
            {
                Console.Write("Введите A (от 0 до 10): ");
                ready = double.TryParse(Console.ReadLine(), out a);
            } while (a < 0 || a > 10 || !ready);

            ready = false;
            
            do
            {
                Console.Write("Введите delta (от {0} до 10): ", Double.Epsilon);
                ready = double.TryParse(Console.ReadLine(), out delta);
            } while (delta < Double.Epsilon || delta > 10 || !ready);
        }

        private static double F(double x)
        {
            return x * x;
        }
    }
}