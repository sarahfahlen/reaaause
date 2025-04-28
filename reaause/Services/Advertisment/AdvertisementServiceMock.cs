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
        Picture = "https://scontent-cph2-1.xx.fbcdn.net/v/t45.5328-4/489611863_695112269689754_4653232189420530797_n.jpg?stp=dst-jpg_s960x960_tt6&_nc_cat=101&ccb=1-7&_nc_sid=247b10&_nc_ohc=ytIS28JHSvcQ7kNvwH0kiXe&_nc_oc=AdlN-QVzADdXivX7H59PMzgrkpk7gyZFz3YM7lbUGADntQgQoP_b59cprRsyQ8QBfnE&_nc_zt=23&_nc_ht=scontent-cph2-1.xx&_nc_gid=4VGNsjY0Zk3WV_OUM8wlHQ&oh=00_AfFyY7HuNFF6njqx2q7DnGrPTqSTI9hmVNSp7C6jFfCkOA&oe=6813DA87",
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

    public async Task<List<Advertisement>> GetAllAdvertisements()
    {
        return allAds.ToList();
    }
    
    public async Task<List<Advertisement>> GetAllActiveAds()
    {
        return allAds.Where(x => x.Status == "active").ToList();
    }

    public Task<User[]> GetAllUsers()
    {
        var users = new List<User> { rip, rap, rup };
        return Task.FromResult(users.ToArray());
    }
    
    //Method to find myAds based on the user who is logged in
    public Task<List<Advertisement>> GetMyAds(string userId)
    {
        var myAds = allAds.Where(ad => ad.Seller.UserId == userId).ToList();
        return Task.FromResult(myAds);
    }
    
    public async Task AddAd(Advertisement ad)
    {
        allAds.Add(ad);
    }

}
