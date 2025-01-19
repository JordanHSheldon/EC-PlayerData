namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Orchestrators.Models.Data;

public interface IDataOrchestrator
{
    Task<GetDataResponseModel> GetData(GetDataRequestModel dataRequest);

    Task<GetDataResponseModel> GetProfileData(GetProfileRequestModel dataRequest);

    Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request);

    Task<List<GetPaginatedUsersResponseModel>> GetPaginatedUsersAsync(GetPaginatedUsersRequestModel req);

    Task<List<PeripheralModel>> GetPeripheralsAsync();
    
    Task<UpdateDataResponseModel> UpdateUserPeripherals(UpdateUserPeripheralsRequest request);
    
}