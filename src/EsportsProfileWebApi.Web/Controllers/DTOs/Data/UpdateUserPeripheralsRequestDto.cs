namespace EsportsProfileWebApi.Web.Controllers.DTOs.Data;

public class UpdateUserPeripheralsRequestDto
{
    public IEnumerable<int> PeripheralIds { get; set; }
}