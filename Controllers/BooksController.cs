using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendProject.Data;
using MyBackendProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MyBackendProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        #region Constructor

        // Constructor that injects the AppDbContext
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Loading of Navigational Properties

        [HttpGet("eager-loading")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithEagerLoading()
        {
            // Eager loading of Authors and Genres
            var books = await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .ToListAsync();

            return books;
        }

        [HttpGet("explicit-loading/{id}")]
        public async Task<ActionResult<Book>> GetBookWithExplicitLoading(int id)
        {
            // Find the book by id
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            // Explicit loading of Authors
            await _context.Entry(book)
                .Collection(b => b.Authors)
                .LoadAsync();

            // Explicit loading of Genres
            await _context.Entry(book)
                .Collection(b => b.Genres)
                .LoadAsync();

            return book;
        }

        #endregion

        #region Join Operators

        [HttpGet("join-example")]
        public async Task<ActionResult<IEnumerable<object>>> GetBooksWithAuthorsUsingJoin()
        {
            // Using join to get books with their authors
            var booksWithAuthors = await _context.Books
                .Join(_context.Authors,
                    book => book.Id,
                    author => author.Id,
                    (book, author) => new
                    {
                        BookTitle = book.Title,
                        AuthorName = author.Name
                    })
                .ToListAsync();

            return booksWithAuthors;
        }

        #endregion

        #region Tracking VS No Tracking

        [HttpGet("tracking")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithTracking()
        {
            // Query with tracking (default behavior)
            var books = await _context.Books.ToListAsync();
            return books;
        }

        [HttpGet("no-tracking")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithNoTracking()
        {
            // Query with no tracking
            var books = await _context.Books.AsNoTracking().ToListAsync();
            return books;
        }

        #endregion

        #region Remote VS Local Evaluation

        [HttpGet("remote-evaluation")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithRemoteEvaluation(string searchTerm)
        {
            // Remote evaluation: filtering is done on the database server
            var books = await _context.Books
                .Where(b => b.Title.Contains(searchTerm))
                .ToListAsync();

            return books;
        }

        [HttpGet("local-evaluation")]
        public ActionResult<IEnumerable<Book>> GetBooksWithLocalEvaluation(string searchTerm)
        {
            // Local evaluation: all data is fetched and then filtered in memory
            var books = _context.Books.ToList()
                .Where(b => b.Title.Contains(searchTerm));

            return books.ToList();
        }

        #endregion

        #region Run SQL Query

        [HttpGet("run-sql-query")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksUsingSqlQuery()
        {
            // Running a raw SQL query
            var books = await _context.Books.FromSqlRaw("SELECT * FROM Books").ToListAsync();
            return books;
        }

        #endregion
    }
}