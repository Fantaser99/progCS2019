using System;

namespace KDZ
{
    public abstract class Human
    {
        protected static readonly Random Rnd = new Random();
        protected bool poisoned;
        protected double healthy;
        protected int damage;
        protected int guard;
        protected double evade;
        protected double poison;
        protected double retaliation;
        public string TeamName;

        /// <summary>
        /// Жив ли данный человек
        /// </summary>
        public bool Alive
        {
            get { return this.healthy > 0; }
        }

        /// <summary>
        /// Атаковать противника <paramref name="enemy"/>
        /// </summary>
        /// <param name="enemy">Противник</param>
        public virtual void Attack(Human enemy)
        {
        }

        /// <summary>
        /// Обработка входящей атаки
        /// </summary>
        /// <param name="enemy">Противник</param>
        /// <param name="_damage">Количество урона</param>
        /// <param name="_poison">Отравит ли этот удар данного человека</param>
        public void GetHit(Human enemy, int _damage, bool _poison)
        {
            bool gotPoisoned = !this.poisoned && _poison;

            double dice = Rnd.NextDouble();
            double recvDmg = 0;
            bool evaded = this.evade > dice;
            if (!evaded)
            {
                recvDmg = _damage - this.guard;
            }

            this.healthy -= recvDmg;

            if (_poison)
                this.poisoned = true;

            this.guard = Math.Max(0, this.guard - 1);

            if (!evaded)
                Console.WriteLine("Из команды {0} {1} атаковал {2} и нанес {3} урона! {4}", enemy.TeamName,
                    enemy.GetType().Name,
                    this.GetType().Name, recvDmg, gotPoisoned ? this.GetType().Name + " был отравлен!" : "");
            else
                Console.WriteLine("Из команды {0} {1} атаковал {2}, но тот увернулся!", enemy.TeamName,
                    enemy.GetType().Name,
                    this.GetType().Name);

            if (this.healthy > 0)
            {
                dice = Rnd.NextDouble();
                if (this.retaliation > dice)
                {
                    this.Attack(enemy);
                }
            }
        }

        /// <summary>
        /// Вывести в консоль звук, с которым данный человек наносит атаку
        /// </summary>
        public abstract void BattleCry();
    }

    public class Fighter : Human
    {
//        protected int damage;
//        protected int guard;
//        protected double evade;

        public Fighter(string tn = "None")
        {
            this.healthy = Rnd.Next(50, 71);
            this.damage = Rnd.Next(5, 11);
            this.guard = 0;
            this.TeamName = tn;
        }

        public override void Attack(Human enemy)
        {
            if (this.poisoned)
            {
                double poisonDmg = Math.Max(5, 0.07 * this.healthy);
                this.healthy -= poisonDmg;
                Console.WriteLine("{0} получает урон {1} от яда!", this.GetType().Name, poisonDmg);
            }

            if (this.healthy <= 0)
                return;

            double dice = Rnd.NextDouble();
            bool willPoison = this.poison > dice;

            this.BattleCry();
            enemy.GetHit(this, this.damage, willPoison);
        }

        public override void BattleCry()
        {
            Console.WriteLine("Хыа!");
        }
    }

    public class Ninja : Fighter
    {
//        public void Attach(Human enemy)
//        {
//            
//        }

        public Ninja(string tn = "None")
        {
            this.healthy = Rnd.Next(60, 76);
            this.damage = Rnd.Next(8, 16);
            this.guard = Rnd.Next(4, 6);
            this.evade = 0.4 + Rnd.NextDouble() * 0.2; // 0.4 .. 0.6
            this.poison = 0.3 + Rnd.NextDouble() * 0.3; // 0.3 .. 0.6
            this.TeamName = tn;
        }

        public override void BattleCry()
        {
            Console.WriteLine("Кия!");
        }
    }

    public class Samurai : Fighter
    {
//        protected double poison;

        public Samurai(string tn = "None")
        {
            this.healthy = Rnd.Next(70, 86);
            this.damage = Rnd.Next(7, 13);
            this.guard = Rnd.Next(4, 7);
            this.evade = 0.3 + Rnd.NextDouble() * 0.2; // 0.3 .. 0.5
            this.retaliation = 0.3 + Rnd.NextDouble() * 0.2; // 0.3 .. 0.5
            this.TeamName = tn;
        }

        public override void BattleCry()
        {
            Console.WriteLine("Чхуа!");
        }

//        public void Attack(Human enemy)
//        {
//            
//        }
    }
}