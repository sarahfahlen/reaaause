using backend.Repository;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepositoryMongoDB loginRepo;

        public LoginController(LoginRepositoryMongoDB loginRepo)
        {
            this.loginRepo = loginRepo;
        }

        [HttpGet]
        public User[] GetAllUsers()
        {
            return loginRepo.GetAllUsers();
        }

        [HttpPost("login")]
        public ActionResult<User?> Login([FromBody] dynamic body)
        {
            string email = body.Email;
            string password = body.Password;

            var users = loginRepo.GetAllUsers();

            var user = users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user == null)
                return Unauthorized();

            user.Password = "validated";
            return Ok(user);
        }
    }
}