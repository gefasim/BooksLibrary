using System.Xml.Serialization;
using BooksLibrary.Models;

namespace BooksLibrary;

public class BooksReader
{
    public static BooksService ReadFile(string path)
    {
        var serializer = new XmlSerializer(typeof(BooksWrapper));
        BooksWrapper? books;
        using var stream = new FileStream(path, FileMode.Open);
        books = serializer.Deserialize(stream) as BooksWrapper;
        return new BooksService(books ?? new BooksWrapper(), path);
    }
}