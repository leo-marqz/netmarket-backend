
namespace API.DTOs.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
