using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace TaskF
{
    class Program
    {
        /// <summary>
        /// Вывести "wrong" и завершить работу
        /// </summary>
        static void ExitWrong()
        {
            Console.WriteLine("wrong");
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            int n, k;
            if (!int.TryParse(Console.ReadLine(), out n))
                ExitWrong();

            if (!int.TryParse(Console.ReadLine(), out k))
                ExitWrong();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                if (word != null)
                    foreach (char c in word)
                    {
                        if (c < 'a' || c > 'z')
                            ExitWrong();
                    }
                else
                    ExitWrong();

                string newWord;
                Caesar(word, k, out newWord);

                Console.WriteLine(newWord);
            }
        }

        /// <summary>
        /// Шифр Цезаря
        /// </summary>
        /// <param name="word">Исходное слово</param>
        /// <param name="shift">Смещение</param>
        /// <param name="cipherText">Результирующая строка</param>
        static void Caesar(string word, int shift, out string cipherText)
        {
            cipherText = "";
            foreach (var c in word)
            {
                int number = c - 'a';
                number = (number + shift) % 26;
                number = (number + 26) % 26;
                char c1 = (char) ('a' + number);
                cipherText = string.Format("{0}{1}", cipherText, c1);
            }
        }
    }
}