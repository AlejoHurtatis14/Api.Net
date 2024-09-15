using Api.Net.Interfaces;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet(Name = "Obtener Lista de Categorias de Productos")]
        public IEnumerable<Category> getCategories()
        {
            return this.categoryRepository.getCategories();
        }
    }
}
