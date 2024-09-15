using Api.Net.Database;
using Api.Net.Interfaces;
using Api.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Net.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBase dataBase;

        public ProductRepository(DataBase data)
        {
            dataBase = data;
        }

        public IEnumerable<Product> listProducts()
        {
            return dataBase.products.Include(p => p.category).Include(d => d.desiredProducts).ToArray();
        }

        public async Task<Product> getProduct(int id)
        {
            var product = await dataBase.products
                                    .Include(p => p.category)
                                    .Include(p => p.desiredProducts)
                                    .FirstOrDefaultAsync(p => p.id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

    }
}
