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
    [Route("GetAllData")]
    public async Task<List<GetDataResponseDTO>> GetAllDataAsync()
    {
        var result = await _dataOrchestrator.GetAllDataAsync();
        return _mapper.Map<List<GetDataResponseDTO>>(result);
    }

    [Authorize]
    [HttpPost]
    [Route("GetData")]
    public async Task<GetDataResponseDTO> GetData(GetDataRequestDTO getDataRequestDto)
    {
        var request = _mapper.Map<GetDataRequestModel>(getDataRequestDto);
        var result = await _dataOrchestrator.GetData(request);
        return _mapper.Map<GetDataResponseDTO>(result);
    }

    [Authorize]
    [HttpPost]
    [Route("UpdateData")]
    public async Task<UpdateDataResponseDTO> UpdateData(UpdateDataRequestDTO updateDataRequestDto)
    {
        var request = _mapper.Map<UpdateDataRequestModel>(updateDataRequestDto);
        var username = HttpContext?.User?.Claims?.First(c => c.Type == "UserName")?.Value;
        request.Username = username;
        var result = await _dataOrchestrator.UpdateData(request);
        return _mapper.Map<UpdateDataResponseDTO>(result);
    }
}