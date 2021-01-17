using System;

namespace Template_Method
{   
    abstract class Unit
    {
        public void Turn()
        {
            CollectResources();
            Building();
            if (HasEnemy())
                Attack();
        }

        protected abstract void CollectResources();

        protected abstract void Building();

        protected virtual bool HasEnemy()
        {
            return new Random().NextDouble() > 0.6;
        }

        protected abstract void Attack();


    }

    class Human : Unit
    {
        protected override void Attack()
        {
            Console.WriteLine("Атака врага");
        }

        protected override void Building()
        {
            Console.WriteLine("Строю стену");
        }

        protected override void CollectResources()
        {
            Console.WriteLine("Собираю ресурсы");
        }

        protected override bool HasEnemy()
        {
            return new Random().NextDouble() > 0.6; 
        }
    }

    class Monster : Unit
    {
        protected override void Attack()
        {
            Console.WriteLine("Кусаю");
        }

        protected override void Building()
        {
        }

        protected override void CollectResources()
        {
        }

        protected override bool HasEnemy()
        {
            return true;
        }
    }

    class Template_Method
    {
        static void Main(string[] args)
        {
            var human = new Human();
            var moster = new Monster();

            human.Turn();
            moster.Turn();
        }
    }
}
