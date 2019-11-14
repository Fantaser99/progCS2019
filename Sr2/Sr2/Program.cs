/* 
Дисциплина: Программирование
Группа: БПИ196/2
Студент: Якшибаев Арыслан Азаматович
Задача: Самостоятельная работа.
Вариант: 8
Дата: 5.11.2019
*/


using System;
using System.Text;

namespace Sr2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            bool repeat = false;
            do
            {
                int n = GetNumberWithPrompt("Введите N: ", minConstraint: 1);
                int m = GetNumberWithPrompt("Введите M: ", minConstraint: 1);
                int[][] matrix = GenerateMatrix(m, n, -783, 785); // (-784, 784]
                Console.WriteLine("Сгенерированная матрица:");
                Console.WriteLine(MatrixToString(matrix));

                int lineIdx, lineSum;

                try
                {
                    (lineIdx, lineSum) = FindMaxRow(matrix);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("Номер строки, сумма элементов которой максимальна: {0}", lineIdx + 1);
                Console.WriteLine("Сумма элементов этой строки: {0}", lineSum);
                
                Console.WriteLine("Press Enter to repeat...");
                repeat = Console.ReadKey(true).Key == ConsoleKey.Enter;
            } while (repeat);
        }

        /// <summary>
        /// Находит строку, сумма элементов которой максимальна.
        /// </summary>
        /// <param name="matrix">Матрица (двумерный массив)</param>
        /// <returns>(индекс найденной строки, сумма элементов этой строки)</returns>
        private static (int, int) FindMaxRow(int[][] matrix)
        {
            int maxSum = Int32.MinValue;
            int maxIdx = -1;
            for (int i = 0; i < matrix.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sum += matrix[i][j];
                }

                if (sum > maxSum || maxIdx == -1)
                {
                    maxIdx = i;
                    maxSum = sum;
                }
            }

            return (maxIdx, maxSum);
        }

        /// <summary>
        /// Сгенерировать строковое представление матрицы (двумерного массива)
        /// </summary>
        /// <param name="matrix">Матрица (двумерный массив)</param>
        /// <returns>Строковое представление - элементы разделены пробелами, строки - переносами строк.</returns>
        private static string MatrixToString(int[][] matrix)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    res.AppendFormat("{0} ", matrix[i][j]);
                }

                res.AppendLine();
            }

            return res.ToString();
        }

        /// <summary>
        /// Сгенерировать матрицу со случайными числами
        /// </summary>
        /// <param name="height">Высота матрицы</param>
        /// <param name="width">Ширина матрицы</param>
        /// <param name="minValue">Минимальное значение (включая)</param>
        /// <param name="maxValue">Максимальное значение (исключая)</param>
        /// <returns></returns>
        private static int[][] GenerateMatrix(int height, int width, int minValue, int maxValue)
        {
            Random rnd = new Random();
            int[][] res = new int[height][];
            for (int i = 0; i < height; i++)
            {
                res[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    res[i][j] = rnd.Next(minValue, maxValue);
                }
            }
            return res;
        }

        /// <summary>
        /// Ввести число с клавиатуры
        /// </summary>
        /// <param name="prompt">Приглашение пользователю</param>
        /// <param name="minConstraint">Минимальное допустимое значение</param>
        /// <param name="maxConstraint">Максимальное допустимое значение</param>
        /// <param name="ensure">Повторять ли попытку ввода при некорректном вводе</param>
        /// <returns>Полученное с клавиатуры число</returns>
        private static int GetNumberWithPrompt(string prompt = "Enter number: ", int minConstraint = int.MinValue,
            int maxConstraint = int.MaxValue, bool ensure = true)
        {
            do
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int res) && res >= minConstraint && res <= maxConstraint)
                {
                    return res;
                }
            } while (ensure);

            throw new Exception("Сouldn't input the number.");
        }
    }
}