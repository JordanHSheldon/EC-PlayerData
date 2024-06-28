namespace EsportsProfileWebApi.Web.Orchestrators.Models.Data;

public class GetPaginatedUsersRequestModel 
{
    public int Offset { get; set; }

    public int Limit { get; set; }

    public string Search { get; set; } = string.Empty;
}