using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections;
using System.Security.Claims;

namespace EsportsProfileWebApi.Web.Repository.Entities.User;

public class UserEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("UserId")]
    public string? UserId { get; set; }

    [BsonElement("UserName")]
    public string? UserName { get; set; }

    [BsonElement("Email")]
    public string? Email { get; set; }

    [BsonElement("Password")]
    public string? Password { get; set; }

    [BsonElement("Claims")]
    public IEnumerable<Claim>? Claims { get; set; }
}
