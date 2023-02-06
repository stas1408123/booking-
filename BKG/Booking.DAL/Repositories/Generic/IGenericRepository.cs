﻿using Booking.DAL.Entities.Base;

namespace Booking.DAL.Repositories.Generic
{
    public interface IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}