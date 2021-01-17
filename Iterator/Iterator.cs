using System;
using System.Collections.Generic;

namespace Iterator
{
    class Book { }
    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
    interface IBookEnumrable
    {
        int Count { get; }

        Book Take(int index);
        IBookIterator Iterator();
    }

    class BookIterator : IBookIterator
    {
        protected IBookEnumrable _lib;

        protected int _index;
        public BookIterator(IBookEnumrable lib)
        {
            _lib = lib;
            _index = 0;
        }
        public bool HasNext()
        {
            return _index < _lib.Count;
        }

        public Book Next()
        {
            return _lib.Take(_index++);
        }
    }


    class Library : IBookEnumrable
    {
        protected List<Book> _books = new List<Book>();
        public int Count => _books.Count;

        public IBookIterator Iterator()
        {
            return new BookIterator(this);
        }

        public Book Take(int index)
        {
            return _books[index];
        }
    }

    class Iiterator
    {
        static void Main(string[] args)
        {
            var lib = new Library();

            var it = lib.Iterator();
            while (it.HasNext())
            {
                var b = it.HasNext();
                Console.WriteLine(b);
            }
            //var it2 = new MyIterator(lib);
            while (it.HasNext())
            {
                var b = it.Next();
                Console.WriteLine(b);
            }
        }
    }
}
