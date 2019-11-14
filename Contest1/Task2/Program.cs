using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            string input = Console.ReadLine();
            if (!int.TryParse(input, out number) || number < 1000 || number > 9999)
            {
                Console.WriteLine("wrong");
                return;
            }

            int result = CheckPalyndrome(number);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Проверяет, является ли четырёхзначное число палиндромом
        /// </summary>
        /// <param name="number">Четырёхзначное число</param>
        /// <returns>1 если переданное число - палиндром. Иначе - любое другое число.</returns>
        private static int CheckPalyndrome(int number)
        {
            int first, last;

            // Берём первую и четвёртую цифры
            
            first = number / 1000;
            last = number % 10;

            int result = 1;

            result += (first - last) * 100;  // Прибавляем к результату разницу между ними
            
            // Чтобы например при числе 1423 разницы не "съели" друг друга, разделяем их домножением на 100 и на 10 

            number = (number / 10) % 100;  // Отсекаем обработанные цифры
            
            // Повторяем процесс
            
            first = number / 10;
            last = number % 10;

            result += (first - last) * 10;

            return result;
        }
    }
}