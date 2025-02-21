using Connektify.Application.IRepositories;
using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository) => _countryRepository = countryRepository;
        public Task<int> CreateCountryAsync(Country country) => _countryRepository.CreateAsync(country);
        public Task<int> UpdateCountryAsync(Country country) => _countryRepository.UpdateAsync(country);
        public Task DeleteCountryAsync(int id) => _countryRepository.DeleteAsync(id);
        public Task<List<Country>> GetCountriesAsync() => _countryRepository.GetAllAsync();
        public Task<Dictionary<string, int>> GetCompanyStatisticsByCountryIdAsync(int countryId) => _countryRepository.GetCompanyStatisticsByCountryIdAsync(countryId);
    }
}
