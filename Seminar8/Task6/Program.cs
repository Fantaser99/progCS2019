using System;
using System.Text;

namespace Task6
{
    internal static class Program
    {
        private class Matrix
        {
            private int[,] _matrix;

            public Matrix(int height, int width)
            {
                _matrix = new int[height, width];
            }

            public int GetElement(int y, int x)
            {
                return _matrix[y, x];
            }

            public void SetElement(int y, int x, int value)
            {
                _matrix[y, x] = value;
            }

            public int GetHeight()
            {
                return _matrix.GetLength(0);
            }

            public int GetWidth()
            {
                return _matrix.GetLength(1);
            }

            public void FillRandom(int min, int max)
            {
                Random rnd = new Random();
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        SetElement(i, j, rnd.Next(min, max));
                    }
                }
            }

            public override string ToString()
            {
                StringBuilder res = new StringBuilder();
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        res.AppendFormat("{0} ", _matrix[i, j]);
                    }

                    res.AppendLine();
                }

                return res.ToString();
            }
            
            public static Matrix operator*(Matrix first, Matrix second)
            {
                if (first.GetWidth() != second.GetHeight())
                {
                    throw new InvalidOperationException("Impossible to multiply these matrices");
                }

                Matrix result = new Matrix(first.GetHeight(), second.GetWidth());
            }
        }

        public static void Main(string[] args)
        {
            int n, m, k, p;

            n = InputNumberWithPrompt("Height of A: ", minConstraint: 1);
            m = InputNumberWithPrompt("Width of A: ", minConstraint: 1);
            k = InputNumberWithPrompt("Height of B: ", minConstraint: 1);
            p = InputNumberWithPrompt("Width of B: ", minConstraint: 1);

            Matrix A = CreateMatrix(n, m);
            Matrix B = CreateMatrix(k, p);

            try
            {
                Matrix C = A * B;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Matrix CreateMatrix(int height, int width)
        {
            Matrix matrix = new Matrix(height, width);
            matrix.FillRandom(1, 11);
            return matrix;
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

}