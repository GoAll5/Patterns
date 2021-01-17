using System;

namespace Mediator
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Participant p);
    }

    abstract class Participant
    {
        protected Mediator _mediator;

        protected Participant(Mediator m)
        {
            _mediator = m;
        }

        public void Send(string msg)
        {
            _mediator.Send(msg, this);
        }

        public abstract void Receive(string msg);
    }

    class Customer : Participant
    {
        public Customer(Mediator m) : base(m)
        {

        }
        public override void Receive(string msg)
        {
            Console.WriteLine($"Сообщение заказчику : {msg}");
        }
    }
    class Developer : Participant
    {
        public Developer(Mediator m) : base(m)
        {

        }
        public override void Receive(string msg)
        {
            Console.WriteLine($"Сообщение разработчику : {msg}");
        }
    }

    class Tester : Participant
    {
        public Tester(Mediator m) : base(m)
        {

        }
        public override void Receive(string msg)
        {
            Console.WriteLine($"Сообщение разработчику : {msg}");
        }
    }

    class Manager : Mediator
    {
        public Customer Customer { get; set; }

        public Developer Developer { get; set; }

        public Tester Tester { get; set; }

        public override void Send(string msg, Participant p)
        {
            if (Tester == p)
            {
                Customer.Send(msg);
            }
            else if (Developer == p)
            {
                Tester.Send(msg);
            }
            else if (Customer == p)
            {
                Developer.Send(msg);
            }
        }
    }

    class Meediator
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            var customer = new Customer(manager);
            var developer = new Developer(manager);
            var tester = new Tester(manager);

            manager.Tester = tester;
            manager.Developer = developer;
            manager.Customer = customer;

            customer.Send("Хочу фичу");
            developer.Send("done, test please");
            tester.Send("Ok go buy");
        }
    }
}
