using TinyGarage.Models;

public interface IEntityService<TEntity> where TEntity : BaseModel
{
    IQueryable<TEntity?> GetAll();
    Task<TEntity?> Get(Guid id);
    Task Delete(Guid id);
}