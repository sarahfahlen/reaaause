using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shared
{
    public class Purchase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string PurchaseId { get; set; } = ObjectId.GenerateNewId().ToString();

        public double Bid { get; set; }
        public string Status { get; set; }

        public Buyer Buyer { get; set; }
    }
    
    public class PurchaseWithAd
    {
        public Advertisement Advertisement { get; set; }
        public Purchase Purchase { get; set; }
    }
}