using _eTicketSystem.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _eTicketSystem.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity) 
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        } 
        

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().SingleOrDefaultAsync(n => n.id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>   await context.Set<T>().ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await context.Set<T>().SingleOrDefaultAsync(n => n.id == id);
        
       public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
