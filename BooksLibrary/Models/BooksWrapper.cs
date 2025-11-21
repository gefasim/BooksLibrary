using System.Xml.Serialization;

namespace BooksLibrary.Models;

[XmlRoot(ElementName = "BooksRoot")]
public class BooksWrapper
{
    [XmlArray(ElementName = "Books")]
    public List<Book> Books { get; set;}

    public BooksWrapper() {}

    public BooksWrapper(List<Book> books)
    {
        Books = books;
    }
}