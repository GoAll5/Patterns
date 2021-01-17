using System;

namespace Strategy
{
    class Point { }

    class Track { }
    interface IPlaner
    {
        Track Build(Point a, Point b);
    }

    class MapApp
    {
        private IPlaner _planer;

        public void SetPlaner(IPlaner p)
        {
            _planer = p;
        }

        public Track BuildTrack(Point a, Point b) => _planer.Build(a, b);

    }

    class WalkPlaner : IPlaner
    {
        public Track Build(Point a, Point b)
        {
            Console.WriteLine("Маршрут по WalkPlaner");
            return new Track();
        }
    }

    class CarPlaner : IPlaner
    {
        public Track Build(Point a, Point b)
        {
            Console.WriteLine("Маршрут по WalkPlaner");
            return new Track();
        }
    }
    class Strategy
    {
        static void Main(string[] args)
        {
            var app = new MapApp();
            var a = new Point();
            var b = new Point();

            app.SetPlaner(new WalkPlaner());

            app.BuildTrack(a, b);

            app.SetPlaner(new CarPlaner());
            app.BuildTrack(a, b);
        }
    }
}
