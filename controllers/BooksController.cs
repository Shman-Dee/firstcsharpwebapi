using Microsoft.AspNetCore.Mvc;

[ApiController]

public class BooksController : ControllerBase
{
    private static List<Book> BOOKS = [
        new Book { BookId = "1", Title = "The Great Gatsby", Genre = "Fiction", AuthorId = "1" },
        new Book { BookId = "2", Title = "The Stand", Genre = "Horror", AuthorId = "2" },
        new Book { BookId = "3", Title = "The Da Vinci Code", Genre = "Mystery", AuthorId = "3" },
        new Book { BookId = "4", Title = "The Catcher in the Rye", Genre = "Fiction", AuthorId = "4" },
        new Book { BookId = "5", Title = "It", Genre = "Horror", AuthorId = "2" },
    ];

    [HttpGet("/books", Name = "Books")]
    public List<Book> GetBooks()
    {
        return BOOKS;
    }

    [HttpGet("/books/{bookId}", Name = "GetBookById")]
    public Book? GetBookById(string bookId)
    {
        return BOOKS.Find(book => book.BookId == bookId);
    }

    [HttpGet("/authors/{authorId}", Name = "GetBooksByAuthorId")]
    public List<Book> GetBooksByAuthorId(string authorId)
    {
        return BOOKS.FindAll(book => book.AuthorId == authorId);
    }

    [HttpPost("/books", Name = "CreateBook")]
    public Book CreateBook([FromBody] BookCreateRequest request)
    {
        //Map our BookCreateRequest to an actual Book.
        Book bookToSave = new Book
        {
            Title = request.Title,
            Genre = request.Genre,
            AuthorId = request.AuthorId,
            BookId = (BOOKS.Count + 1).ToString()
        };
        //"Save" the book to our in-memory database.
        BOOKS.Add(bookToSave);
        return bookToSave;
    }
}
