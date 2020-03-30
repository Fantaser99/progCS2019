using System;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;

namespace KDZ
{
    internal static class Program
    {
        /// <summary>
        /// Получить число от пользователя. Будет повторять, пока не получит корректный ввод.
        /// </summary>
        /// <param name="prompt">Запрос</param>
        /// <param name="minConstraint">Минимальное допустимое значение</param>
        /// <param name="maxConstraint">Максимальное допустимое значение</param>
        /// <param name="failText">Сообщение при некорректном вводе</param>
        /// <returns></returns>
        private static int GetNumber(string prompt = "Введите число", int minConstraint = int.MinValue,
            int maxConstraint = int.MaxValue, string failText = "Пожалуйста, введите корректное число.")
        {
            do
            {
                Console.Write(prompt + "==> ");
                string thing = Console.ReadLine();
                int val;
                if (int.TryParse(thing, out val))
                {
                    if (val >= minConstraint && val <= maxConstraint)
                        return val;
                }

                Console.WriteLine(failText);
            } while (true);
        }

        /// <summary>
        /// Создать нового случайного воина
        /// </summary>
        /// <param name="tn">Название команды</param>
        /// <returns></returns>
        private static Human GenerateNewFighter(string tn)
        {
            Human newFighter;

            double dice = rnd.NextDouble();

            if (dice < 0.45)
                newFighter = new Fighter(tn);
            else if (dice < 0.75)
                newFighter = new Ninja(tn);
            else
                newFighter = new Samurai(tn);

            return newFighter;
        }

        private static Random rnd = new Random();

        public static void Main(string[] args)
        {
            do
            {
                try
                {
                    int team = rnd.Next(0, 2);
                    Human[][] teams = new Human[2][];
                    int[] aliveCount = new int[2];
                    int[] currentFighter = new[] {-1, -1};
                    teams[0] = new Human[10];
                    teams[1] = new Human[10];

                    for (int i = 0; i < 10; i++)
                    {
                        teams[0][i] = GenerateNewFighter("Computer");
                    }

                    switch (GetNumber(
                        prompt:
                        "=====\r\nВыберите, как набрать отряд.\r\n 1 - автоматически, 2 - вручную.\r\n=====\r\n",
                        minConstraint: 1, maxConstraint: 2))
                    {
                        case 1:
                            teams[1] = new Human[10];
                            for (int i = 0; i < 10; i++)
                            {
                                teams[1][i] = GenerateNewFighter("Player");
                            }

                            break;
                        case 2:
                            Console.WriteLine("У вас есть 10 монет.\r\nСоберите ваш идеальный отряд!" +
                                              "\r\n1. Самурай:\t2 монеты.\r\n" +
                                              "2. Ниндзя:\t1,5 монеты.\r\n3. Боец:\t1 монета.\r\n\r\n");
                            Console.WriteLine("Чтобы взять воина в свой отряд, введите номер его класса." +
                                              "\r\nЧтобы завершить сбор отряда, введите 0.");
                            double coins = 10;
                            int cnt = 0;
                            bool flag = false;
                            while (true)
                            {
                                if (coins <= 0)
                                {
                                    Console.WriteLine("У вас закончились монеты! Отряд собран.");
                                    break;
                                }

                                int choice = GetNumber(prompt: "", minConstraint: 0, maxConstraint: 3);
                                switch (choice)
                                {
                                    case 0:
                                        if (cnt == 0)
                                        {
                                            Console.WriteLine("В отряде должен быть хотя бы один воин!");
                                            break;
                                        }

                                        Console.WriteLine("Отряд собран.");
                                        flag = true;
                                        break;
                                    case 1:
                                        if (coins < 2)
                                        {
                                            Console.WriteLine("У вас не хватает монет!");
                                            break;
                                        }

                                        coins -= 2;
                                        teams[1][cnt++] = new Samurai("Player");
                                        Console.WriteLine("Самурай добавлен в команду. \r\nВаш баланс: {0}", coins);
                                        break;
                                    case 2:
                                        if (coins < 1.5)
                                        {
                                            Console.WriteLine("У вас не хватает монет!");
                                            break;
                                        }

                                        coins -= 1.5;
                                        teams[1][cnt++] = new Ninja("Player");
                                        Console.WriteLine("Ниндзя добавлен в команду. \r\nВаш баланс: {0}", coins);
                                        break;
                                    case 3:
                                        if (coins < 1)
                                        {
                                            Console.WriteLine("У вас не хватает монет!");
                                            break;
                                        }

                                        coins -= 1;
                                        teams[1][cnt++] = new Fighter("Player");
                                        Console.WriteLine("Боец добавлен в команду. \r\nВаш баланс: {0}", coins);
                                        break;
                                }

                                if (flag) break;
                            }

                            break;
                    }

                    do
                    {
                        int enemyIdx;
                        int enemyTeam = (team + 1) % 2;
                        do
                        {
                            enemyIdx = rnd.Next(teams[enemyTeam].Length);
                        } while (teams[enemyTeam][enemyIdx] == null || !teams[enemyTeam][enemyIdx].Alive);

                        do
                        {
                            currentFighter[team] = (currentFighter[team] + 1) % teams[team].Length;
                        } while (teams[team][currentFighter[team]] == null || !teams[team][currentFighter[team]].Alive);

                        teams[team][currentFighter[team]].Attack(teams[enemyTeam][enemyIdx]);
                        if (!teams[enemyTeam][enemyIdx].Alive)
                        {
                            Console.WriteLine("{0} умер!", teams[enemyTeam][enemyIdx].GetType().Name);
                        }

                        for (int j = 0; j < teams.Length; j++)
                        {
                            aliveCount[j] = 0;
                            for (int i = 0; i < teams[j].Length; i++)
                            {
                                if (teams[j][i] != null && teams[j][i].Alive)
                                {
                                    aliveCount[j]++;
                                }
                            }
                        }

                        team = enemyTeam;
                    } while (aliveCount[0] > 0 && aliveCount[1] > 0);

                    if (aliveCount[0] == 0 && aliveCount[1] == 0)
                        Console.WriteLine("Ничья!");
                    else
                    {
                        Console.WriteLine("Победила команда {0}!",
                            aliveCount[0] > 0 ? teams[0][0].TeamName : teams[1][0].TeamName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Произошла неожиданная ошибка. Описание ошибки: {0}", e.Message);
                }

                Console.WriteLine(
                    "Чтобы начать новую игру, нажмите Enter. Чтобы завершить работу, нажмите любую другую клавишу.");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}