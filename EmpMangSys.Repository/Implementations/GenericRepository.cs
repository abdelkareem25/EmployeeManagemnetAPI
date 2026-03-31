using EmpMangSys.Core.Interface;
using EmpMangSys.Repository.DataBaseContext;

namespace EmpMangSys.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BadrGroupDbContext context;

        public GenericRepository(BadrGroupDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            context.SaveChanges();
        }

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
