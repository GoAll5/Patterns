using System;

// метод createproduct будет фабричный метод
namespace Factory_method
{   interface IFood
    {
        public string Name { get;}

        public double Weight { get;}
    }

    class Buckwheat : IFood //гречка
    {

        public string Name { get; set; }

        public double Weight { get; set; }
    }

    class Rice : IFood //рис
    {

        public string Name { get; set; }

        public double Weight { get; set; }
    }

    abstract class Kitchener
    {
        public string Name { get; }

        public Kitchener(string name)
        {
            Name = name;
        }
        abstract public IFood Cook();

        // staff принять заказ, есть другие методы
    }

    class BuckwheatKitchener : Kitchener
    {
        public BuckwheatKitchener(string name) : base(name) { } 
        public override IFood Cook()
        {
            return new Buckwheat { Name = "Buckwheat1", Weight = 0.5 };
        }
    }

    class RiceKitchener : Kitchener
    {
        public RiceKitchener(string name) : base(name) { }
        public override IFood Cook()
        {
            return new Rice { Name = "Rice1", Weight = 0.5 };
        }
    }
    //чтобы добавить что-то новое мы создаем новый класс еды и наследуем от IFood
    // и создаем новый класс повара этой еды
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            Kitchener k = new BuckwheatKitchener("Povar1"); //если захотим поменять еду то меняем только здесь повара
            IFood f = k.Cook();
            Console.WriteLine(f);
        }
    }
}
//не нарушаем наши принципы, доавбление нового повара или еды не меняет наш старый код, не изменяется а расширяется