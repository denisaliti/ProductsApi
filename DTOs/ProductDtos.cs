namespace ProductsApi.DTOs
{
    // Used for Reading data
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Fixed
        public string Category { get; set; } = string.Empty; // Fixed
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool InStock { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // Used for Creating data
    public class CreateProductDto
    {
        public required string Name { get; set; }
        public required string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    // Used for Updating data
    public class UpdateProductDto
    {
        public string Name { get; set; } = string.Empty; // Fixed
        public string Category { get; set; } = string.Empty; // Fixed
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}