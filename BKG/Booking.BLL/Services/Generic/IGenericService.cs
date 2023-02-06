using Booking.DAL.Entities.Base;

namespace Booking.BLL.Services.Generic
{
    public interface IGenericService<TEntity, TModel> 
        where TModel : class
        where TEntity : BaseEntity
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(Guid id);
        Task<TModel> AddAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        void Delete(TModel model);
    }
}
