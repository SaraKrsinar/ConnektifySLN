using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.IServices
{
    public interface ICountryService
    {
        /// <summary>
        /// Creates a new country.
        /// </summary>
        /// <param name="country">The country to create.</param>
        /// <returns>The ID of the created country.</returns>
        Task<int> CreateCountryAsync(Country country);

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country">The country to update.</param>
        /// <returns>The ID of the updated country.</returns>
        Task<int> UpdateCountryAsync(Country country);

        /// <summary>
        /// Deletes a country by ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        /// <returns>A task representing the deletion operation.</returns>
        Task DeleteCountryAsync(int id);

        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <returns>A list of countries.</returns>
        Task<List<Country>> GetCountriesAsync();

        /// <summary>
        /// Retrieves statistics of companies for a given country.
        /// </summary>
        /// <param name="countryId">The ID of the country.</param>
        /// <returns>A dictionary where the key is the company name and the value is the number of contacts associated with that company.</returns>
        Task<Dictionary<string, int>> GetCompanyStatisticsByCountryIdAsync(int countryId);
    }
}
