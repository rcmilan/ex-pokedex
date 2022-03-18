using External.PokeApi.Models;
using Refit;

namespace External.PokeApi.Api
{
    internal interface IPokeApi
    {
        [Get("/pokemon/{number}")]
        Task<Pokemon> Pokemon([AliasAs("number")] int number, CancellationToken cancellationToken);

        [Get("/pokemon/{name}")]
        Task<Pokemon> Pokemon([AliasAs("name")] string name, CancellationToken cancellationToken);
    }
}
