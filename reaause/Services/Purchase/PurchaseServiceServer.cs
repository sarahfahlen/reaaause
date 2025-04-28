using System.Net.Http.Json;
using MongoDB.Driver;
using shared;

namespace reaause.Services.Purchase
{
    public class PurchaseServiceServer : IPurchaseService
    {
        private readonly HttpClient client;
        private readonly string serverUrl = "http://localhost:5097";

        public PurchaseServiceServer(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<PurchaseWithAd>> GetMyPurchase(string loggedInUserEmail)
        {
            var result = await client.GetFromJsonAsync<List<PurchaseWithAd>>(
                $"{serverUrl}/api/purchases/my/{loggedInUserEmail}"
            );
            return result ?? new List<PurchaseWithAd>();
        }

        public async Task AddPurchase(string adId, shared.Purchase purchase)
        {
            await client.PostAsJsonAsync($"api/purchases/add/{adId}", purchase);

        }
        
        public async Task UpdatePurchaseRequestStatus(string adId, string purchaseId, string newStatus)
        {
            var content = new StringContent($"\"{newStatus}\"", System.Text.Encoding.UTF8, "application/json");
            await client.PutAsync($"api/purchases/status/{adId}/{purchaseId}", content);
        }


    } 
}