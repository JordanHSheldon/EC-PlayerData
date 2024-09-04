namespace EsportsProfileWebApi.Web.Mapping;

using AutoMapper;
using EsportsProfileWebApi.Web.Controllers.DTOs;
using EsportsProfileWebApi.Web.Controllers.DTOs.Data;
using EsportsProfileWebApi.Web.Controllers.DTOs.User;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.Data;
using EsportsProfileWebApi.Web.Orchestrators.Models.Data;
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

        CreateMap<DataEntity, GetPaginatedUsersResponseModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetPaginatedUsersRequestDTO,GetPaginatedUsersRequestModel>().ReverseMap();
        CreateMap<GetPaginatedUsersResponseDTO,GetPaginatedUsersResponseModel>().ReverseMap();

        CreateMap<PeripheralDTO,PeripheralModel>().ReverseMap();
        CreateMap<PeripheralModel,PeripheralEntity>().ReverseMap();
    }
}
