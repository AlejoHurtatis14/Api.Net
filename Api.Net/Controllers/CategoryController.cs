using Api.Net.Database;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly DataBase dataBase;

        public CategoryController(DataBase data)
        {
            dataBase = data;
        }

        [HttpGet(Name = "Obtener Lista de Categorias de Productos")]
        public IEnumerable<Category> getCategories()
        {
            return dataBase.categories.ToArray();
        }
    }
}
