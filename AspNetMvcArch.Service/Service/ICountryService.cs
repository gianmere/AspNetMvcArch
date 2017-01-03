using AspNetMvcArch.Domain;

namespace AspNetMvcArch.Service
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int Id);

        void Delete(int id);
    }
}
