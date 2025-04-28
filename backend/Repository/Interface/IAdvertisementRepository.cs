using shared;

namespace backend.Repository
{
    public interface IAdvertisementRepository
    {
        Task<List<Advertisement>> GetAllAdvertisements();
        Task<List<Advertisement>> GetAllActiveAdvertisements();
        Task<List<Advertisement>> GetMyAdvertisements(string userId);
        Task AddAdvertisement(Advertisement ad);
        Task UpdateAdStatus(string adId, string newStatus);
        void Remove(string id);
    }
}