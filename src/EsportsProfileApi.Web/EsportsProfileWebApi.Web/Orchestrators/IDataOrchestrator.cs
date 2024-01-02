namespace EsportsProfileWebApi.Web.Orchestrators
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using EsportsProfileWebApi.Web.Controllers;

    public interface IDataOrchestrator
    {
        GetDataResponse GetData(GetDataRequest dataRequest);

        IEnumerable<GetDataResponse> GetAllData();

        bool UpdateData(UpdateDataRequest peripheralsRequest);

        Task<List<users>> GetAllUsersAsync();
    }
}