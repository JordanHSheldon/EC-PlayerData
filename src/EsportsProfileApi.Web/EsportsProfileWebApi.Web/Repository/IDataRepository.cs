namespace EsportsProfileWebApi.INFRASTRUCTURE;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.Web.Controllers;
using System.Collections.Generic;

public interface IDataRepository
{
    public GetDataResponse GetData(GetDataRequest dataRequest);

    public IEnumerable<GetDataResponse> GetAllData();

    bool UpdateData(UpdateDataRequest request);

    Task<List<users>> GetAllUsersAsync();
}