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

        public async Task AddAd(Advertisement ad)
        {
            await httpClient.PostAsJsonAsync("api/advertisements", ad);
        }

        public async Task UpdateAdStatus(string adId, string newStatus)
        {
            var content = new StringContent($"\"{newStatus}\"", System.Text.Encoding.UTF8, "application/json");
            await httpClient.PutAsync($"api/advertisements/status/{adId}", content);
        }

        public Task UpdateAd(Advertisement ad)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(string id)
        {
            await httpClient.DeleteAsync($"/api/advertisements/{id}");
        }


    }
}