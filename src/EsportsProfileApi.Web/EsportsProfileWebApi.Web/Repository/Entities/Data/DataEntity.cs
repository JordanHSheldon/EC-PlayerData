using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EsportsProfileWebApi.Web.Repository.Entities.Data;

public class DataEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("UserId")]
    public string? UserId { get; set; }

    [BsonElement("sensitivity")]
    public double Sensitivity { get; set; }

    [BsonElement("dpi")]
    public int Dpi { get; set; }

    [BsonElement("resolutionx")]
    public int ResolutionX { get; set; }

    [BsonElement("resolutiony")]
    public int ResolutionY { get; set; }

    [BsonElement("resolutiontype")]
    public string? ResolutionType { get; set; }

    [BsonElement("mouse")]
    public string? Mouse { get; set; }

    [BsonElement("mousepad")]
    public string? MousePad { get; set; }

    [BsonElement("keyboard")]
    public string? KeyBoard { get; set; }

    [BsonElement("headset")]
    public string? HeadSet { get; set; }

    [BsonElement("monitor")]
    public string? Monitor { get; set; }
}
