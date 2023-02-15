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

    public async Task<List<TEntity>> GetAll()
    {
        return await DbSet.AsNoTracking()
            .ToListAsync();
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }


    public async Task<TEntity> Add(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        DbSet.Update(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity?> Delete(Guid id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity != null) DbSet.Remove(entity);

        await DbContext.SaveChangesAsync();

        return entity;
    }
}