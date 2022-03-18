using External.PokeApi.Models;
using External.PokeApi.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeApiController : ControllerBase
    {
        private readonly IPokeApiProvider _apiProvider;

        public PokeApiController(IPokeApiProvider apiProvider)
        {
            _apiProvider = apiProvider;
        }

        [HttpGet]
        public async Task<ActionResult<Pokemon>> Get(int? number, string? name, CancellationToken cancellationToken)
        {
            var pkmn = await _apiProvider.Get(number, name, cancellationToken);

            if (pkmn is null)
                return NotFound();

            return Ok(pkmn);
        }
    }
}