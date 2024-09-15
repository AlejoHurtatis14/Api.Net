using Api.Net.Interfaces;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/desired-product")]
    public class DesiredProductController : ControllerBase
    {

        private IDesiredProductRepository desiredProductRepository;

        public DesiredProductController(IDesiredProductRepository desired)
        {
            this.desiredProductRepository = desired;
        }

        [HttpGet(Name = "Obtener Lista de Productos Deseados")]
        public IEnumerable<DesiredProduct> listProducts()
        {
            return desiredProductRepository.listProducts();
        }

        [HttpPost(Name = "Crear Producto deseado")]
        public async Task<ActionResult<DesiredProduct>> postDesiredProduct(PostDesiredProd postDesiredProd)
        {
            var response = await desiredProductRepository.postDesiredProduct(postDesiredProd);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "Eliminar Producto deseado")]
        public async Task<ActionResult<DesiredProduct>> deleteDesiredProduct(int id)
        {
            var response = (Boolean) await desiredProductRepository.deleteDesiredProduct(id);
            if (response)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("{id}", Name = "Obtener productos deseados de un usuario")]
        public async Task<ActionResult<DesiredProduct>> getDesiredProductUser(int id)
        {
            var desiredProduct = await desiredProductRepository.getDesiredProductUser(id);

            if (desiredProduct == null)
            {
                return NotFound();
            }
            return desiredProduct;
        }
    }

    public class PostDesiredProd
    {
        public int productId { get; set; }
        public int userId { get; set; }
    }
}
