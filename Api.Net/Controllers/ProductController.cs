using Api.Net.Interfaces;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet(Name = "Obtener Lista de Productos")]
        public IEnumerable<Product> listProducts()
        {
            return productRepository.listProducts();
        }

        [HttpGet("{id}", Name = "Obtener Producto")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var product = await productRepository.getProduct(id);
            if (product == null) {
                return NotFound();
            }
            return product;
        }

    }
}
