using Api.Net.Models;

namespace Api.Net.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> listProducts();

        Task<Product> getProduct(int id);

    }
}
