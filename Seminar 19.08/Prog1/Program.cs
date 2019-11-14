/* 
Дисциплина: "Программирование"
Группа: БПИ196/1
Студент: Якшибаев Арыслан Азаматович
Задача: Написать метрод, переводящий оценку в баллах десятибалльной шкалы в аттестационную (четырех балльную) шкалу:
 * 1, 2, 3 балла - неудовлетворительно;
 * 4, 5 - удовлетворительно;
 * 6, 7 - хорошо;
 * 8, 9, 10 - отлично;
Используйте переключатель. 
В основной программе в получайте от пользователя оценки (целые числа из диапазона 1..10 и выводите значение в четырёх балльной шкале.
Дата: 2019.09.19
*/

using System;

namespace Prog1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int score = -1;
            bool initialized = false;

            Console.WriteLine("Введите оценку. Чтобы завершить программу, введите -1.");
            
            do
            {
                if (initialized)
                {
                    Console.WriteLine("Ваша оценка: {0}. Ваш результат: {1}.", score, Convert(score));
                }
                if (!int.TryParse(Console.ReadLine(), out score))
                {
                    Console.WriteLine("Введите корректное целое число.");
                    initialized = false;
                }
                else
                {
                    initialized = true;
                }
            } while (score != -1);
        }

        private static string Convert(int score)
        {
            string result;

            switch (score)
            {
                case 1:
                case 2:
                case 3:
                    result = "Неудовлетворительно";
                    break;
                case 4:
                case 5:
                    result = "Удовлетворительно";
                    break;
                case 6:
                case 7:
                    result = "Хорошо";
                    break;
                case 8:
                case 9:
                case 10:
                    result = "Отлично";
                    break;
                default:
                    result = "Некорректная оценка. Введите значение в диапазоне 1..10";
                    break;
            }

            return result;
        }
    }
}