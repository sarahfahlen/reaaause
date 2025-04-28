using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace shared; 

public class Advertisement
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    public string Name { get; set; }
    public string Category { get; set; }
    public string? Color { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public string? Picture { get; set; }
    public string? Condition { get; set; }
    public bool AtSchool { get; set; }
    public string Status { get; set; }
    
    public Seller Seller { get; set; }

    public Facility? Location { get; set; }
    public List<Purchase>? PurchaseRequests { get; set; } = new();
}