using Domain.Base;
using Domain.Interfaces;

namespace Infra.Database
{
    internal class Repository<TEntity, TID> : IDisposable, IRepository<TEntity, TID> where TEntity : BaseModel<TID>
    {
        private PokedexContext? _pokedexContext;

        public Repository(PokedexContext pokedexContext)
        {
            _pokedexContext = pokedexContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _pokedexContext
                .Set<TEntity>()
                .AddAsync(entity);

            await _pokedexContext.SaveChangesAsync();

            return entity;
        }

        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> GetAsync(TID Id)
        {
            return await _pokedexContext
                .Set<TEntity>()
                .FindAsync(Id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (this._pokedexContext != null)
                {
                    this._pokedexContext.Dispose();
                    this._pokedexContext = null;
                }
        }
    }
}