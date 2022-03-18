using External.PokeApi.Api;
using External.PokeApi.Models;

namespace External.PokeApi.Providers
{
    internal class PokeApiProvider : IPokeApiProvider
    {
        private readonly IPokeApi _api;

        public PokeApiProvider(IPokeApi api)
        {
            _api = api;
        }

        public async Task<Pokemon> Get(int? number, string? name, CancellationToken cancellationToken)
        {
            if (number is not null)
                return await _api.Pokemon(number.Value, cancellationToken);

            if (!string.IsNullOrEmpty(name))
                return await _api.Pokemon(name, cancellationToken);

            return default!;
        }
    }
}