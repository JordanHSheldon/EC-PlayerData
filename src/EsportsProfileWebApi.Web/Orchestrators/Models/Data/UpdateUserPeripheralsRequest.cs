namespace EsportsProfileWebApi.Web.Orchestrators.Models.Data;

public record UpdateUserPeripheralsRequest
{
    public int UserId { get; set; }

    public IEnumerable<int> PeripheralIds { get; set; } = [];
    
}