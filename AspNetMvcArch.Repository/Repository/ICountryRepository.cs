using System;
using AspNetMvcArch.Model;
namespace AspNetMvcArch.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }
}
