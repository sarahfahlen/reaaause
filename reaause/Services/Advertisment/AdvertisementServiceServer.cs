using shared;
using System.Net.Http.Json;

namespace reaause.Services.Advertisment
{
    public class AdvertisementServiceServer : IAdvertisementService
    {
        private readonly HttpClient httpClient;

        public AdvertisementServiceServer(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Advertisement>> GetAllAdvertisements()
        {
            return await httpClient.GetFromJsonAsync<List<Advertisement>>("api/advertisements");
        }

        public async Task<List<Advertisement>> GetAllActiveAds()
        {
            return await httpClient.GetFromJsonAsync<List<Advertisement>>("api/advertisements/active");
        }

        public async Task<List<Advertisement>> GetMyAds(string email)
        {
            return await httpClient.GetFromJsonAsync<List<Advertisement>>($"api/advertisements/myads/{email}");
        }

        public Task AddAd(Advertisement ad)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAdStatus(string adId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}