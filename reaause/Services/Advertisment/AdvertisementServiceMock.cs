using reaause.Services.Login;
using MongoDB.Bson;
using shared;
using static reaause.Services.Login.LoginServiceClientSite;

namespace reaause.Services.Advertisment;

public class AdvertisementServiceMock : IAdvertisementService
{
    public static Advertisement test1 = new Advertisement
    {
        Name = "Nice lamp",
        Category = "Furniture",
        Price = 250,
        AtSchool = false,
        Status = "active",
        Seller = new Seller
        {
            UserId = rip.Id,
            Name = rip.Name,
            Email = rip.Email
        },
        PurchaseRequests = new List<Purchase>
        {
            new Purchase
            {
                PurchaseId = ObjectId.GenerateNewId().ToString(),
                Bid = 200,
                Status = "pending",
                Buyer = new Buyer
                {
                    UserId = rup.Id,
                    Name = rup.Name,
                    Email = rup.Email
                }
            },
            new Purchase
            {
                PurchaseId = ObjectId.GenerateNewId().ToString(),
                Bid = 230,
                Status = "accepted",
                Buyer = new Buyer
                {
                    UserId = rap.Id,
                    Name = rap.Name,
                    Email = rap.Email
                }
            }
        }
    };

    public static Advertisement test2 = new Advertisement
    {
        Name = "Long skirt",
        Category = "Clothes",
        Price = 100,
        AtSchool = false,
        Status = "active",
        Seller = new Seller
        {
            UserId = rap.Id,
            Name = rap.Name,
            Email = rap.Email
        },
        PurchaseRequests = new List<Purchase>{
        new Purchase
        {
            PurchaseId = ObjectId.GenerateNewId().ToString(),
            Bid = 100,
            Status = "accepted",
            Buyer = new Buyer
            {
                UserId = rip.Id,
                Name = rip.Name,
                Email = rip.Email
            }
        }
        }
    };

    // Mock-liste med annoncer
    public List<Advertisement> allAds = new List<Advertisement> { test1, test2 };

    public async Task<List<Advertisement>> GetAllActiveAds()
    {
        return allAds.Where(x => x.Status == "active").ToList();
    }

    public Task<User[]> GetAllUsers()
    {
        var users = new List<User> { rip, rap, rup };
        return Task.FromResult(users.ToArray());
    }
}
