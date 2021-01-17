using System;
using System.Collections.Generic;

namespace Visitor
{
    interface IVisitor
    {
        void Visit(Admin a);

        void Visit(User u);

        void Visit(Staff s);
    }

    interface IVisitable
    {
        void Accept(IVisitor v);

    }

    class HtmlVisitor : IVisitor
    {
        private string _data = string.Empty;
        public void Visit(Admin a)
        {
            _data += $"<p>{a.Info}</p>";
        }

        public void Visit(User u)
        {
            _data += $"<p>{u.Info}</p>";
        }

        public void Visit(Staff s)
        {
            _data += $"<p>{s.Info}</p>";
        }

        public string Report() => _data;
    }



    class Admin : IVisitable
    {
        public string Info => "Admin";
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }

    class Staff : IVisitable
    {
        public string Info => "Staff";
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }

    class User : IVisitable
    {
        public string Info => "User";
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }

    class Company
    {
        List<IVisitable> _participants = new List<IVisitable>();

        public void Add(IVisitable v) => _participants.Add(v);

        public void Remove(IVisitable v) => _participants.Remove(v);

        public void Accept(IVisitor v)
        {
            foreach(var p in _participants)
            {
                p.Accept(v);
            }
        }
       

    }
    class Visitor
    {
        static void Main(string[] args)
        {
            var c = new Company();
            c.Add(new Admin());
            c.Add(new User());
            c.Add(new Staff());

            var html = new HtmlVisitor();
            c.Accept(html);
            Console.WriteLine(html.Report());


        }
    }
}
