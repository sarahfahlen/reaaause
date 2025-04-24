using Microsoft.AspNetCore.Mvc;
using backend.Repository;
using shared;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepo;

        public LoginController(ILoginRepository loginRepo)
        {
            this.loginRepo = loginRepo;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return loginRepo.GetAllUsers();
        }
    }
}
