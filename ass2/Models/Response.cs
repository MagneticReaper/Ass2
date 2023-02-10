namespace ass2.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public Product? Product { get; set; }
        public List<Product>? Products { get; set; }
    }
}
