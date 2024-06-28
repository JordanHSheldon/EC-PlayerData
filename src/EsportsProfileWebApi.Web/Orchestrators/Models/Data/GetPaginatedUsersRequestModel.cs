namespace EsportsProfileWebApi.Web.Orchestrators.Models;

public class GetPaginatedUsersRequestModel 
{
    public int Offset { get; set; } = 0;

    public int Limit { get; set; } = 20;

    public string Search { get; set; } = string.Empty;
}