using AspNetMvcArch.Domain;

namespace AspNetMvcArch.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long Id);
    }
}
