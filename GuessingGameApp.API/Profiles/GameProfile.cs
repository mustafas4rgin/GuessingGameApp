using AutoMapper;
using GuessingGameApp.Application.DTOs.Create;
using GuessingGameApp.Application.DTOs.List;
using GuessingGameApp.Application.DTOs.Update;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.API.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameDTO>().ReverseMap();
        CreateMap<Game, CreateGameDTO>().ReverseMap();
        CreateMap<Game, UpdateGameDTO>().ReverseMap();
    }
}