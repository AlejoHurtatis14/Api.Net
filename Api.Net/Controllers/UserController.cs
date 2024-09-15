using Api.Net.Interfaces;
using Api.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet(Name = "Obtener Lista de usuarios")]
        public IEnumerable<User> getusers()
        {
            return userRepository.getusers();
        }
    }
}
