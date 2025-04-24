using shared;
namespace reaause;

public interface ILoginService
{
    Task<User> GetUserLoggedIn();
    
    Task<bool> Login(string Email, string password);
    
    Task<User[]> GetAll();
}