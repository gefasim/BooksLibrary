using System.Xml.Serialization;
using BooksLibrary.Models;

namespace BooksLibrary;

public class BooksService
{
    private readonly BooksWrapper booksWrapper;
    private readonly string path;

    internal BooksService(BooksWrapper booksWrapper, string path)
    {
        this.booksWrapper = booksWrapper;
        this.path = path;
    }

    public IEnumerable<Book> GetAll()
    {
        return booksWrapper.Books ?? [];
    }

    public BooksService Add(Book book)
    {
        booksWrapper.Books = booksWrapper.Books != null
            ? [.. booksWrapper.Books, book]
            : [book];
        return this;
    }

    public BooksService Sort()
    {
        booksWrapper.Books = booksWrapper.Books != null && booksWrapper.Books.Count > 0
            ? [.. booksWrapper.Books.OrderBy(book => book.Author).ThenBy(book => book.Title)]
            : [];
        return this;
    }

    public IEnumerable<Book> Find(string title)
    {
        return booksWrapper.Books != null && booksWrapper.Books.Count > 0
            ? booksWrapper.Books.Where(b => b.Title.Contains(title))
            : [];
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(BooksWrapper));
        using TextWriter writer = new StreamWriter(path);
        serializer.Serialize(writer, booksWrapper);
    }
}