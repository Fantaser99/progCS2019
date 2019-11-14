using System;

namespace Task5
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[][] pascal;
            int n;
            do
            {
                n = InputNumberWithPrompt("Enter depth of Pascal's triangle", minConstraint: 1);

                pascal = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    switch (i)
                    {
                        case 0:
                            pascal[i] = new[] {1};
                            break;
                        default:
                            pascal[i] = new int[i + 1];
                            pascal[i][0] = 1;
                            pascal[i][i] = 1;
                            for (int j = 1; j < i; j++)
                            {
                                pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
                            }
                            break;
                    }
                }

                foreach (var line in pascal)
                {
                    foreach (var el in line)
                    {
                        Console.Write("{0} ", el);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("To exit program press ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.WriteLine();
        }

        /// <summary>
        ///     Prompt the user with provided line <paramref name="prompt"/>. 
        ///     Input fails if the number provided by the user is not a correct Int32 number 
        ///     or doesn't fit the constraints 
        ///     [<paramref name="minConstraint"/>; <paramref name="maxConstraint"/>]
        /// </summary>
        /// <param name="prompt">The text prompt shown to the user</param>
        /// <param name="ensure">
        ///     If <b>true</b>, the method doesn't 
        ///     throw any exceptions and repeats the prompt until the user types in a correct number.
        /// </param>
        /// <param name="minConstraint">Minium allowed value</param>
        /// <param name="maxConstraint">Maximum allowed value</param>
        /// <returns>The number entered by the user</returns>
        private static int InputNumberWithPrompt(string prompt = "Enter a number:", bool ensure = true,
            int minConstraint = int.MinValue, int maxConstraint = int.MaxValue)
        {
            do
            {
                try
                {
                    Console.WriteLine(prompt);
                    int number = int.Parse(Console.ReadLine() ??
                                           throw new NullReferenceException("Unexpected input error"));
                    if (number > maxConstraint || number < minConstraint)
                    {
                        throw new Exception(string.Format("The provided number doesn't fit the set constraints." +
                                                          " Please enter a number which fits in [{0}; {1}].",
                            minConstraint, maxConstraint));
                    }

                    return number;
                }
                catch (Exception e)
                {
                    if (!ensure)
                    {
                        throw;
                    }

                    Console.WriteLine(e.Message);
                }

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            } while (ensure);

            throw new Exception("Unexpected problem occured while trying to input a number.");
        }
    }
}