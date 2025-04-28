using MongoDB.Driver;
using shared;

namespace backend.Repository
{
    public class PurchaseRepositoryMongoDB : IPurchaseRepository
    {
        private IMongoCollection<Advertisement> PurchaseCollection;

        public PurchaseRepositoryMongoDB()
        {
            var password = "ReaaaUse1234";
            var mongoUri = $"mongodb+srv://ReaaaUse:{password}@reaaause.icrherw.mongodb.net/?appName=ReaaaUse";

            try
            {
                var client = new MongoClient(mongoUri);
                var dbName = "Market"; // Din database
                var collectionName = "Items"; // Din collection

                PurchaseCollection = client.GetDatabase(dbName)
                    .GetCollection<Advertisement>(collectionName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to MongoDB: " + e.Message);
                throw;
            }
        }
        
        public async Task UpdatePurchaseRequestStatus(string adId, string purchaseId, string newStatus)
        {
            var filter = Builders<Advertisement>.Filter.Eq(a => a.Id, adId);
            var update = Builders<Advertisement>.Update
                .Set("PurchaseRequests.$[elem].Status", newStatus);

            var arrayFilters = new List<ArrayFilterDefinition>
            {
                new JsonArrayFilterDefinition<shared.Purchase>("{ 'elem.PurchaseId': ObjectId('" + purchaseId + "') }")
            };

            var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

            await PurchaseCollection.UpdateOneAsync(filter, update, updateOptions);
        }
        
        public async Task AddPurchase(string adId, Purchase newPurchase)
        {
            var filter = Builders<Advertisement>.Filter.Eq(a => a.Id, adId);

            var ad = await PurchaseCollection.Find(filter).FirstOrDefaultAsync();

            if (ad == null)
                return;

            // Tjek om der allerede findes et bud fra samme bruger
            var existingBid = ad.PurchaseRequests?.FirstOrDefault(p => p.Buyer.Email == newPurchase.Buyer.Email);

            if (existingBid != null)
            {
                // Brugeren har allerede budt - vi opdaterer det eksisterende bud
                var update = Builders<Advertisement>.Update
                    .Set("PurchaseRequests.$[elem].Bid", newPurchase.Bid)
                    .Set("PurchaseRequests.$[elem].Status", "pending");

                var arrayFilters = new List<ArrayFilterDefinition>
                {
                    new JsonArrayFilterDefinition<Purchase>("{ 'elem.Buyer.Email': '" + newPurchase.Buyer.Email + "' }")
                };

                var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

                await PurchaseCollection.UpdateOneAsync(filter, update, updateOptions);
            }
            else
            {
                // Ingen bud endnu - tilføj nyt
                var pushUpdate = Builders<Advertisement>.Update.Push(a => a.PurchaseRequests, newPurchase);
                await PurchaseCollection.UpdateOneAsync(filter, pushUpdate);
            }
        }
        

        public async Task<List<PurchaseWithAd>> GetPurchasesByUserEmail(string userEmail)
        {
            var filter = Builders<Advertisement>.Filter.ElemMatch(
                ad => ad.PurchaseRequests,
                purchase => (purchase.Buyer.Email == userEmail) &&
                            (purchase.Status == "accepted" || purchase.Status == "pending" || purchase.Status == "declined")
            );

            var ads = await PurchaseCollection.Find(filter).ToListAsync();

            var result = new List<PurchaseWithAd>();

            foreach (var ad in ads)
            {
                foreach (var purchase in ad.PurchaseRequests)
                {
                    if (purchase.Buyer.Email == userEmail &&
                        (purchase.Status == "accepted" || purchase.Status == "pending" || purchase.Status == "declined"))
                    {
                        result.Add(new PurchaseWithAd
                        {
                            Advertisement = ad,
                            Purchase = purchase
                        });
                    }
                }
            }

            return result;
        }
    }
}
