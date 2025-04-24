using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace shared;

public class Seller
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
}
