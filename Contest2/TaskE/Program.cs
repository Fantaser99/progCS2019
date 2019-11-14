using System;
using System.IO;

namespace TaskE
{
    class Matrix
    {
        public ulong element11, element12, element21, element22;
        // element11 element12
        // element21 element22

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="first">Матрица 1</param>
        /// <param name="second">Матрица 2</param>
        /// <returns>Матрица-произведение</returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            return new Matrix(
                first.element11 * second.element11 + first.element12 * second.element21,
                first.element11 * second.element12 + first.element12 * second.element22,
                first.element21 * second.element11 + first.element22 * second.element21,
                first.element21 * second.element12 + first.element22 * second.element22
            );
        }

        Matrix(ulong element11, ulong element12, ulong element21, ulong element22)
        {
            this.element11 = element11;
            this.element12 = element12;
            this.element21 = element21;
            this.element22 = element22;
        }

        public static readonly Matrix FibInitial = new Matrix(1, 1, 1, 0);

        // 1 1 
        // 1 0
        // Начальная матрица
        public static readonly Matrix Unit = new Matrix(1, 0, 0, 1);
        // 1 0
        // 0 1
        // Единичная матрица
    }

    static class Program
    {
        private const bool DEBUG = false;

        static void Main(string[] args)
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0) // Проверяем количество
            {
                Console.WriteLine("wrong");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                ulong idx;
                if (!ulong.TryParse(Console.ReadLine(), out idx)) // Проверяем номер числа Фибоначчи
                {
                    Console.WriteLine("wrong");
                    continue;
                }

                // Вычисляем и выводим
                Console.WriteLine(Fibonacci(idx));
            }
        }

        private static ulong Fibonacci(ulong idx)
        {
            // (матрица ^ (idx - 1))[1][1] = нужное число.
            return MatrixPower(Matrix.FibInitial, idx - 1, 0).element11 % (ulong) Math.Pow(2, 30);
        }

        /// <summary>
        /// Возведение матрицы в степень
        ///
        /// Для степени 
        /// </summary>
        /// <param name="mtx">Матрица</param>
        /// <param name="power">Показатель степени</param>
        /// <param name="depth">Если дебаг включен, будет использоваться для определения глубины рекурсии</param>
        /// <returns></returns>
        private static Matrix MatrixPower(Matrix mtx, ulong power, int depth)
        {
            switch (power)
            {
                // Начальные значения
                case 0:
                    return Matrix.Unit;
                case 1:
                    return mtx;
            }

            // Делим пополам для оптимальности
            ulong newPower = power / 2;

            // Для дебага рекурсии
            if (DEBUG)
                Console.WriteLine("{2}power({3}) = matrix^{0} * matrix^{0} * matrix^{1}", newPower,
                    power - newPower - newPower,
                    new String('\t', depth), power);

            // Вычисляем mtx^(newPower)
            Matrix tmp = MatrixPower(mtx, newPower, depth + 1);

            // Умножая на mtx^(power - newPower * 2) "догоняем" остаток
            return tmp * tmp *
                   MatrixPower(mtx, power - newPower * 2, depth + 1);
        }
    }
}