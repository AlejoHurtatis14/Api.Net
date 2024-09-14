using Api.Net.Database;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly DataBase dataBase;

        public UserController(DataBase data)
        {
            dataBase = data;
        }

        [HttpGet(Name = "Obtener Lista de usuarios")]
        public IEnumerable<User> getusers()
        {
            return dataBase.users.ToArray();
        }
    }
}
