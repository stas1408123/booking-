using Booking.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories.Base
{
    public abstract class Repository<TEntity> 
        where TEntity : BaseEntity
    {
        protected readonly BookingDbContext DbContext;
        protected DbSet<TEntity> DbSet;

        public Repository(BookingDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
    }
}
