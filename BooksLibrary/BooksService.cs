using System.Xml.Serialization;
using BooksLibrary.Models;

namespace BooksLibrary;

public class BooksService
{
    private readonly BooksWrapper books;
    private readonly string path;

    internal BooksService(BooksWrapper books, string path)
    {
        this.books = books;
        this.path = path;
    }

    public IEnumerable<Book> GetAll()
    {
        return books.BooksArray;
    }

    public BooksService Add(Book book)
    {
        books.BooksArray = books.BooksArray != null
            ? [.. books.BooksArray, book]
            : [book];
        return this;
    }

    public BooksService Sort()
    {
        return this;
    }

    public IEnumerable<Book> Find(string title)
    {
        return books.BooksArray != null && books.BooksArray.Length > 0
            ? books.BooksArray.Where(b => b.Title.Contains(title))
            : [];
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(BooksWrapper));
        using TextWriter writer = new StreamWriter(path);
        serializer.Serialize(writer, books);
    }
}