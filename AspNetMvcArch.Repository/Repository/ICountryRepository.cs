using System;
using AspNetMvcArch.Domain;
namespace AspNetMvcArch.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }
}
