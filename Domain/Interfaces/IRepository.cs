using Domain.Base;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity, TID> where TEntity : BaseModel<TID>
    {
        Task<TEntity> GetAsync(TID Id);
        Task<TEntity> AddAsync(TEntity entity);
    }
}
