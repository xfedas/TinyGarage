using Microsoft.AspNetCore.Identity;
using TinyGarage.Models;

namespace TinyGarage.Repositories.Abstract
{
    public interface IDataRepository
    {
        IQueryable<T> GetAll<T>() where T : BaseModel;
        Task<T?> Get<T>(Guid id) where T : BaseModel;
        Task Delete<T>(Guid id) where T : BaseModel;
        Task Update<T>(T entity) where T : BaseModel;
        Task Create<T>(T entity) where T : BaseModel;
        ApplicationUser GetUser(string email);
        IUserStore<ApplicationUser> GetUserStore();
        void Dispose();
    }
}