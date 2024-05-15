using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8.Dto.Author;
using WebAPI8.Models;
using WebAPI8.Services.Author;

namespace WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet("ListAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAuthors()
        {
            var authors = await _authorInterface.ListAuthors();

            return Ok(authors);
        }
        [HttpGet("GetAuthorById/{authorId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int authorId)
        {
            var author = await _authorInterface.GetAuthorById(authorId);

            return Ok(author);
        }
        [HttpGet("GetAuthorByBookId/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int bookId)
        {
            var author = await _authorInterface.GetAuthorByBookId(bookId);

            return Ok(author);
        }
        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreationDto authorCreationDto)
        {
            var authors = await _authorInterface.CreateAuthor(authorCreationDto);

            return Ok(authors);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> UpdateAuthor(AuthorEditionDto authorEditionDto)
        {
            var authors = await _authorInterface.UpdateAuthor(authorEditionDto);

            return Ok(authors);
        }

        [HttpDelete("DeleteAuthor/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int authorId)
        {
            var authors = await _authorInterface.DeleteAuthor(authorId);

            return Ok(authors);
        }
    }
}
