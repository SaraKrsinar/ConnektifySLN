using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.IRepositories
{
    public interface ICountryRepository
    {
        Task<int> CreateAsync(Country country);
        Task<int> UpdateAsync(Country country);
        Task DeleteAsync(int id);
        Task<List<Country>> GetAllAsync();
        Task<Dictionary<string, int>> GetCompanyStatisticsByCountryIdAsync(int countryId);
    }
}
