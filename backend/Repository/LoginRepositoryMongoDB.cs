using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using shared;

namespace backend.Repository
{
    public class LoginRepositoryMongoDB : ILoginRepository
    {
        private IMongoClient client;
        private IMongoCollection<User> Usercollection;
     

        public LoginRepositoryMongoDB()
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
            var dbName = "Login";
            var collectionName = "Users";

            Usercollection = client.GetDatabase(dbName)
                .GetCollection<User>(collectionName);
            
        }

     
        public User[] GetAllUsers()
        {
            var nofilter = Builders<User>.Filter.Empty;
            return Usercollection.Find(nofilter).ToList().ToArray();
        }
    }
}