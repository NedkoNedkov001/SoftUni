using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;

        private int currentIndex = -1;

        public Book Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            books = new List<Book>(books);
        }
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            return ++currentIndex < books.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
