using shared;
namespace reaause.Services.Advertisment;

public interface IAdvertisementService
{
    Task<List<Advertisement>> GetAllActiveAds();
    
    Task<User[]> GetAllUsers();
}