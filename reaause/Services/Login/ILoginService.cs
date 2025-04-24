using shared;
namespace reaause;

public interface ILoginService
{
    Task<User> GetUserLoggedIn();
    
    Task<bool> Login(string brugernavn, string password);
    
    Task<User[]> GetAll();
}