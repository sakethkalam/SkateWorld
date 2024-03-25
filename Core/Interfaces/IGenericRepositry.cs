using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepositry<T> where T:BaseEntity
    {
        Task<T> GetProductById(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntitywithSpec(ISpecfication<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecfication<T> spec);
    }
}