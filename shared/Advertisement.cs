using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
namespace shared; 

public class Advertisement
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [Required(ErrorMessage = "Name is prohibited")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Category is prohibited")]
    public string Category { get; set; }
    [Required(ErrorMessage = "Color is prohibited")]
    public string? Color { get; set; }
    [Required(ErrorMessage = "Price is prohibited")]
    public double Price { get; set; }
    public string? Description { get; set; }
    public string? Picture { get; set; }
    [Required(ErrorMessage = "Condition is prohibited")]
    public string? Condition { get; set; }
    public bool AtSchool { get; set; }
    public string Status { get; set; }
    
    public Seller Seller { get; set; }

    public Facility? Location { get; set; }
    public List<Purchase>? PurchaseRequests { get; set; } = new();
}
