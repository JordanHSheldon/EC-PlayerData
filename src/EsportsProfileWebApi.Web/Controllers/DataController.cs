namespace EsportsProfileWebApi.Web.Controllers;

using AutoMapper;
using DTOs.Data;
using Orchestrators;
using Orchestrators.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DataController(IDataOrchestrator dataOrchestrator, IMapper mapper) : Controller
{
    private readonly IDataOrchestrator _dataOrchestrator = dataOrchestrator ?? throw new NotImplementedException();
    private readonly IMapper _mapper = mapper ?? throw new NotImplementedException();

    [HttpPost]
    [Route("GetPaginatedUserData")]
    public async Task<List<GetPaginatedUsersResponseDto>> GetPaginatedUsersAsync(GetPaginatedUsersRequestDTO req)
    {
        var request = _mapper.Map<GetPaginatedUsersRequestModel>(req);
        var result = await _dataOrchestrator.GetPaginatedUsersAsync(request);
        return _mapper.Map<List<GetPaginatedUsersResponseDto>>(result);
    }

    [Authorize]
    [HttpPost]
    [Route("GetUserProfile")]
    public async Task<GetDataResponseDTO> GetProfileData()
    {
        var request = new GetProfileRequestModel();
        var id = HttpContext?.User?.Claims?.First(c => c.Type == "Id")?.Value;
        request.Id = id;
        var result = await _dataOrchestrator.GetProfileData(request);
        return _mapper.Map<GetDataResponseDTO>(result);
    }

    [HttpPost]
    [Route("GetDataByUserName")]
    public async Task<GetDataResponseDTO> GetDataByUserName(GetDataRequestDTO getDataRequestDto)
    {
        var request = _mapper.Map<GetDataRequestModel>(getDataRequestDto);
        var result = await _dataOrchestrator.GetData(request);
        return _mapper.Map<GetDataResponseDTO>(result);
    }

    [Authorize]
    [HttpPost]
    [Route("UpdateUserPeripherals")]
    public async Task<UpdateDataResponseDTO> UpdateData(UpdateUserPeripheralsRequestDto request)
    {
        var req = mapper.Map<UpdateUserPeripheralsRequest>(request);
        var id = HttpContext?.User?.Claims?.First(c => c.Type == "Id")?.Value;
        int userId = int.Parse(id);
        req.UserId = userId;
        var result = await _dataOrchestrator.UpdateUserPeripherals(req);
        return _mapper.Map<UpdateDataResponseDTO>(result);
    }

    [HttpPost]
    [Route("GetPeripherals")]
    public async Task<List<PeripheralDto>> GetPeripherals()
    {
        var result = await _dataOrchestrator.GetPeripheralsAsync();
        return _mapper.Map<List<PeripheralDto>>(result);
    }
}