using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories.Base
{
    public abstract class BaseRepository<TEntity> 
        where TEntity : class
    {
        protected readonly BookingDbContext DbContext;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(BookingDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
    }
}
