using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int dec; // Decimal

            // Ввод и проверка на органичения

            if (!int.TryParse(Console.ReadLine(), out dec) || dec < 1 || dec > 100)
            {
                Console.WriteLine("wrong");
                return;
            }

            // Вызов конвертера

            string result = Romanize(dec);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Конвертирует десятичное число в пределах [1, 100] в римскую систему исчисления
        /// </summary>
        /// <param name="dec">Десятичное число для конвертации</param>
        /// <returns>Результат конвертации (в римской системе)</returns>
        private static string Romanize(int dec)
        {
            string res = "";

            // Обозначаем ключевые точки, "базы"

            int[] bases = {1, 4, 5, 9, 10, 40, 50, 90, 100};
            string[] symbols = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C"};

            // Начинать будем с самой большой
            int current_base_idx = bases.Length - 1;

            while (dec > 0) // Пока не обработаем число целиком
            {
                // Находим, сколько раз надо написать текущую "базу" и вычитаем то, что сейчас будем записывать, из числа 

                int count = dec / bases[current_base_idx];
                dec = dec % bases[current_base_idx];

                for (int i = 0; i < count; i++)
                {
                    // Добавляем текущую базу с результат столько раз сколько нужно
                    res = string.Format("{0}{1}", res, symbols[current_base_idx]);
                }

                // Переходим к следующей (меньшей) базе
                current_base_idx--;
            }

            return res;
        }
    }
}