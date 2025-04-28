using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shared
{
    public class Facility
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public OpeningHours OpeningHours { get; set; } = new();
        public string? StaffUserId { get; set; }
    }

    public class OpeningHours
    {
        public string Monday { get; set; } = "";
        public string Tuesday { get; set; } = "";
        public string Wednesday { get; set; } = "";
        public string Thursday { get; set; } = "";
        public string Friday { get; set; } = "";
        public string Saturday { get; set; } = "";
        public string Sunday { get; set; } = "";
    }
}