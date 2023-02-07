using AutoMapper;
using Booking.BLL.Models.Base;
using Booking.BLL.Services.Base;
using Booking.DAL.Entities.Base;
using Booking.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Booking.BLL.Services.Generic
{
    public class GenericService<TEntity, TModel> : Service<TEntity, TModel>, IGenericService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
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
                throw new ArgumentNullException(nameof(entity));
            }

            var model = Mapper.Map<TEntity, TModel>(entity);

            return model;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            var entity = Mapper.Map<TModel, TEntity>(model);
            entity.Id = Guid.NewGuid();

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
