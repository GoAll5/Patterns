using System;

namespace Decorator
{
    interface INotificator
    {
        void Send(string text);
    }
    class BaseNotificatorDecorator : INotificator
    {
        protected INotificator _wrappee;

        public BaseNotificatorDecorator(INotificator n = null)
        {
            _wrappee = n;
        }
        public virtual void Send(string text)
        {
            _wrappee?.Send(text); //если ссылка не равно null то отправит сообщение
            //if (_wrappee != null)
            //    _wrappee.Send(text); // то же самое
        }
    }

    class TelegramDecorator : BaseNotificatorDecorator
    {

        public TelegramDecorator(INotificator n) : base(n)
        {
        }
        public override void Send(string text)
        {
            base.Send(text);
            Console.WriteLine($"Send to TG {text}");
        }
    }

    class SmsDecorator : BaseNotificatorDecorator
    {

        public SmsDecorator(INotificator n) : base(n)
        {
        }
        public override void Send(string text)
        {
            base.Send(text);
            Console.WriteLine($"Send to Sms {text}");
        }
    }
    class Decorator
    {
        static void Main(string[] args)
        {
            INotificator notifer = new BaseNotificatorDecorator();

            bool needSms = true;
            bool Tg = true;

            if (needSms)
            {
                notifer = new SmsDecorator(notifer); // sms.wrappe -> base
            }
            if (Tg)
            {
                notifer = new TelegramDecorator(notifer); // tg -> sms -> base
            }
            notifer.Send("Test");
        }
    }
}
