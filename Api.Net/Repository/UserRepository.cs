using Api.Net.Database;
using Api.Net.Interfaces;
using Api.Net.Models;

namespace Api.Net.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBase dataBase;

        public UserRepository(DataBase data)
        {
            dataBase = data;
        }

        public IEnumerable<User> getusers()
        {
            return dataBase.users.ToArray();
        }

    }
}
