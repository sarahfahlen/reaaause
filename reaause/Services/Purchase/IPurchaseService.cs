using shared;

public interface IPurchaseService
{
    Task<List<PurchaseWithAd>> GetMyPurchase(string loggedInUserEmail);


    Task AddPurchase(string adId, Purchase purchase);

    Task UpdatePurchaseStatus(string purchaseID, string newStatus);
}