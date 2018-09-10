using System.Collections;
using System.Collections.Generic;


public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = new SortedSet<Book>(books, new BookComparator());
    }

    public SortedSet<Book> Books { get; private set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        public LibraryIterator(SortedSet<Book> books)
        {
            this.Books = new List<Book>(books);
            this.CurrentIndex = -1;
        }

        public List<Book> Books { get; private set; }
        public int CurrentIndex { get; private set; }

        public Book Current => this.Books[this.CurrentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            this.CurrentIndex++;
            return this.CurrentIndex < this.Books.Count;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}