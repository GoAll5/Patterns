using System;
using System.Collections;
using System.Collections.Generic;

namespace Memento
{
    class Hero //originator
    {
        protected int _bullets = 10;
        protected int _lives = 5;

        public void Shoot()
        {
            if (_bullets > 0)
                _bullets--;
            else
                throw new Exception("Патроны кончились");
        }

        public IHeroMemento Save()
        {
            return new HeroMemento(_bullets, _lives);
        }

        public void Restore(IHeroMemento imemento)
        {
            var memento = imemento as HeroMemento;
            if (memento == null) throw new Exception("Некорректный тип");
            _bullets = memento.Bullets;
            _lives = memento.Lives;
        }


    }

    interface IHeroMemento
    {

    }
    public class HeroMemento : IHeroMemento
    {
        public int Bullets { get; }
        public int Lives { get; }

        public HeroMemento(int bullets, int lives)
        {
            Bullets = bullets;
            Lives = lives;
        }
    }
    class Memento
    {
        static void Main(string[] args)
        {
            var hero = new Hero();
            var history = new Stack<IHeroMemento>();
            hero.Shoot();
            hero.Shoot();

            

            history.Push(hero.Save());

            hero.Shoot(); // 7
            hero.Shoot(); // 6



            var m = history.Pop();
            hero.Restore(m);


            hero.Shoot(); // 7
        }
    }
}
