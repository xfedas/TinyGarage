using Microsoft.EntityFrameworkCore;
using TinyGarage.Models;
using TinyGarage.Repositories;
using TinyGarage.Repositories.Abstract;

public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : BaseModel
{
    internal readonly IDataRepository _repository;
    internal readonly IHttpContextAccessor _httpContextAccessor;
    internal ApplicationUser CurrentUser => throw new NotImplementedException();
        //_repository.GetUser(_httpContextAccessor.HttpContext?.User.Identity.Name);

    public EntityService(IDataRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _repository.GetAll<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> Get(Guid id)
    {
        return await _repository.Get<TEntity>(id);
    }


    public async Task Delete(Guid id)
    {
        await _repository.Delete<TEntity>(id);
    }
}
