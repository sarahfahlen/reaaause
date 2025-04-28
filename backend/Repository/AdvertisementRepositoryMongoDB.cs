using MongoDB.Driver;
using MongoDB.Bson;
using shared;

namespace backend.Repository
{
    public class AdvertisementRepositoryMongoDB : IAdvertisementRepository
    {
        private IMongoClient client;
        private readonly IMongoCollection<Advertisement> adCollection;

        public AdvertisementRepositoryMongoDB()
        {
            // atlas database
            var password = "ReaaaUse1234";
            var mongoUri = $"mongodb+srv://ReaaaUse:{password}@reaaause.icrherw.mongodb.net/?appName=ReaaaUse";

            //local mongodb
            //var mongoUri = "mongodb://localhost:27017/";

            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                                  "Atlas cluster. Check that the URI includes a valid " +
                                  "username and password, and that your IP address is " +
                                  $"in the Access List. Message: {e.Message}");
                throw;
            }

            // Provide the name of the database and collection you want to use.
            var dbName = "Market";
            var collectionName = "Items";

            adCollection = client.GetDatabase(dbName)
                .GetCollection<Advertisement>(collectionName);
            
        }

        public async Task<List<Advertisement>> GetAllAdvertisements()
        {
            var noFilter = Builders<Advertisement>.Filter.Empty;
            return await adCollection.Find(noFilter).ToListAsync();
        }

        public async Task<List<Advertisement>> GetAllActiveAdvertisements()
        {
            var filter = Builders<Advertisement>.Filter.Eq(a => a.Status, "active");
            return await adCollection.Find(filter).ToListAsync();
        }
        
        public async Task<List<Advertisement>> GetMyAdvertisements(string email)
        {
            var filter = Builders<Advertisement>.Filter.Eq("Seller.Email", email);
            var result = await adCollection.Find(filter).ToListAsync();
            Console.WriteLine($"[DEBUG] Fandt {result.Count} annoncer for email {email}");
            return result;
        }

        public async Task AddAdvertisement(Advertisement ad)
        {
            await adCollection.InsertOneAsync(ad);
        }

        public async Task UpdateAdStatus(string adId, string newStatus)
        {
            var filter = Builders<Advertisement>.Filter.Eq(a => a.Id, adId);
            var update = Builders<Advertisement>.Update.Set(a => a.Status, newStatus);
            await adCollection.UpdateOneAsync(filter, update);
        }

    }
}