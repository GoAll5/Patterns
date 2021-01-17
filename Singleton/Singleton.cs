using System;

namespace Singleton
{   
    class Config
    {
        private static Lazy<Config> config = new Lazy<Config>(() => new Config()); // = new Config(); для многопоточки лишаемся ленивой инициализации
        protected Config()
        {

        }
        public static Config Instance()
        {
            //if(config == null)
            //{
            //    lock ()
            //    {
            //        config = new Config(); //сохраняем ливую инициализацию
            //    }
                
            //}
            return config.Value;
        }

    }
    class Singleton
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
