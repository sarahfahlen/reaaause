using shared;

namespace backend.Repository;

public interface ILoginRepository
{
    User[] GetAllUsers();
    Task<User?> Validate(string email, string password);
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}