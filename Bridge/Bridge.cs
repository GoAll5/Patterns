using System;

namespace Bridge
{
    interface IConsole
    {
        void ExecuteCommand(string cmd);
    }

    class Console1 : IConsole
    {
        public void ExecuteCommand(string cmd)
        {
            Console.WriteLine($"Console 1 : {cmd}");
        }
    }

    class Console2 : IConsole
    {
        public void ExecuteCommand(string cmd)
        {
            Console.WriteLine($"Console 2 : {cmd}");
        }
    }

    abstract class Joystick
    {
        protected IConsole _cosole;
        public void ChangeConsole(IConsole console)
        {
            _cosole = console;
        }
        public void SendX()
        {
            _cosole.ExecuteCommand("X");
        }
        public void SendL1()
        {
            _cosole.ExecuteCommand("L1");
        }
    }

    class SimleJoystick : Joystick
    {

    }

    class SmartJoystick : Joystick
    {
        public void SmartButton()
        {
            _cosole.ExecuteCommand("X");
            _cosole.ExecuteCommand("L1");
        }
    }

    class Bridge
    {
        static void Main(string[] args)
        {
            var c1 = new Console1();
            var smart = new SmartJoystick();

            smart.ChangeConsole(c1);
            smart.SmartButton();

            var c2 = new Console2();
            smart.ChangeConsole(c2);
            smart.SmartButton();

        }
    }
}
