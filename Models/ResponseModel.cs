namespace WebAPI8.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = String.Empty;
        public bool Status { get; set; } = true;
    }
}
