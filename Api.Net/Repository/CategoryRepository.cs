using Api.Net.Database;
using Api.Net.Interfaces;
using Api.Net.Models;

namespace Api.Net.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBase dataBase;

        public CategoryRepository(DataBase data)
        {
            dataBase = data;
        }

        public IEnumerable<Category> getCategories()
        {
            return dataBase.categories.ToArray();
        }

    }
}
