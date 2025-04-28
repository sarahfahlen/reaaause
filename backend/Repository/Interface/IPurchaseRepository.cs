using shared;

namespace backend.Repository
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseWithAd>> GetPurchasesByUserEmail(string userEmail);
        Task UpdatePurchaseStatus(string purchaseId, string newStatus);
        Task AddPurchase(string adId, Purchase purchase);
    }
}