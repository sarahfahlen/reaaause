using MongoDB.Bson;
using reaause.Services.Advertisment;
using shared;
using static reaause.Services.Login.LoginServiceClientSite;
using static reaause.Services.Advertisment.AdvertisementServiceMock;

public class PurchaseServiceMock : IPurchaseService
{
    public Task<List<PurchaseWithAd>> GetMyPurchase(string loggedInUserId)
    {
        var adService = new AdvertisementServiceMock(); // Initiating the mock so we can access it
        var allAds = adService.GetAllAdvertisements().Result;

        var result = new List<PurchaseWithAd>(); // <-- VIGTIG ÆNDRING HER!

        foreach (var ad in allAds)
        {
            foreach (var purchase in ad.PurchaseRequests)
            {
                if (purchase.Buyer.UserId == loggedInUserId &&
                    (purchase.Status == "accepted" || purchase.Status == "pending"))
                {
                    result.Add(new PurchaseWithAd
                    {
                        Advertisement = ad,
                        Purchase = purchase
                    });
                }
            }
        }

        return Task.FromResult(result);
    }
    
    public async Task AddPurchase(string adId, Purchase purchase)
    {
        var adService = new AdvertisementServiceMock(); // Initiere mock adService
        var allAds = await adService.GetAllAdvertisements(); // Hent alle annoncer

        var ad = allAds.FirstOrDefault(a => a.Id == adId);
        if (ad != null)
        {
            if (ad.PurchaseRequests == null)
            {
                ad.PurchaseRequests = new List<Purchase>();
            }

            ad.PurchaseRequests.Add(purchase);

            // Opdater status til reserved
            await adService.UpdateAdStatus(adId, "reserved");
        }
    }
}