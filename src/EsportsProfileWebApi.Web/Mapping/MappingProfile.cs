namespace EsportsProfileWebApi.Web.Mapping;

using AutoMapper;
using EsportsProfileWebApi.Web.Controllers.DTOs;
using EsportsProfileWebApi.Web.Controllers.DTOs.Data;
using EsportsProfileWebApi.Web.Controllers.DTOs.User;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.Data;
using EsportsProfileWebApi.Web.Responses.User;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetDataResponseDTO, GetDataResponseModel>().ReverseMap();
        CreateMap<GetDataRequestDTO, GetDataRequestModel>().ReverseMap();
        CreateMap<UpdateDataRequestDTO, UpdateDataRequestModel>().ReverseMap();
        CreateMap<UpdateDataResponseDTO, UpdateDataResponseModel>().ReverseMap();
        CreateMap<UpdateDataResponseModel,Boolean>().ReverseMap();

        CreateMap<UserLoginRequestDTO, UserLoginRequestModel>().ReverseMap();
        CreateMap<UserRegisterRequestDTO, UserRegisterRequestModel>().ReverseMap();
        CreateMap<UserRegisterResponseDTO, UserRegisterResponseModel>().ReverseMap();
        CreateMap<UserLoginResponseDTO, UserLoginResponseModel>().ReverseMap();

        CreateMap<GetDataResponseModel, DataEntity>().ReverseMap();

        CreateMap<GetPaginatedUsersRequestDTO,GetPaginatedUsersRequestModel>().ReverseMap();
    }
}
