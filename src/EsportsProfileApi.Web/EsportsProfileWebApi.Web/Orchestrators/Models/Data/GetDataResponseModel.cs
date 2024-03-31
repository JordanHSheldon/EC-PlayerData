using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EsportsProfileWebApi.Web.Orchestrators.Models;

public class GetDataResponseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("username")]
    public string Username { get; set; } = string.Empty;

    [BsonElement("sensitivity")]
    public double Sensitivity { get; set; } = 2.5;

    [BsonElement("dpi")]
    public int Dpi { get; set; } = 400;

    [BsonElement("resolutionx")]
    public int ResolutionX { get; set; } = 1920;

    [BsonElement("resolutiony")]
    public int ResolutionY { get; set; } = 1080;

    [BsonElement("resolutiontype")]
    public string ResolutionType { get; set; } = "Native";

    [BsonElement("mouse")]
    public string? Mouse { get; set; } = string.Empty;

    [BsonElement("mousepad")]
    public string? MousePad { get; set; } = string.Empty;

    [BsonElement("keyboard")]
    public string? KeyBoard { get; set; } = string.Empty;

    [BsonElement("headset")]
    public string? HeadSet { get; set; } = string.Empty;

    [BsonElement("monitor")]
    public string? Monitor { get; set; } = string.Empty;
}