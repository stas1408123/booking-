using Booking.DAL.Entities.Base;
using Booking.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories.Generic
{
    public class GenericRepository<TEntity> : Repository<TEntity>, IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        public GenericRepository(BookingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id
                    .Equals(id));
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }
    }
}
