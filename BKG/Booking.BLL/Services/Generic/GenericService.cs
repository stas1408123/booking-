using AutoMapper;
using Booking.BLL.Services.Base;
using Booking.DAL.Entities.Base;
using Booking.DAL.Repositories.Generic;

namespace Booking.BLL.Services.Generic
{
    public class GenericService<TEntity, TModel> : Service<TEntity, TModel>, IGenericService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : class
    {
        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var entities = await GenericRepository.GetAllAsync();

            return Mapper.Map<List<TEntity>, List<TModel>>(entities);
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            var entity = await GenericRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Mapper.Map<TEntity, TModel>(entity);
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            var entity = Mapper.Map<TModel, TEntity>(model);
            var returnedEntity = await GenericRepository.AddAsync(entity);

            if (returnedEntity is null)
            {
                throw new ArgumentNullException(nameof(returnedEntity));
            }

            return model;
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = Mapper.Map<TModel, TEntity>(model);
            var returnedEntity = await GenericRepository.UpdateAsync(entity);

            if (returnedEntity is null)
            {
                throw new ArgumentNullException(nameof(returnedEntity));
            }

            return model;
        }

        public void Delete(TModel model)
        {
            var entity = Mapper.Map<TModel, TEntity>(model);
            GenericRepository.Delete(entity);
        }
    }
}
