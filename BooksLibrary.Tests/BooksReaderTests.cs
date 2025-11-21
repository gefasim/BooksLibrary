
namespace BooksLibrary.Tests;

public class BooksReaderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReadOrCreateFile_FileDoesNotExists_EmptyBooksWrapperReturned()
    {
        // Arrange
        const string filePath = "./TestsData/missingFile.xml";

        // Act
        var service = BooksReader.ReadOrCreateFile(filePath);

        // Assert
        Assert.That(service.GetAll(), Is.Empty);
    }

    [Test]
    public void ReadOrCreateFile_FileExistsWithNoBooks_EmptyBooksWrapperReturned()
    {
        // Arrange
        const string filePath = "./TestsData/validFileWithNoBooks.xml";

        // Act
        var service = BooksReader.ReadOrCreateFile(filePath);

        // Assert
        Assert.That(service.GetAll(), Is.Empty);
    }

    [Test]
    public void ReadOrCreateFile_InvalidFile_ExceptionThrown()
    {
        // Arrange
        const string filePath = "./TestsData/invalidFile.xml";

        // Act & Assert
        Assert.Throws<Exception>(() => BooksReader.ReadOrCreateFile(filePath));
    }
}