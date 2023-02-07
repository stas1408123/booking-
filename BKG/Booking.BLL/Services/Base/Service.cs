using AutoMapper;
using Booking.DAL.Entities.Base;
using Booking.DAL.Repositories.Generic;

namespace Booking.BLL.Services.Base
{
    public abstract class Service<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : class
    {
        protected readonly IGenericRepository<TEntity> GenericRepository;
        protected readonly IMapper Mapper;

        protected Service(IGenericRepository<TEntity> genericRepository,
            IMapper mapper)
        {
            GenericRepository = genericRepository;
            Mapper = mapper;
        }
    }
}
