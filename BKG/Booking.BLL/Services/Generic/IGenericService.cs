using Booking.BLL.Models.Base;

namespace Booking.BLL.Services.Generic
{
    public interface IGenericService<TModel> 
        where TModel : BaseModel
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(Guid id);
        Task<TModel> AddAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task DeleteAsync(Guid id);
    }
}
