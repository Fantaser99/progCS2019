/* 
Дисциплина: "Программирование"
Группа: БПИ196/1
Студент: Якшибаев Арыслан Азаматович
Задача: Написать метод для вычисления площади и длины окружности, радиус которой задает вещественный параметр.
    В основной программе, вводя значения радиуса, с помощью обращения к методу, вычислять площадь и длину окружности. 
    При вводе применять метод double.TryParse() и проверять корректность введенного значения.
    При выводе использовать форматную строку метода WriteLine(). 
    Окончание работы программы - ввод нулевого или отрицательного значения радиуса.

Дата: 2019.09.12
*/

using System;

namespace Task2
{
    internal static class Program
    {
        private static void Calculate(in double radius, out double s, out double c)
        {
            s = Math.PI * Math.Pow(radius, 2);
            c = 2 * Math.PI * radius;
            return;
        }

        public static void Main(string[] args)
        {
            double r = 1, // Радиус
                s, // Площадь круга
                c; // Длина окружности
            string str;

            while (r > 0)
            {
                do
                {
                    Console.Write("Введите радиус: ");
                    str = Console.ReadLine();
                } while (!double.TryParse(str, out r));

                if (r <= 0)
                    return;

                Calculate(r, out s, out c);

                Console.WriteLine("Введённый радиус: {0:f3}.\nПлощадь круга: {1:f3}\nДлина окружности: {2:f3}", r, s,
                    c);
            }
        }
    }
}