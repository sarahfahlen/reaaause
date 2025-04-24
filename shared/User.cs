using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace shared;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Staff { get; set; }
    public string Password { get; set; }

    public List<Advertisement>? Advertisements { get; set; } = new();
}
