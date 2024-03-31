namespace EsportsProfileWebApi.Web.Orchestrators;

using AutoMapper;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Orchestrators.Models;

public class DataOrchestrator(IDataRepository dataRepository, IMapper mapper) : IDataOrchestrator
{
    private readonly IDataRepository _dataRepository = dataRepository ?? throw new NotImplementedException();
    private readonly IMapper _mapper = mapper ?? throw new NotImplementedException();

    public async Task<string> CreateCSData(string username)
    {
        return await _dataRepository.CreateCSData(username);
    }

    // make seperate endpoint for just getting data for searched users
    // make this endpoint use claims to get the id.
    public async Task<GetDataResponseModel> GetDataById(GetDataRequestModel dataRequest)
    {
        var result = await _dataRepository.GetUserDataById(dataRequest);
        return _mapper.Map<GetDataResponseModel>(result);
    }

    public async Task<UpdateDataRequestModel> UpdateDataById(UpdateDataRequestModel request)
    {
        var result = await _dataRepository.UpdateDataById(request);
        return _mapper.Map<UpdateDataRequestModel>(result);
    }

    public async Task<List<GetDataResponseModel>> GetAllDataAsync()
    {
        var result = await _dataRepository.GetAllDataAsync();
        return _mapper.Map<List<GetDataResponseModel>>(result);
    }
}
