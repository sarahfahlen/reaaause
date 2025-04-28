using shared;

namespace backend.Repository
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseWithAd>> GetPurchasesByUserEmail(string userEmail);
        Task AddPurchase(string adId, Purchase purchase);
        Task UpdatePurchaseRequestStatus(string adId, string purchaseId, string newStatus);
    }
}