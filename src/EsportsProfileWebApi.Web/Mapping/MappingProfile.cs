namespace EsportsProfileWebApi.Web.Mapping;

using AutoMapper;
using Controllers.DTOs.Data;
using Controllers.DTOs.User;
using Controllers.DTOs;
using Orchestrators.Models.User;
using Repository.Entities.Data;
using Orchestrators.Models.Data;
using Responses.User;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetDataResponseDTO, GetDataResponseModel>().ReverseMap();
        CreateMap<GetDataRequestDTO, GetDataRequestModel>().ReverseMap();
        CreateMap<UpdateDataRequestDTO, UpdateDataRequestModel>().ReverseMap();
        CreateMap<UpdateDataResponseDTO, UpdateDataResponseModel>().ReverseMap();
        CreateMap<UpdateDataResponseModel, bool>().ReverseMap();
        CreateMap<UserLoginRequestDTO, UserLoginRequestModel>().ReverseMap();
        CreateMap<UpdateUserPeripheralsRequestDto, UpdateUserPeripheralsRequest>();
        CreateMap<UserRegisterRequestDTO, UserRegisterRequestModel>().ReverseMap();
        CreateMap<UserRegisterResponseDTO, UserRegisterResponseModel>().ReverseMap();
        CreateMap<UserLoginResponseDTO, UserLoginResponseModel>().ReverseMap();
        CreateMap<GetDataResponseModel, DataEntity>().ReverseMap();
        CreateMap<DataEntity, GetPaginatedUsersResponseModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<GetPaginatedUsersRequestDTO,GetPaginatedUsersRequestModel>().ReverseMap();
        CreateMap<GetPaginatedUsersResponseDto,GetPaginatedUsersResponseModel>().ReverseMap();
        CreateMap<PeripheralDto,PeripheralModel>().ReverseMap();
        CreateMap<PeripheralModel,PeripheralEntity>().ReverseMap();
    }
}
