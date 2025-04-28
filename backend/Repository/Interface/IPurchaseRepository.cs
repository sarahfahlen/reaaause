using shared;

namespace backend.Repository
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseWithAd>> GetPurchasesByUserEmail(string userEmail);

    }
}