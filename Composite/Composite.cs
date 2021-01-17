using System;
using System.Collections.Generic;

namespace Composite
{
    interface INode //узел
    {
        string Name { get; }
        void Display();

    }
    class File : INode
    {
        public File(string name)
        {
            Name = name;
        }
        public string Name { get;  }

        public void Display()
        {
            Console.WriteLine($"File: {Name}");
        }
    }

    class Directory : INode //компоновщик
    {
        private List<INode> _children = new List<INode>();

        public Directory(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public void Add(INode node)
        {
            _children.Add(node);
        }
        public void Remove(INode node)
        {
            _children.Remove(node);
        }
        public void Display()
        {
            Console.WriteLine($"Directory: {Name}");
            foreach(var node in _children)
            {
                node.Display();
            }
        }
    }
    class Composite
    {
        static void Main(string[] args)
        {
            var fs = new Directory("/");

            var diskC = new Directory("Local Drive C");
            fs.Add(diskC);
            var txt = new File("data.txt");
            diskC.Add(txt);

            var png = new File("image.png");

            fs.Display();
        }
    }
}
