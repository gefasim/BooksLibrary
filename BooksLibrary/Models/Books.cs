using System.Xml.Serialization;

namespace BooksLibrary.Models;

[XmlRoot(ElementName = "BooksRoot")]
public class Books
{
    [XmlArray(ElementName = "Books")]
    public required IEnumerable<Book> BooksArray { get; set;}

    public Books() {}

    public Books(IEnumerable<Book> books)
    {
        BooksArray = books;
    }
}