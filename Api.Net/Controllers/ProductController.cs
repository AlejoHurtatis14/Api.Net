using Api.Net.Database;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly DataBase dataBase;

        public ProductController(DataBase data)
        {
            dataBase = data;
        }

        [HttpGet(Name = "Obtener Lista de Productos")]
        public IEnumerable<Product> listProducts()
        {
            return dataBase.products.Include(p => p.category).Include(d => d.desiredProducts).ToArray();
        }

        [HttpGet("{id}", Name = "Obtener Producto")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var product = await dataBase.products
                                    .Include(p => p.category)
                                    .Include(p => p.desiredProducts)
                                    .FirstOrDefaultAsync(p => p.id == id);
            if (product == null) {
                return NotFound();
            }
            return product;
        }

    }
}
