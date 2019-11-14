/* 
Дисциплина: "Программирование"
Группа: БПИ196/2
Студент: Якшибаев Арыслан Азаматович
Самостоятельная работа 3
Вариант 9
Дата: 2019.10.17
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace project
{
    static class Program
    {
        /// <summary>
        /// Проверить, является ли число степенью двойки
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <returns><b>true</b>, если <paramref name="number"/> является степенью двойки, иначе <b>false</b>.</returns>
        static bool CheckPowerOfTwo(int number)
        {
            while (number % 2 == 0)
                number /= 2;
            return number == 1;
        }

        /// <summary>
        /// Отобрать из массива <paramref name="array"/> всен числа, являющиеся степенями двойки.
        /// </summary>
        /// <param name="array">Массив целых чисел</param>
        /// <returns>Новый массив целых чисел. Содержит только те элементы массива <paramref name="array"/>,
        /// которые являются степенями двойки.</returns>
        static int[] FilterPowersOfTwo(int[] array)
        {
            List<int> result = new List<int>();
            
            foreach (int number in array)
            {
                if (CheckPowerOfTwo(number))
                    result.Add(number);
            }

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            bool repeat = true;
            do
            {
                try
                {
                    int count = 1;
                    bool gotCount = false;
                    do
                    {
                        Console.Write("Введите длину массива: ");
                        try
                        {
                            count = int.Parse(Console.ReadLine() ??
                                              throw new Exception("Отсутствуют введённые данные."));
                            gotCount = count > 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            gotCount = false;
                        }
                    } while (!gotCount);

                    // Вызов метода отбора

                    List<int> arr = new List<int>();
                    Random rnd = new Random();

                    for (int i = 0; i < count; i++)
                    {
                        arr.Add(rnd.Next(1, 256));
                    }

                    int[] array = arr.ToArray();

                    int[] result = FilterPowersOfTwo(array);

                    StreamWriter f = new StreamWriter("output.txt");

                    for (int i = 0; i < array.Length; i++)
                    {
                        f.Write("{0} ", array[i]);
                    }

                    f.WriteLine();
                    for (int i = 0; i < result.Length; i++)
                    {
                        f.Write("{0} ", result[i]);
                    }

                    f.WriteLine();
                    f.Close();

                    Console.WriteLine(
                        "Чтобы продолжить, нажмите Enter. Чтобы завершить выполнение программы, введите любой текст");
                    string repeatAnswer = Console.ReadLine();
                    if (repeatAnswer != null) repeat = repeatAnswer.Length == 0;
                    else
                    {
                        throw new Exception("Отсутствуют введённые данные.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    repeat = true;
                }
            } while (repeat);
        }
    }
}