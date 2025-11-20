using System.Xml.Serialization;

namespace BooksLibrary.Models;

public class Book
{
    [XmlElement(ElementName = "Title")]
    public required string Title { get; set; }

    [XmlElement(ElementName = "Author")]
    public required string Author { get; set; }

    [XmlElement(ElementName = "NumberOfPages")]
    public int NumberOfPages { get; set; }

    public Book() {}
    
    public Book(string title, string author, int numberOfPages)
    {
        Title = title;
        Author = author;
        NumberOfPages = numberOfPages;
    }
}