using reaause.Services.Login;
using shared;
using static reaause.Services.Login.LoginServiceClientSite;
namespace reaause.Services.Advertisment;

public class AdvertisementServiceMock : IAdvertisementService
{
    public static Advertisement test1 = new Advertisement
    {
        Name = "Nice lamp", Category = "Furniture", Price = 250, AtSchool = false, Status = "active", Seller = new Seller{
            UserId = rip.Id,
            Name = rip.Name,
            Email = rip.Email
        }
    };

    public static Advertisement test2 = new Advertisement
    {
        Name = "Long skirt", Category = "Clothes", Price = 100, AtSchool = false, Status = "active", Seller = new Seller{
            UserId = rap.Id,
            Name = rap.Name,
            Email = rap.Email
        }
    };
    
    //we create a mock list including the mock items from above
    public List<Advertisement> allAds = new List<Advertisement>{test1, test2};

    //Filtering by active status, making sure we only show ads that are active
    public async Task<List<Advertisement>> GetAllActiveAds()
    {
        return allAds.Where(x => x.Status == "active").ToList();
    }
    
    public Task<User[]> GetAllUsers()
    {
        var users = new List<User> { LoginServiceClientSite.rip, LoginServiceClientSite.rap, LoginServiceClientSite.rup };
        return Task.FromResult(users.ToArray());
    }
}