using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookAPIDbContext dbContext;

        public BooksController(BookAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet] //Get All Books Data
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await dbContext.Books.ToListAsync());
        }

        [HttpGet] //Get Particular Book Data 
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBook([FromRoute] Guid id)
        {
            var book = await dbContext.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound("Book Not Found");
            }

            return Ok(book);
        }

        [HttpPost] //Save Books Data
        public async Task<IActionResult> AddBooks(AddBookRequest addBookRequest)
        {
            var book = new Book()
            {
                BookId = Guid.NewGuid(),
                BookTitle = addBookRequest.BookTitle,
                BookDescription = addBookRequest.BookDescription,
                BookAuthor = addBookRequest.BookAuthor
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPut] //Update Particular Book Data
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBooks([FromRoute] Guid id, UpdateBookRequest updateBookRequest)
        { 
        var book= await dbContext.Books.FindAsync(id);

            if(book != null) {
            
                book.BookTitle=updateBookRequest.BookTitle;
                book.BookDescription=updateBookRequest.BookDescription;
                book.BookAuthor=updateBookRequest.BookAuthor;

                await dbContext.SaveChangesAsync();

                return Ok(book);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBooks([FromRoute] Guid id)
        {
            var book = await dbContext.Books.FindAsync(id);
            if(book != null)
            {
                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();
        }
    }
}
