namespace reaause.Services.Login;

using Blazored.LocalStorage;
using shared;

public class LoginServiceClientSite : ILoginService
{
    private ILocalStorageService localStorage { get; set; }

    public LoginServiceClientSite(ILocalStorageService ls)
    {
        localStorage = ls;
    }

    public static User rip = new User
        { Id = "1", Name = "rip", Password = "1234", Email = "rip@rip.com", Phone = 76546789 };

    public static User rap = new User
        { Id = "2", Name = "rap", Password = "4321", Email = "rap@rap.com", Phone = 87907652 };

    public static User rup = new User
        { Id = "3", Name = "rup", Password = "qwerty", Email = "rup@rup.com", Phone = 64572358 };

    public async Task<User?> GetUserLoggedIn()
    {
        User? res = await localStorage.GetItemAsync<User>("user");
        return res;
    }
    
    public async Task<bool> Login(string Email, string Password)
    {
        User? u = await Validate(Email, Password);
        if (u != null)
        {
            u.Password = "validated";
            await localStorage.SetItemAsync("user", u);
            return true;
        }

        return false;
    } 

    public static List<User> users = new List<User> { rip, rap, rup };

    protected virtual async Task<User?> Validate(string username, string password)
    {
        foreach (User u in users)

            if (username.Equals(u.Email) && password.Equals(u.Password))
                return u;

        return null;
    }

    public async Task<User[]> GetAll()
    {
        return users.ToArray();
    }
}