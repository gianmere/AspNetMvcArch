using AspNetMvcArch.Domain;
using AspNetMvcArch.Repository;

namespace AspNetMvcArch.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        IUnitOfWork _unitOfWork;
        IPersonRepository _personRepository;
        
        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }


        public Person GetById(long Id) {
            var person = _personRepository.GetById(Id);
            return person;
        }
    }
}
