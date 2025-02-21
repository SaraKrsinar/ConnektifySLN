using Connektify.Application.IRepositories;
using Connektify.Domain.Entities;
using Connektify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country.CountryId;
        }

        public async Task<int> UpdateAsync(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return country.CountryId;
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetCompanyStatisticsByCountryIdAsync(int countryId)
{
    return await _context.Contacts
        .Where(c => c.CountryId == countryId)
        .GroupBy(c => c.Company.CompanyName ?? string.Empty) // Fallback to empty string if CompanyName is null
        .Select(group => new { Company = group.Key, ContactCount = group.Count() })
        .ToDictionaryAsync(group => group.Company, group => group.ContactCount);
}
    }
}
