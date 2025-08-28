using AutoMapper;
using FluentValidation;
using GuessingGameApp.API.Controllers;
using GuessingGameApp.Application.DTOs.Create;
using GuessingGameApp.Application.DTOs.List;
using GuessingGameApp.Application.DTOs.Update;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : GenericController<Game, GameDTO, CreateGameDTO, UpdateGameDTO>
    {
        public GameController(
            IGameService gameService,
            IMapper mapper,
            IValidator<CreateGameDTO> createValidator,
            IValidator<UpdateGameDTO> updateValidator
        ) : base(gameService, mapper, createValidator, updateValidator)
        {
            
        }
    }
}
