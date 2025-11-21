using System.Xml.Serialization;
using BooksLibrary.Models;

namespace BooksLibrary;

public class BooksReader
{
    /// <summary>
    /// Reads XML file with Books.
    /// Creates a new file on a step <see cref="BookService.Save()"/> if file doesn't exists.
    /// </summary>
    /// <param name="path">books xml file path</param>
    /// <returns>BooksService</returns>
    public static BooksService ReadOrCreateFile(string path)
    {
        if (!File.Exists(path))
        {
            return new BooksService(new BooksWrapper(), path);
        }

        try
        {
            var serializer = new XmlSerializer(typeof(BooksWrapper));
            BooksWrapper? books;
            using var stream = new FileStream(path, FileMode.Open);
            books = serializer.Deserialize(stream) as BooksWrapper;
            return new BooksService(books ?? new BooksWrapper(), path);
        } catch (InvalidOperationException e)
        {
            throw new Exception("Invalid data format", e);
        } catch (Exception e)
        {
            throw new Exception("Exception occurred on the file read", e);
        }
    }
}