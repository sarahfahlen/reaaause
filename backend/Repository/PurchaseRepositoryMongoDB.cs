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
