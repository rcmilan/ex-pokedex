using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IRepository<Pokemon, int> _repository;

        public PokemonController(IMediator mediator, IRepository<Pokemon, int> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddPokemon command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int Id)
        {
            var result = await _repository.GetAsync(Id);

            return Ok(result);
        }
    }
}
