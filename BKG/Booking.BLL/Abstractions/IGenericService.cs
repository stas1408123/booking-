using Booking.BLL.Models;

namespace Booking.BLL.Abstractions;

public interface IGenericService<TModel>
    where TModel : BaseModel
{
    Task<List<TModel>> GetAll();
    Task<TModel> GetById(Guid id);
    Task<TModel> Add(TModel model);
    Task<TModel> Update(TModel model);
    Task<TModel> Delete(Guid id);
}