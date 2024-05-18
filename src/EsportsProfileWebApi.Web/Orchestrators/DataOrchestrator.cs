﻿namespace EsportsProfileWebApi.Web.Orchestrators;

using AutoMapper;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Orchestrators.Models;

public class DataOrchestrator(IDataRepository dataRepository, IMapper mapper) : IDataOrchestrator
{
    private readonly IDataRepository _dataRepository = dataRepository ?? throw new NotImplementedException();
    private readonly IMapper _mapper = mapper ?? throw new NotImplementedException();

    public async Task<GetDataResponseModel> GetData(GetDataRequestModel dataRequest)
    {
        var result = await _dataRepository.GetUserData(dataRequest);
        return _mapper.Map<GetDataResponseModel>(result);
    }

    public async Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request)
    {
        var result = await _dataRepository.UpdateData(request);
        return _mapper.Map<UpdateDataResponseModel>(result);
    }

    public async Task<List<GetDataResponseModel>> GetAllDataAsync()
    {
        var result = await _dataRepository.GetAllDataAsync();
        return _mapper.Map<List<GetDataResponseModel>>(result);
    }
}
