using AutoMapper;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using Booking.DAL.Abstractions;

namespace Booking.BLL.Services;

public class GenericService<TEntity, TModel> : BaseService<TEntity>, IGenericService<TModel>
    where TEntity : class
    where TModel : BaseModel
{
    public GenericService(IGenericRepository<TEntity> repository,
        IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<List<TModel>> GetAll()
    {
        var entities = await GenericRepository.GetAll();

        var models = Mapper.Map<List<TModel>>(entities);

        return models;
    }

    public async Task<TModel> GetById(Guid id)
    {
        var entity = await GenericRepository.GetById(id);

        if (entity is null) throw new ArgumentNullException($"Cannot find {typeof(TModel).Name} by id: {id}");

        var model = Mapper.Map<TModel>(entity);

        return model;
    }

    public async Task<TModel> Add(TModel model)
    {
        model.Id = Guid.NewGuid();
        var entity = Mapper.Map<TEntity>(model);

        var createdEntity = await GenericRepository.Add(entity);
        var createdModel = Mapper.Map<TModel>(createdEntity);

        return createdModel;
    }

    public async Task<TModel> Update(TModel model)
    {
        var entity = Mapper.Map<TEntity>(model);
        await GenericRepository.Update(entity);

        return model;
    }

    public async Task<TModel> Delete(Guid id)
    {
        var entity = await GenericRepository.Delete(id);

        var model = Mapper.Map<TModel>(entity);

        return model;
    }
}