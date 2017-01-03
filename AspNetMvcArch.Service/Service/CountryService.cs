using AspNetMvcArch.Domain;
using AspNetMvcArch.Repository;

namespace AspNetMvcArch.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        IUnitOfWork _unitOfWork;
        ICountryRepository _countryRepository;
        IPersonRepository _personRepository;
        
        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository, IPersonRepository personRepository)
            : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
            _personRepository = personRepository;
        }


        public Country GetById(int Id) {

            var country = _countryRepository.GetById(Id);
            return country;
        }

        public void Delete(int id)
        {

            var persons = _personRepository.FindBy(x => x.CountryId == id);
            foreach (var person in persons)
            {
                _personRepository.Delete(person);
            }

            Country country = _countryRepository.GetById(id);
            _countryRepository.Delete(country);

            _unitOfWork.Commit();
        }
    }
}
