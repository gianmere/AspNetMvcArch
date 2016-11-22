using AspNetMvcArch.Domain;
using AspNetMvcArch.Repository;

namespace AspNetMvcArch.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        IUnitOfWork _unitOfWork;
        ICountryRepository _countryRepository;
        
        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository)
            : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }


        public Country GetById(int Id) {

            var country = _countryRepository.GetById(Id);
            return country;
        }
    }
}
