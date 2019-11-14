/* 
Дисциплина: "Программирование"
Группа: БПИ196/1
Студент: Якшибаев Арыслан Азаматович
Задача:
............
Дата: 2019.10.2
*/

using System;

namespace TaskJ
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
        private static void InputAndCheck(out double variable, double leftConstraint, double rightConstraint)
        {
            string input = Console.ReadLine();
            double tmp;
            if (!double.TryParse(input, out tmp))
                ExitWrong();

            if (tmp < leftConstraint || tmp > rightConstraint)
                ExitWrong();

            variable = tmp;
        }
        
        static void Main(string[] args)
        {
            double a, b, c, d;
            
            // Вводим вещественные коэффициенты
            InputAndCheck(out a, 0, double.MaxValue);
            InputAndCheck(out b, 0, double.MaxValue);
            InputAndCheck(out c, 0, double.MaxValue);
            InputAndCheck(out d, 0, double.MaxValue);

            int maxValue = int.MinValue;
            int cnt = 0;
            
            // Перебираем все пары x, y
            for (int x = -50; x <= 50; x++)
            {
                for (int y = -50; y <= 50; y++)
                {
                    int tmp = Function(a, b, c, d, x, y);  // Получаем значение функции
                    // Обновляем максимум и количество подсчитанных пар
                    if (tmp > maxValue)
                    {
                        maxValue = tmp;
                        cnt = 0;
                    }
    
                    // +1 к количеству, если нашлась нужная пара
                    if (tmp == maxValue)
                        cnt++;
                }
            }

            Console.WriteLine("{0}\n{1}", cnt, maxValue);
        }

        /// <summary>
        /// Математическая функция F(x, y) = A * sin(B * x) + C * (cos(D * y)) ^ 3
        /// </summary>
        /// <param name="a">Вещественный коэффициент A</param>
        /// <param name="b">Вещественный коэффициент B</param>
        /// <param name="c">Вещественный коэффициент C</param>
        /// <param name="d">Вещественный коэффициент D</param>
        /// <param name="x">Целочисленная переменная x</param>
        /// <param name="y">Целочисленная переменная y</param>
        /// <returns>Округленное значение функции F(x, y)</returns>
        private static int Function(double a, double b, double c, double d, int x, int y)
        {
            return (int)Math.Round(a * Math.Sin(b * x) + c * Math.Pow(Math.Cos(d * y), 3));
        }
    }
}