using WebAPI8.Dto.Author;
using WebAPI8.Dto.Book;
using WebAPI8.Models;

namespace WebAPI8.Services.Book
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<BookModel>> GetBookById(int id);
        Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookCreationDto bookCreationDto);

        Task<ResponseModel<List<BookModel>>> UpdateBook(BookEditionDto bookEditionDto);

        Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId);
    }
}
