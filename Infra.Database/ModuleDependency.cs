using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database
{
    public static class ModuleDependency
    {
        public static void AddDatabaseModule(this IServiceCollection services)
        {
            services.AddDbContext<PokedexContext>(options => options.UseSqlite($"Data Source=./db/pokedex.sqlite3;"));

            services.AddScoped<IRepository<Pokemon, int>, Repository<Pokemon, int>>();
        }
    }
}
