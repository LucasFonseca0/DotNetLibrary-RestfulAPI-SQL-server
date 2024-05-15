using WebAPI8.Dto.Binding;

namespace WebAPI8.Dto.Book
{
    public class BookEditionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public AuthorBindingDto Author { get; set; }
    }
}
