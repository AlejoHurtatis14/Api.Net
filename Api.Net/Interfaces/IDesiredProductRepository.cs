using Api.Net.Controllers;
using Api.Net.Models;

namespace Api.Net.Interfaces
{
    public interface IDesiredProductRepository
    {
        IEnumerable<DesiredProduct> listProducts();

        Task<DesiredProduct> postDesiredProduct(PostDesiredProd postDesiredProd);

        Task<Boolean> deleteDesiredProduct(int id);

        Task<DesiredProduct> getDesiredProductUser(int id);

    }
}
