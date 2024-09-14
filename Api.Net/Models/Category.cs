using Microsoft.Extensions.Hosting;

namespace Api.Net.Models
{
    public class Category
    {

        public int id { get; set; }
        public required string title { get; set; }

        public ICollection<Product> products { get; }

    }
}
