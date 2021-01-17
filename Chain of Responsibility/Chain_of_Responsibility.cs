using System;

namespace Chain_of_Responsibility
{   
    interface ITransferer
    {
        ITransferer Successor { get; set; } 
        void Transfer(double money); //проверить что он (successor) не null

    }

    abstract class PaymentMethod : ITransferer
    {
        protected double _money;
        public ITransferer Successor { get; set; }

        protected PaymentMethod(double money)
        {
            _money = money;
        }

        protected abstract void SelfTransfer(double money);
        public void Transfer(double money)
        {
            if (_money < money)
            {
                if (Successor != null)
                    Successor.Transfer(money);
                else
                {
                    throw new Exception("Недостаточно средств");
                }
            }
            else
            {
                SelfTransfer(money);
            }

        }
    }

    class TinkoffCard : PaymentMethod
    {
        public string Number { get;  }
        public TinkoffCard(string number, double money) : base(money)
        {
            Number = number;
        }
        protected override void SelfTransfer(double money)
        {
            _money -= money;
            Console.WriteLine($"Перевели {money} с карты Tinkoff {Number}");
        }
    }

    class PayPal : PaymentMethod
    {
        public PayPal(double money) : base(money)
        { }
        protected override void SelfTransfer(double money)
        {
            _money -= money;
            Console.WriteLine($"Перевели {money} с карты PayPal");
        }
    }

    class Chain_of_Responsibility
    {
        static void Main(string[] args)
        {
            var t1 = new TinkoffCard("1111", 10_000);
            var t2 = new TinkoffCard("2222", 40_000);
            var pp = new PayPal(17_000);

            var handler = t1;
            t1.Successor = pp;
            pp.Successor = t2;

            handler.Transfer(30_000);
            handler.Transfer(50_000);
        }
    }
}
