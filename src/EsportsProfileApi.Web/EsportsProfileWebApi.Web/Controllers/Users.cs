namespace EsportsProfileWebApi.Web.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class users
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("username")]
    public string Username { get; set; }

    [BsonElement("password")]
    public string password { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("fname")]
    public string fname { get; set; }

    [BsonElement("lname")]
    public string lname { get; set; }

    [BsonElement("__v")]
    public int __v { get; set; }
}
