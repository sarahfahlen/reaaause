using shared;

public interface IPurchaseService
{
    Task<List<(Advertisement, Purchase)>> GetMyPurchase(string loggedInUserId);

    Task AddPurchase(string adId, Purchase purchase);

    Task UpdatePurchaseStatus(string purchaseID, string newStatus);
}