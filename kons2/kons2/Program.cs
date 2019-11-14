using System;
using System.IO;

namespace kons2
{
    static class Program
    {
        static void Main(string[] args)
        {
        }

        static bool WriteLine(string output)
        {
            Console.WriteLine(output);
            return Log(output);
        }

        static bool ReadLine(out string input)
        {
            input = Console.ReadLine();
            return Log(input);
        }

        static bool Log(params string[] info)
        {
            string logPath = @"../../../../log.txt";
            string logLine = "";
            for (int i = 0; i < info.Length - 1; i++)
            {
                logLine = string.Format("{0}{1} ", logLine, info[i]);
            }

            logLine = string.Format("{0}{1}{2}", logLine, info[info.Length - 1], Environment.NewLine);
            try
            {
                File.AppendAllText(logPath, logLine);
            }
            catch (IOException e)
            {
                Console.WriteLine("Невозможна запись в файл лога: {0}", e.Message);
            }

            return true;
        }
    }
}