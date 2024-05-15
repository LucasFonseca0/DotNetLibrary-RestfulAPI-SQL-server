using Microsoft.AspNetCore.Mvc;
using WebAPI8.Dto.Book;
using WebAPI8.Models;
using WebAPI8.Services.Book;

namespace WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        public BookController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }

        [HttpGet("ListBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var books = await _bookInterface.ListBooks();

            return Ok(books);
        }
        [HttpGet("GetBookById/{bookId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int bookId)
        {
            var book = await _bookInterface.GetBookById(bookId);

            return Ok(book);
        }
        [HttpGet("GetBooksByAuthorId/{authorId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBooksByAuthorId(int authorId)
        {
            var books = await _bookInterface.GetBooksByAuthorId(authorId);

            return Ok(books);
        }
        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookCreationDto bookCreationDto)
        {
            var book = await _bookInterface.CreateBook(bookCreationDto);

            return Ok(book);
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateBook(BookEditionDto bookEditionDto)
        {
            var book = await _bookInterface.UpdateBook(bookEditionDto);

            return Ok(book);
        }

        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int bookId)
        {
            var books = await _bookInterface.DeleteBook(bookId);

            return Ok(books);
        }
    }
}
