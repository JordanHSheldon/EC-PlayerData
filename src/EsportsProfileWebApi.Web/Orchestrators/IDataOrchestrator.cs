namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.Web.Orchestrators.Models;

public interface IDataOrchestrator
{
    Task<GetDataResponseModel> GetData(GetDataRequestModel dataRequest);

    Task<GetDataResponseModel> GetProfileData(GetProfileRequestModel dataRequest);

    Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request);

    Task<List<GetPaginatedUsersResponseModel>> GetPaginatedUsersAsync(GetPaginatedUsersRequestModel req);
}