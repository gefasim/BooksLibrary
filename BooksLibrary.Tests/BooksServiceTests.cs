
using BooksLibrary.Models;

namespace BooksLibrary.Tests;

public class BooksServicerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetAll_ValidFile_AllBooksReturned()
    {
        // Arrange
        const string filePath = "./TestsData/validFileWithBooks.xml";

        // Act
        var books = BooksReader.ReadOrCreateFile(filePath).GetAll().ToArray();

        // Assert
        Assert.That(books, Has.Length.EqualTo(5));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(books[0].Author, Is.EqualTo("Bryce"));
            Assert.That(books[0].Title, Is.EqualTo("Echo"));
            Assert.That(books[4].Author, Is.EqualTo("Adam"));
            Assert.That(books[4].Title, Is.EqualTo("Alfa"));
        }
    }

    [Test]
    public void Add_ValidFile_AllBooksAdded()
    {
        // Arrange
        const string filePath = "./TestsData/validFileWithBooks.xml";
        var newBook1 = new Book("Test Title 1", "Test Author 1", 0);
        var newBook2 = new Book("Test Title 2", "Test Author 2", 0);

        // Act
        var books = BooksReader.ReadOrCreateFile(filePath).Add(newBook1).Add(newBook2)
            .GetAll().ToArray();

        // Assert
        Assert.That(books, Has.Length.EqualTo(7));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(books[0].Author, Is.EqualTo("Bryce"));
            Assert.That(books[0].Title, Is.EqualTo("Echo"));
            Assert.That(books[4].Author, Is.EqualTo("Adam"));
            Assert.That(books[4].Title, Is.EqualTo("Alfa"));
            Assert.That(books[5].Author, Is.EqualTo(newBook1.Author));
            Assert.That(books[5].Title, Is.EqualTo(newBook1.Title));
            Assert.That(books[6].Author, Is.EqualTo(newBook2.Author));
            Assert.That(books[6].Title, Is.EqualTo(newBook2.Title));
        }
    }

    [Test]
    public void Sort_ValidFile_AllBooksSorted()
    {
        // Arrange
        const string filePath = "./TestsData/validFileWithBooks.xml";
        var newBook1 = new Book("Test Title 1", "Test Author 1", 0);
        var newBook2 = new Book("Test Title 2", "Test Author 2", 0);

        // Act
        var books = BooksReader.ReadOrCreateFile(filePath).Add(newBook2).Add(newBook1)
            .Sort().GetAll().ToArray();

        // Assert
        Assert.That(books, Has.Length.EqualTo(7));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(books[0].Author, Is.EqualTo("Adam"));
            Assert.That(books[0].Title, Is.EqualTo("Alfa"));
            Assert.That(books[4].Author, Is.EqualTo("Cooper"));
            Assert.That(books[4].Title, Is.EqualTo("Foxtrot"));
            Assert.That(books[5].Author, Is.EqualTo(newBook1.Author));
            Assert.That(books[5].Title, Is.EqualTo(newBook1.Title));
            Assert.That(books[6].Author, Is.EqualTo(newBook2.Author));
            Assert.That(books[6].Title, Is.EqualTo(newBook2.Title));
        }
    }

    [Test]
    public void Find_ValidFile_BookReturned()
    {
        // Arrange
        const string filePath = "./TestsData/validFileWithBooks.xml";

        // Act
        var books = BooksReader.ReadOrCreateFile(filePath).Find("oxtro").ToArray();

        // Assert
        Assert.That(books, Has.Length.EqualTo(1));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(books[0].Author, Is.EqualTo("Cooper"));
            Assert.That(books[0].Title, Is.EqualTo("Foxtrot"));
        }
    }

    [Test]
    public void Sava_MissingFile_NewFileCreated()
    {
        // Arrange
        const string filePath = "./TestsData/newFile.xml";
        File.Delete(filePath);
        var newBook1 = new Book("Test Title 1", "Test Author 1", 0);
        var newBook2 = new Book("Test Title 2", "Test Author 2", 0);

        // Act
        BooksReader.ReadOrCreateFile(filePath).Add(newBook2).Add(newBook1)
            .Sort().Save();
        var books = BooksReader.ReadOrCreateFile(filePath).GetAll().ToArray();

        // Assert
        Assert.That(books, Has.Length.EqualTo(2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(books[0].Author, Is.EqualTo(newBook1.Author));
            Assert.That(books[0].Title, Is.EqualTo(newBook1.Title));
            Assert.That(books[1].Author, Is.EqualTo(newBook2.Author));
            Assert.That(books[1].Title, Is.EqualTo(newBook2.Title));
        }
    }
}
