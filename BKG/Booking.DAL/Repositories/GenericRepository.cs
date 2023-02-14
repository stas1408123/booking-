using Booking.DAL.Abstractions;
using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories;

public class GenericRepository<TEntity> : BaseRepository<TEntity>, IGenericRepository<TEntity>
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

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
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

    public async Task<TEntity?> DeleteAsync(Guid id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity != null) DbSet.Remove(entity);

        await DbContext.SaveChangesAsync();

        return entity;
    }
}