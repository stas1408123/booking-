using AutoMapper;
using Booking.DAL.Repositories.Generic;

namespace Booking.BLL.Services.Base
{
    public abstract class BaseService<TEntity>
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> GenericRepository;
        protected readonly IMapper Mapper;

        protected BaseService(IGenericRepository<TEntity> genericRepository,
            IMapper mapper)
        {
            GenericRepository = genericRepository;
            Mapper = mapper;
        }
    }
}
