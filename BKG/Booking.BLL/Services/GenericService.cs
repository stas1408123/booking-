using AutoMapper;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using Booking.DAL.Abstractions;

namespace Booking.BLL.Services
{
    public class GenericService<TEntity, TModel> : BaseService<TEntity>, IGenericService<TModel>
        where TEntity : class
        where TModel : BaseModel
    {
        public GenericService(IGenericRepository<TEntity> repository,
            IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var entities = await GenericRepository.GetAllAsync();

            var models = Mapper.Map<List<TEntity>, List<TModel>>(entities);

            return models;
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            var entity = await GenericRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new Exception($"Cannot find {typeof(TModel).Name} by id: {id}");
            }

            var model = Mapper.Map<TEntity, TModel>(entity);

            return model;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            model.Id = Guid.NewGuid();
            var entity = Mapper.Map<TModel, TEntity>(model);

            var createdEntity = await GenericRepository.AddAsync(entity);
            var createdModel = Mapper.Map<TEntity, TModel>(createdEntity);

            return createdModel;
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = Mapper.Map<TModel, TEntity>(model);
            await GenericRepository.UpdateAsync(entity);

            return model;
        }

        public async Task DeleteAsync(Guid id)
        {
            await GenericRepository.DeleteAsync(id);
        }
    }
}
