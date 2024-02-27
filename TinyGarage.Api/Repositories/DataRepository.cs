using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TinyGarage.Models;
using TinyGarage.Repositories.Abstract;

namespace TinyGarage.Repositories
{
    public class DataRepository : IDataRepository
    {
        internal AppDbContext _context;

        public DataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create<T>(T entity) where T : BaseModel
        {   
            await _context.Set<T>().AddAsync(entity);
            await Save();
        }   

        public async Task Delete<T>(Guid id) where T : BaseModel
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await Update<T>(entity);
            }

            await Save();
        }

        public async Task<T?> Get<T>(Guid id) where T : BaseModel
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll<T>() where T : BaseModel
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task Update<T>(T entity) where T : BaseModel
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        internal async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public ApplicationUser GetUser(string email)
        {
            return _context.Users.First(u => u.Email == email);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IUserStore<ApplicationUser> GetUserStore()
        {
            return new UserStore<ApplicationUser>(_context);
        }
    }
}