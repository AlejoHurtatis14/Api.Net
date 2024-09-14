namespace Api.Net.Models
{
    public class Product
    {

        public int id { get; set; }

        public required string title { get; set; }

        public required string description { get; set; }

        public required decimal precio { get; set; }

        public int categoryId{ get; set; }

        public Category category { get; set; }

        public ICollection<DesiredProduct> desiredProducts { get; }

    }
}
