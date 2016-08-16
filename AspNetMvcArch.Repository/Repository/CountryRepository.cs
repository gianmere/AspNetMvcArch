using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetMvcArch.Model;

namespace AspNetMvcArch.Repository
{
  public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
      public CountryRepository(DbContext context)
            : base(context)
        {
           
        }
        public Country GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();            
        }
    }
}
