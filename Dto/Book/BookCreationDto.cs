using WebAPI8.Dto.Binding;

namespace WebAPI8.Dto.Book
{
    public class BookCreationDto
    {
        public string Title { get; set; }

        public AuthorBindingDto Author { get; set; }
    }
}
