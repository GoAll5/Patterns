using System;
using System.Collections.Generic;

namespace Prototype
{   
    public interface IElement
    {
        IElement Clone();
        string Info();
        void AddHandler();
    }

    public class Horse : IElement
    {
        protected double v;
        protected double w;

        public Horse(double v, double w)
        {
            this.w = w;
            this.v = v;
        }

        public Horse(Horse other)
        {
            w = other.w;
            v = other.v;
        }
        public IElement Clone()
        {
            return new Horse(this);
        }

        public string Info()
        {
            return $"скорость и вес {v} и {w}";
        }

        public void AddHandler()
        {
            throw new NotImplementedException();
        }
    }

    class Prototype
    {
        static void Main(string[] args)
        {
            Dictionary<string, IElement> reg = new Dictionary<string, IElement>();

            reg.Add("horse", new Horse(30, 100));

            IElement e = reg["horse"].Clone();
            Console.WriteLine(e.Info());
        }
    }
}
