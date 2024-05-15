using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI8.Data;
using WebAPI8.Dto.Author;
using WebAPI8.Models;

namespace WebAPI8.Services.Author
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorFromDb => authorFromDb.Id == authorId);

                if (author == null)
                {
                    response.Message = "No author found!";
                    return response;
                }

                response.Data = author;
                response.Message = "Author located";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(bookFromDb => bookFromDb.Id == bookId);

                if (book == null)
                {
                    response.Message = "No record found!";
                    return response;
                }
                response.Data = book.Author;
                response.Message = "author located";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreationDto authorCreationDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = new AuthorModel()
                {
                    Name = authorCreationDto.Name,
                    LastName = authorCreationDto.LastName
                };

                _context.Add(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author created successfully!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorEditionDto authorEditionDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorFromDb => authorFromDb.Id == authorEditionDto.Id);

                if (author == null)
                {
                    response.Message = "No Author found";
                    return response;
                }

                author.Name = authorEditionDto.Name;
                author.LastName = authorEditionDto.LastName;

                _context.Update(author);
                await _context.SaveChangesAsync();


                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author edited successfully";

                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorFromDb => authorFromDb.Id == authorId);

                if (author == null)
                {
                    response.Message = "No Author found";
                    return response;
                }

                _context.Remove(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author Removed successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();

                response.Data = authors;
                response.Message = "All authors collected";
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
