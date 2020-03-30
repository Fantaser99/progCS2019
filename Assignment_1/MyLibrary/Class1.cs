using System;

namespace MyLibrary
{
    class Misc
    {
        internal static Random rnd = new Random(DateTime.Now.Millisecond);
    }
    
    public abstract class Human
    {
        /// <summary>
        /// true если отравлен, иначе false
        /// </summary>
        protected bool poisoned;

        /// <summary>
        /// HP. Если падает до 0, человек умирает.
        /// </summary>
        protected double healthy;

        public bool alive => healthy > 0;


//        public bool TryEvade()
//        {
//            double prob = Misc.rnd.NextDouble();
//            return prob <= evade;
//        }
//        
//        public void ReceiveDamage(int _damage)
//        {
//            healthy = Math.Max(0, _damage - guard);
//        }
    }

    public class Fighter : Human
    {
        /// <summary>
        /// Урон, который персонаж наносит противнику
        /// </summary>
        protected int damage;

        /// <summary>
        /// Защита персонажа. После каждой атаки на этого игрока,
        /// защита уменьшается на 1, (вплоть до 0, не может принимать отрицательных значений).
        /// </summary>
        protected int guard;

        /// <summary>
        /// Вероятность уклонения текущего персонажа от удара противника.
        /// </summary>
        protected double evade;

        /// <summary>
        /// Рассчитывает, уклонился ли противник от атаки (используется enemy.evade).
        /// Если не уклонился, то наносит противнику урон равный (this.damage - enemy.guard).
        /// Если противник оказался самураем, то проверить, будет ли он наносить ответный удар и если да,
        /// то вызывать у противника метод Attack(передав в качестве аргумента ссылку на текущий персонаж).
        /// </summary>
        /// <param name="enemy">Ссылка на атакуемого персонажа (противника).</param>
        public virtual void Attack(Human enemy)
        {
            // Check evade

            double prob = Misc.rnd.NextDouble();

            if (prob <= enemy.evade)
            {
                // Deal damage
            }

//            if (enemy.TryEvade())
//            {
//                enemy.ReceiveDamage(damage);
//                
//                if ()
//            }
        }
    }
}