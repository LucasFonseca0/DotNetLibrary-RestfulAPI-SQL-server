namespace WebAPI8.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public AuthorModel Author { get; set; }
    }
}
