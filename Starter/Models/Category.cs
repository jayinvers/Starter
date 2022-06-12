namespace Starter.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public int ParentId { get; set; }

        public List<Product> Products { get; set; }
    }
}
