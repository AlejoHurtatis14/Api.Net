using Api.Net.Models;

namespace Api.Net.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> getCategories();

    }
}
