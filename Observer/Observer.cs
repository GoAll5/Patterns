using System;
using System.Collections.Generic;

namespace Observer
{
    using Payload = List<Tuple<string, double>>;
    interface IBank
    {
        void Notify(Payload p);
    }

    interface INotifier
    {
        void Notify(Payload p);
    }

    class Stock : INotifier
    {
        private List<IBank> _subs = new List<IBank>();

        public void Register(IBank b) => _subs.Add(b);

        public void Unregister(IBank b) => _subs.Remove(b);

        public void Market()
        {
            var rnd = new Random();
            var euro = rnd.NextDouble() * 20 + 70;
            var dollar = rnd.NextDouble() * 20 + 60;
            Notify(new Payload {
                Tuple.Create("euro", euro),
                Tuple.Create("dollar", dollar)
            });
        }

        
        public void Notify(Payload p)
        {
            foreach(var s in _subs)
            {
                s.Notify(p);
            }
        }
    }
    class Bank : IBank
    {
        public void Notify(Payload p)
        {
            foreach (var c in p)
                Console.WriteLine($"{c.Item1} курс: {c.Item2}");
        }
    }

    class Observer
    {
        static void Main(string[] args)
        {
            var s = new Stock();

            var b = new Bank();

            s.Register(b);

            s.Market();

        }
    }
}
