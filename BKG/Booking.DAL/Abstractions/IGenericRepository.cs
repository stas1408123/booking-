namespace Booking.DAL.Abstractions;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(Guid id);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity?> Delete(Guid id);
}