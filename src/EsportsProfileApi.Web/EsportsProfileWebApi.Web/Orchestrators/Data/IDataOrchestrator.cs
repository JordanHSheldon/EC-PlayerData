namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Settings
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;

    public interface IDataOrchestrator
    {
        GetDataResponse GetData(GetDataRequest dataRequest);

        IEnumerable<GetDataResponse> GetAllData(GetDataRequest dataRequest);

        bool UpdateData(UpdateDataRequest peripheralsRequest);
    }
}