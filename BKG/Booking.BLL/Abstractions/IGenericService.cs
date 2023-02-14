using Booking.BLL.Models;

namespace Booking.BLL.Abstractions;

public interface IGenericService<TModel>
    where TModel : BaseModel
{
    Task<List<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(Guid id);
    Task<TModel> AddAsync(TModel model);
    Task<TModel> UpdateAsync(TModel model);
    Task<TModel> DeleteAsync(Guid id);
}