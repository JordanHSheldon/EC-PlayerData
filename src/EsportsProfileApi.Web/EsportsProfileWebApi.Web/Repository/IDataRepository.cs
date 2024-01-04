namespace EsportsProfileWebApi.INFRASTRUCTURE;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using System.Collections.Generic;

public interface IDataRepository
{
    Task<GetDataResponse> GetUserDataByAlias(GetDataRequest dataRequest);

    Task<bool> UpdateDataByAlias(UpdateDataRequest request);

    Task<List<GetDataResponse>> GetAllDataAsync();
}