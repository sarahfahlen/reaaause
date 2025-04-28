using backend.Repository;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ILoginRepository.LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return BadRequest("Missing email or password");

            var user = await loginRepo.Validate(loginRequest.Email, loginRequest.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(user);
        }
        [HttpGet("staff")]
        public ActionResult<IEnumerable<User>> GetAllStaff()
        {
            var users = loginRepo.GetAllUsers().Where(u => u.Staff == true).ToArray();
            return Ok(users);
        }


    }
}