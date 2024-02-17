using Microsoft.AspNetCore.Identity;
using TinyGarage.Models;

namespace TinyGarage.Repositories.Abstract
{
    public interface IDataRepository
    {
        IQueryable<T?> GetAll<T>() where T : BaseModel;
        Task<T?> Get<T>(Guid id) where T : BaseModel;
        void Delete<T>(Guid id) where T : BaseModel;
        void Update<T>(T entity) where T : BaseModel;
        void Create<T>(T entity) where T : BaseModel;
        void Save();
        ApplicationUser GetUser(string email);
        IUserStore<ApplicationUser> GetUserStore();
        void Dispose();
    }
}