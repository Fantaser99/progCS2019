using System;
using System.Text;

namespace Sr5
{
    internal class Program
    {
        private static Random rnd;
        
        public static void Main(string[] args)
        {
            do
            {
                rnd = new Random();
                
                int n = GetNumber(prompt: "Enter the N:", minConstraint: 1);
                Cat[] cats = new Cat[n];
                for (int i = 0; i < n; i++)
                {
                    int meows_count = rnd.Next(2, n);
                    string[] meows = new string[meows_count];

                    for (int j = 0; j < meows_count; j++)
                    {
                        meows[j] = RandomString(2, n);
                    }
                    
                    cats[i] = new Cat(string.Format("Cat{0}", i + 1), meows);
                }

                for (int i = 0; i < cats.Length; i++)
                {
                    Console.WriteLine("{0}'s meows: ", cats[i].Name);
                    for (int j = 0; j < cats[i].Length; j++)
                    {
                        Console.Write("\"{0}\" ", cats[i][j]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Press Enter to repeat, any other key to exit.");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);

            Console.WriteLine("Closing...");
        }

        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="minLen">Min string length</param>
        /// <param name="maxLen">Max string length</param>
        /// <param name="minChar">Min char</param>
        /// <param name="maxChar">Max char</param>
        /// <returns></returns>
        private static string RandomString(int minLen, int maxLen, char minChar = 'a', char maxChar = 'z')
        {
            int len = rnd.Next(minLen, maxLen);

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                str.Append((char)rnd.Next((int)minChar, (int)maxChar));
            }

            return str.ToString();
        }

        private static int GetNumber(string prompt = "Enter a number:", int minConstraint = Int32.MinValue,
            int maxConstraint = Int32.MaxValue, bool ensure = true)
        {
            do
            {
                Console.WriteLine(prompt);
                int tmp;
                var strtmp = Console.ReadLine();
                if (int.TryParse(strtmp, out tmp))
                {
                    if (tmp >= minConstraint && tmp <= maxConstraint)
                        return tmp;
                    Console.WriteLine("The number didn't fit in the constraints.");
                }
                else
                {
                    // If fails, print out a relevant error message
                    try
                    {
                        tmp = int.Parse(strtmp ?? throw new Exception("Unexpected ArgumentNullException"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            } while (ensure);

            throw new Exception("Couldn't get the number.");
        }
    }
}