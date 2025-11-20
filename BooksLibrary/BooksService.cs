using System.Xml.Serialization;
using BooksLibrary.Models;

namespace BooksLibrary;

public class BooksService
{
    private BooksWrapper books;
    private readonly string path;

    internal BooksService(BooksWrapper books, string path)
    {
        this.books = books;
        this.path = path;
    }

    public IEnumerable<Book> Get()
    {
        return null;
    }

    public BooksService Add()
    {
        return this;
    }

    public BooksService Sort()
    {
        return this;
    }

    public Book? Find(string title)
    {
        return null;
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(BooksWrapper));
        using TextWriter writer = new StreamWriter(path);
        serializer.Serialize(writer, books);
    }
}