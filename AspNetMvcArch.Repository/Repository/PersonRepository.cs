﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AspNetMvcArch.Domain;

namespace AspNetMvcArch.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            : base(context)
        {
           
        }

        public override IEnumerable<Person> GetAll()
        {
            return _entities.Set<Person>().Include(x=>x.Country).AsEnumerable(); 
        }

        public Person GetById(long id)
        {
            return _dbset.Include(x=>x.Country).Where(x => x.Id == id).FirstOrDefault();            
        }
    }
}
