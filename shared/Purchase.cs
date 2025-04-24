using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace shared;

public class Purchase
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string FacilityId { get; set; } = ObjectId.GenerateNewId().ToString();

    public string Name { get; set; }
    public string OpeningHours { get; set; }

    public User StaffMember { get; set; }
}