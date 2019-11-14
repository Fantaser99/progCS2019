using System;

namespace TaskA
{
    static class Program
    {
        static void Main(string[] args)
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 100000)
            {
                Console.WriteLine("wrong");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                string type = Console.ReadLine();
                long price;
                switch (type)
                {
                    case "none":
                        price = -1;
                        break;
                    case "bus":
                        price = 1200;
                        break;
                    case "taxi":
                        if (!long.TryParse(Console.ReadLine(), out price) || price < 1 || price > 1000000)
                        {
                            Console.WriteLine("wrong");
                            return;
                        }

                        if (price > 1500)
                            price = (long) Math.Ceiling(price * 0.8);
                        break;
                    default:
                        Console.WriteLine("wrong");
                        return;
                }

                switch (price)
                {
                    case -1:
                        continue;
                    case 1200:
                        Console.WriteLine(3);
                        break;
                    default:
                        Console.WriteLine(CountBills(price));
                        break;
                }
            }
        }

        private static long CountBills(long price)
        {
            int cnt = 0;

            while (price > 0)
            {
                if (price > 400)
                    price -= 500;
                else if (price > 100)
                    price -= 200;
                else
                    price -= 100;
                cnt += 1;
            }

            return cnt;
        }
    }
}