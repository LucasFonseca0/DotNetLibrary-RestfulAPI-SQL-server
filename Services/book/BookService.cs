using Microsoft.EntityFrameworkCore;
using WebAPI8.Data;
using WebAPI8.Dto.Author;
using WebAPI8.Dto.Book;
using WebAPI8.Models;

namespace WebAPI8.Services.Book
{
    public class BookService : IBookInterface
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<BookModel>> GetBookById(int id)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(bookFromDb => bookFromDb.Id == id);

                if (book == null)
                {
                    response.Message = "No book found!";
                    return response;
                }

                response.Data = book;
                response.Message = "Book located";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(a => a.Author).Where(bookFromDb => bookFromDb.Author.Id == authorId).ToListAsync();

                if (books == null)
                {
                    response.Message = "No records found!";
                    return response;
                }
                response.Data = books;
                response.Message = "Books located";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreationDto bookCreationDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorFromDb => authorFromDb.Id == bookCreationDto.Author.Id);
                if (author == null)
                {
                    response.Message = "No author record found";
                    return response;
                }

                var book = new BookModel()
                {
                    Title = bookCreationDto.Title,
                    Author = author
                };

                _context.Add(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Message = "Book created successfully!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> UpdateBook(BookEditionDto bookEditionDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(bookFromDb => bookFromDb.Id == bookEditionDto.Id);

                var author = await _context.Authors.FirstOrDefaultAsync(authorFromDb => authorFromDb.Id == bookEditionDto.Author.Id);

                if (author == null)
                {
                    response.Message = "No author record found";
                    return response;
                }
                if (book == null)
                {
                    response.Message = "No book record found";
                    return response;
                }

                book.Title = bookEditionDto.Title;
                book.Author = author;

                _context.Update(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(bookFromDb => bookFromDb.Id == bookId);

                if (book == null)
                {
                    response.Message = "No Book found";
                    return response;
                }

                _context.Remove(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Message = "Book Removed successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<BookModel>>> ListBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(a => a.Author).ToListAsync();

                response.Data = books;
                response.Message = "All books collected";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

    }
}
