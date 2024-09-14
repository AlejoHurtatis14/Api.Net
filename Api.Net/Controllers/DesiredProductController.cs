using Api.Net.Database;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/desired-product")]
    public class DesiredProductController : ControllerBase
    {
        private readonly DataBase dataBase;

        public DesiredProductController(DataBase data)
        {
            dataBase = data;
        }

        [HttpGet(Name = "Obtener Lista de Productos Deseados")]
        public IEnumerable<DesiredProduct> listProducts()
        {
            return dataBase.desiredProducts.Include(p => p.product).Include(u => u.user).ToArray();
        }

        [HttpPost(Name = "Crear Producto deseado")]
        public async Task<ActionResult<DesiredProduct>> postDesiredProduct(PostDesiredProd postDesiredProd)
        {

            var user = await dataBase.users.FindAsync(postDesiredProd.userId);
            if (user == null)
            {
                return NotFound();
            }

            var product = await dataBase.products.FindAsync(postDesiredProd.productId);
            if (product == null)
            {
                return NotFound();
            }

            DesiredProduct desiredSave = new DesiredProduct
            {
                productId = product.id,
                userId = user.Id
            };

            dataBase.desiredProducts.Add(desiredSave);
            await dataBase.SaveChangesAsync();
            return Ok(desiredSave);
        }

        [HttpDelete("{id}", Name = "Eliminar Producto deseado")]
        public async Task<ActionResult<DesiredProduct>> deleteDesiredProduct(int id)
        {
            var desiredProduct = await dataBase.desiredProducts.FindAsync(id);

            if (desiredProduct != null) {
                dataBase.desiredProducts.Remove(desiredProduct);
                await dataBase.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }

    public class PostDesiredProd
    {
        public int productId { get; set; }
        public int userId { get; set; }
    }
}
