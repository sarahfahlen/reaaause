using System.Net.Http.Json;
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

        public Task AddPurchase(string adId, shared.Purchase purchase)
        {
            throw new NotImplementedException();
        }
    } 
}