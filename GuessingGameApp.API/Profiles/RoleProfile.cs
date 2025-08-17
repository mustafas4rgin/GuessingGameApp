using AutoMapper;
using GuessingGameApp.Application.DTOs.Create;
using GuessingGameApp.Application.DTOs.List;
using GuessingGameApp.Application.DTOs.Update;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.API.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<CreateDayDTO,Role>().ReverseMap();
        CreateMap<Role,CreateRoleDTO>().ReverseMap();
        CreateMap<UpdateRoleDTO, Role>().ReverseMap();
        CreateMap<Role, UpdateRoleDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
    }
}