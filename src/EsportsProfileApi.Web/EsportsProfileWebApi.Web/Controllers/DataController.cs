namespace EsportsProfileWebApi.Web.Controllers;

using AutoMapper;
using EsportsProfileWebApi.Web.Controllers.DTOs.Data;
using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DataController(IDataOrchestrator dataOrchestrator, IMapper mapper) : Controller
{
    private readonly IDataOrchestrator _dataOrchestrator = dataOrchestrator ?? throw new NotImplementedException();
    private readonly IMapper _mapper = mapper ?? throw new NotImplementedException();

    [Authorize]
    [HttpPost]
    [Route("GetAllUserData")]
    public async Task<List<GetDataResponseDTO>> GetAllDataAsync()
    {
        var result = await _dataOrchestrator.GetAllDataAsync();
        return _mapper.Map<List<GetDataResponseDTO>>(result);
    }

    [Authorize]
    [HttpPost]
    [Route("GetDataById")]
    public async Task<GetDataResponseDTO> GetDataById(GetDataRequestDTO getDataRequestDto)
    {
        var request = _mapper.Map<GetDataRequestModel>(getDataRequestDto);
        var result = await _dataOrchestrator.GetDataById(request);
        return _mapper.Map<GetDataResponseDTO>(result);
    }

    [Authorize]
    [HttpPost]
    [Route("UpdateDataById")]
    public async Task<UpdateDataResponseDTO> UpdateDataById(UpdateDataRequestDTO updateDataRequestDto)
    {
        var request = _mapper.Map<UpdateDataRequestModel>(updateDataRequestDto);
        var result = await _dataOrchestrator.UpdateDataById(request);
        return _mapper.Map<UpdateDataResponseDTO>(result);
    }
}