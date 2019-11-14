/* 
Дисциплина: "Программирование"
Группа: БПИ196/1
Студент: Якшибаев Арыслан Азаматович
Задача: 
    Написать метод для вычисления по формуле Ньютона с точностью до «машинного нуля» приближенного значения арифметического квадратного корня. 
    Параметры: подкоренное значение, полученное значение корня и значение точности, достигнутой при его вычислении. Если подкоренное значение отрицательно - метод должен возвращать в точку вызова значение false, иначе - true. 

    В основной программе вводить вещественные числа и выводить их корни. При отрицательных числах выводить сообщения.
Дата: 2019.09.19
*/

using System;

namespace Prog4
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            double x, result = 0, eps = 0;
            Console.Title = "Формула Ньютона";
            ConsoleKeyInfo keyInfo; //Нажатая пользователем клавиша
            do
            {
                do
                {
                    Console.Clear(); // очистка консольного окна
                    Console.Write("x=");
                } while (!double.TryParse(Console.ReadLine(), out x));

                if (!Newton(x, out result, out eps))
                {
                    Console.WriteLine("Error!");
                    return;
                }

                Console.WriteLine("root({0}) = {1,8:f4}, eps = {2,8:e4}", x, result, eps);

                Console.WriteLine("Для выхода нажмите клавишу ESC");
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Escape);

            Console.Beep(500, 1000);
        }

        private static bool Newton(double x, out double sq, out double eps)
        {
            double r1, r2 = x;
            sq = eps = 0.0;
            if (x <= 0.0)
            {
                Console.WriteLine("Ошибка в данных!");
                return false;
            }

            do
            {
                r1 = r2;
                eps = x / r1 / 2 - r1 / 2;
                r2 = r1 + eps;
            } while (r1 != r2); // пока приближения «различимы» для ЭВМ

            sq = r2;
            return true;
        }
    }
}