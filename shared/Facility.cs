using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace shared;

public class Facility
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string FacilityId { get; set; } = ObjectId.GenerateNewId().ToString();

    public string Name { get; set; }
    public string OpeningHours { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? StaffUserId { get; set; }  // Nullable, hvis ikke altid sat
}