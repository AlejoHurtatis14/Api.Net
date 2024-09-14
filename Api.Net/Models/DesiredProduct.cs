namespace Api.Net.Models
{
    public class DesiredProduct
    {

        public int Id { get; set; }

        public required int productId { get; set; }

        public Product product { get; set; }

        public required int userId { get; set; }

        public User user { get; set; }

    }
}
