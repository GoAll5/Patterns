using System;
using System.Collections.Generic;

namespace Builder
{
    class Builder
    {   
        class Car
        {
            public Car(string weight, string[] extra)
            {
                Weight = weight;
                Extra = extra;
            }
            public string Weight { get; protected set; } // easy, hard

            public string[] Extra { get; protected set; } //печка вебасто парктроники камера
        }

        interface ICarBuilder
        {

            ICarBuilder SetWeight(string weight);
            ICarBuilder SetExtra(string[] extra);

            ICarBuilder Reset();
            Car Build();
        }

        class EasyBuilder : ICarBuilder
        {
            protected string Weight = ""; 

            protected List<string> Extra = new List<string>();
            //protected Car c;

            public Car Build()
            {
                var c = new Car(Weight, Extra.ToArray());
                //sbros
                return c;
            }

            public ICarBuilder Reset()
            {
                //sbros
                return this;
            }

            public ICarBuilder SetExtra(string[] extra)
            {
                Extra = new List<string>(extra);
                return this;
            }

            public ICarBuilder SetWeight(string weight)
            {
                Weight = weight;
                return this;
            }
        }

        class CarDirector
        {
            public ICarBuilder builder = new EasyBuilder();
            public CarDirector(ICarBuilder builder)
            {
                builder.SetWeight("easy").SetExtra(
                new string[] { "печка", "вебасто" });
            }
            public Car Make()
            {
                return builder.Build();
            }

        }

        static void Main(string[] args)
        {
            ICarBuilder builder = new EasyBuilder();
            Car car = builder.SetWeight("easy").SetExtra(
                new string[] { "печка", "вебасто" }).Build();
            var director = new CarDirector(new EasyBuilder());
            //director.builder.SetExtra().Build();
            //var car2 = director.Make();
            var c = director.builder.Build();
        }
    }
}
// есть объект 