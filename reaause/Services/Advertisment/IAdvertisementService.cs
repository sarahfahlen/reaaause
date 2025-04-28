using shared;
namespace reaause.Services.Advertisment;

public interface IAdvertisementService
{
    Task<List<Advertisement>> GetAllAdvertisements();
    Task<List<Advertisement>> GetAllActiveAds();
    Task<List<Advertisement>> GetMyAds(string loggedInUserId);
    Task AddAd(Advertisement ad);
    
}