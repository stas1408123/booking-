using AutoMapper;
using Booking.DAL.Abstractions;

namespace Booking.BLL.Services;

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