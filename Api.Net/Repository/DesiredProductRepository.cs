using Api.Net.Controllers;
using Api.Net.Database;
using Api.Net.Interfaces;
using Api.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Net.Repository
{
    public class DesiredProductRepository : IDesiredProductRepository
    {
        private readonly DataBase dataBase;

        public DesiredProductRepository(DataBase data)
        {
            dataBase = data;
        }

        public IEnumerable<DesiredProduct> listProducts()
        {
            return dataBase.desiredProducts.Include(p => p.product).Include(u => u.user).ToArray();
        }

        public async Task<DesiredProduct> postDesiredProduct(PostDesiredProd postDesiredProd)
        {

            var user = await dataBase.users.FindAsync(postDesiredProd.userId);
            if (user == null)
            {
                return null;
            }

            var product = await dataBase.products.FindAsync(postDesiredProd.productId);
            if (product == null)
            {
                return null;
            }

            DesiredProduct desiredSave = new DesiredProduct
            {
                productId = product.id,
                userId = user.Id
            };

            dataBase.desiredProducts.Add(desiredSave);
            await dataBase.SaveChangesAsync();
            return desiredSave;
        }

        public async Task<Boolean> deleteDesiredProduct(int id)
        {
            var desiredProduct = await dataBase.desiredProducts.FindAsync(id);

            if (desiredProduct != null)
            {
                dataBase.desiredProducts.Remove(desiredProduct);
                await dataBase.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<DesiredProduct> getDesiredProductUser(int id)
        {
            var desiredProduct = await dataBase.desiredProducts
                                    .Include(p => p.product)
                                    .Include(u => u.user)
                                    .FirstOrDefaultAsync(p => p.userId == id);

            if (desiredProduct == null)
            {
                return null;
            }
            return desiredProduct;
        }
    }
}
