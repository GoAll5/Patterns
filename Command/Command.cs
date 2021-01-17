using System;
using System.Collections;
using System.Collections.Generic;

namespace Command
{
    class Editor
    {
        public string Text { get; set; }
    }

    interface ICommand
    {
        void Execute();
        void Undo();

    }

    abstract class Command : ICommand
    {
        protected Editor _editor;

        protected Command(Editor editor)
        {
            _editor = editor;
        }
        public abstract void Execute();

        public abstract void Undo();
    }

    class CopyCommand : Command
    {

        protected CopyCommand(Editor e) : base(e)
        {
            
        }
        public override void Execute()
        {
            Console.WriteLine($"Запоминаем '{_editor.Text}' в буфер обмена");
        }

        public override void Undo()
        {
        }
    }

    class CutCommand : Command
    {
        protected string _backup;

        public CutCommand(Editor e) : base(e)
        {

        }
        public override void Execute()
        {
            _backup = _editor.Text;
            _editor.Text = string.Empty;
            //Console.WriteLine($"Запоминаем '{_editor.Text}' в буфер обмена");
        }

        public override void Undo()
        {
            _editor.Text = _backup;
        }
    }

    class Coommand
    {
        static void Main(string[] args)
        {
            var editor = new Editor();
            var history = new Stack<ICommand>();

            editor.Text = "hello";

            var cmd = new CutCommand(editor);
            cmd.Execute();
            history.Push(cmd);
            Console.WriteLine(editor.Text);

            history.Pop().Undo();
            Console.WriteLine(editor.Text);
        }
    }
}
