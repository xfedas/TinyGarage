using TinyGarage.Models;
using TinyGarage.Repositories;

public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : BaseModel
{
    internal readonly DataRepository _repository;
    internal readonly IHttpContextAccessor _httpContextAccessor;
    internal ApplicationUser CurrentUser => _repository.GetUser(_httpContextAccessor.HttpContext?.User.Identity.Name);

    public EntityService(DataRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    public IQueryable<TEntity?> GetAll()
    {
        return _repository.GetAll<TEntity>();
    }

    public async Task<TEntity?> Get(Guid id)
    {
        return await _repository.Get<TEntity>(id);
    }


    public void Delete(Guid id)
    {
        _repository.Delete<TEntity>(id);
    }
}
