using MongoDB.Driver;
using shared;

namespace backend.Repository
{
    public class FacilityRepositoryMongoDB : IFacilityRepository
    {
        private readonly IMongoCollection<Facility> facilityCollection;

        public FacilityRepositoryMongoDB()
        {
            var password = "ReaaaUse1234";
            var mongoUri = $"mongodb+srv://ReaaaUse:{password}@reaaause.icrherw.mongodb.net/?appName=ReaaaUse";
            var client = new MongoClient(mongoUri);

            var dbName = "Market";
            var collectionName = "Facilities"; 

            facilityCollection = client.GetDatabase(dbName)
                .GetCollection<Facility>(collectionName);
        }

        public async Task<List<Facility>> GetAllFacilities()
        {
            return await facilityCollection.Find(Builders<Facility>.Filter.Empty).ToListAsync();
        }

        public async Task AddFacility(Facility facility)
        {
            await facilityCollection.InsertOneAsync(facility);
        }
    }
}