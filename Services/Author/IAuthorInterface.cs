using WebAPI8.Dto.Author;
using WebAPI8.Models;

namespace WebAPI8.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int id);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreationDto authorCreationDto);

        Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorEditionDto authorEditionDto);

        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId);
    }
}
