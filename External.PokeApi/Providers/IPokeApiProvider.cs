using External.PokeApi.Models;

namespace External.PokeApi.Providers
{
    public interface IPokeApiProvider
    {
        Task<Pokemon> Get(int? number, string? name, CancellationToken cancellationToken);
    }
}