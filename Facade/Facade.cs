using System;

namespace Facade
{
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Write code...");
        }

        public void Save()
        {
            Console.WriteLine("Save code...");
        }
    }

    class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("Compilation...");
        }
    }

    class Linker
    {
        public void Link()
        {
            Console.WriteLine("Linking...");
        }
    }
    class Debugger
    {
        public void Execute()
        {
            Console.WriteLine("Executing...");
        }
        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }
    // -----------------------------------------------------
    class VSFacade
    {
        private TextEditor _te = new TextEditor();
        private Compiler _c = new Compiler();
        private Linker _l = new Linker();
        private Debugger _d = new Debugger();

        public void CreateCode()
        {
            _te.CreateCode();
        }
        public void Save()
        {
            _te.Save();
        }
        public void Run()
        {
            Save();
            _c.Compile();
            _l.Link();
            _d.Execute();
        }

        public void Stop()
        {
            _d.Stop();
        }
    }
    class Facade
    {
        static void Main(string[] args)
        {
            var ide = new VSFacade();

            ide.CreateCode();
            ide.Run();
            ide.Stop();
        }
    }
}
