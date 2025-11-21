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

    /// <summary>
    /// Gets all books
    /// </summary>
    /// <returns>IEnumerable of books</returns>
    public IEnumerable<Book> GetAll()
    {
        return booksWrapper.Books ?? [];
    }

    /// <summary>
    /// Adds a book in the end of the collection
    /// </summary>
    /// <param name="book">book model</param>
    /// <returns>BooksService</returns>
    public BooksService Add(Book book)
    {
        booksWrapper.Books = booksWrapper.Books != null
            ? [.. booksWrapper.Books, book]
            : [book];
        return this;
    }

    /// <summary>
    /// Sort books by Author first, then by Title
    /// </summary>
    /// <returns>BooksService</returns>
    public BooksService Sort()
    {
        booksWrapper.Books = booksWrapper.Books != null && booksWrapper.Books.Count > 0
            ? [.. booksWrapper.Books.OrderBy(book => book.Author).ThenBy(book => book.Title)]
            : [];
        return this;
    }

    /// <summary>
    /// Find books by substring of the title
    /// </summary>
    /// <param name="title">substring of the title</param>
    /// <returns>IEnumerable of books</returns>
    public IEnumerable<Book> Find(string title)
    {
        return booksWrapper.Books != null && booksWrapper.Books.Count > 0
            ? booksWrapper.Books.Where(b => b.Title.Contains(title))
            : [];
    }

    /// <summary>
    /// Saves the books to the XML file
    /// </summary>
    public void Save()
    {
        var serializer = new XmlSerializer(typeof(BooksWrapper));
        using TextWriter writer = new StreamWriter(path);
        serializer.Serialize(writer, booksWrapper);
    }
}
