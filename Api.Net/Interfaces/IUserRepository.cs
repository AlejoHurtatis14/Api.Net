using Api.Net.Models;

namespace Api.Net.Interfaces
{
    public interface IUserRepository
    {

        IEnumerable<User> getusers();

    }
}
