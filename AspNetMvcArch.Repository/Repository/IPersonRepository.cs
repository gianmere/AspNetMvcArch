using AspNetMvcArch.Domain;

namespace AspNetMvcArch.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long id);
    }
}
