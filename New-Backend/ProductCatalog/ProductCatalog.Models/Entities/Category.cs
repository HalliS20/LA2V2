namespace ProductCatalog.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        // Navigation properties
        // One-to-many relationship with Product
        public List<Product> Products { get; set; } = [];
    }
}