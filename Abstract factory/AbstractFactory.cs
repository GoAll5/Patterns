using System;

namespace Abstract_factory
{
    public interface IBoost
    {
        void Boost(Car car);
    }

    public interface ISpeed
    {
        void Speed(Car car);
    }
    public class HighBoost : IBoost
    {
        public void Boost(Car car)
        {
            Console.WriteLine($"скорость {car} на 5 сек увеличена на 100 км/ч");
        }
    }

    public class LowBoost : IBoost
    {
        public void Boost(Car car)
        {
            Console.WriteLine($"скорость {car} на 5 сек увеличена на 50 км/ч");
        }
    }

    public class HighSpeed : ISpeed
    {
        public void Speed(Car car)
        {
            Console.WriteLine($"скорость {car} 200 км/ч");
        }
    }

    public class LowSpeed : ISpeed
    {
        public void Speed(Car car)
        {
            Console.WriteLine($"скорость {car} 150 км/ч");
        }
    }

    public interface ICarFactory
    {
        IBoost GetBoost();
        ISpeed GetSpeed();
    }

    public class BMWFactory : ICarFactory
    {
        public IBoost GetBoost()
        {
            return new LowBoost();
        }

        public ISpeed GetSpeed()
        {
            return new LowSpeed();
        }
    }
    public class ToyotaFactory : ICarFactory
    {
        public IBoost GetBoost()
        {
            return new HighBoost();
        }

        public ISpeed GetSpeed()
        {
            return new HighSpeed();
        }
    }

    public class CustomCarFactory : ICarFactory
    {
        public IBoost GetBoost()
        {
            return new LowBoost();
            //return new UserVariant();
        }

        public ISpeed GetSpeed()
        {
            return new HighSpeed();
            //return new UserVariant();
        }
    }



    public class Car 
    {
        public IBoost Boost { get; set; }

        public ISpeed Speed { get; set; }

        public Car(ICarFactory factory)
        {
            Boost = factory.GetBoost();
            Speed = factory.GetSpeed();
        }
    }


    class AbstractFactory
    {
        static void Main(string[] args)
        {
            Car toyota = new Car(new ToyotaFactory()); //если хотим другую машину меняет название factory
        }
    }
}
