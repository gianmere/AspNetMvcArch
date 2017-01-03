using System.Collections.Generic;
using AspNetMvcArch.Domain;

namespace AspNetMvcArch.Service
{
    public interface IEntityService<T>: IService
     where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();      
        void Update(T entity);
    }
}
