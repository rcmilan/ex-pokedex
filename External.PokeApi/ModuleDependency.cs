using External.PokeApi.Api;
using External.PokeApi.Providers;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;

namespace External.PokeApi
{
    public static class ModuleDependency
    {
        public static void AddPokeApiModule(this IServiceCollection services)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var settings = new RefitSettings()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(options)
            };

            services.AddSingleton(RestService.For<IPokeApi>("https://pokeapi.co/api/v2"));

            services.AddScoped<IPokeApiProvider, PokeApiProvider>();
        }
    }
}