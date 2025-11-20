using System.Xml.Serialization;

namespace BooksLibrary.Models;

[XmlRoot(ElementName = "BooksRoot")]
public class BooksWrapper
{
    [XmlArray(ElementName = "Books")]
    public Book[] BooksArray { get; set;}

    public BooksWrapper() {}

    public BooksWrapper(Book[] books)
    {
        BooksArray = books;
    }
}