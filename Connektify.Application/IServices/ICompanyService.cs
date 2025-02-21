using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.IServices
{
    public interface ICompanyService
    {
        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="company">The company to create.</param>
        /// <returns>The ID of the created company.</returns>
        Task<int> CreateCompanyAsync(Company company);

        /// <summary>
        /// Updates an existing company.
        /// </summary>
        /// <param name="company">The company to update.</param>
        /// <returns>The ID of the updated company.</returns>
        Task<int> UpdateCompanyAsync(Company company);

        /// <summary>
        /// Deletes a company by ID.
        /// </summary>
        /// <param name="id">The ID of the company to delete.</param>
        /// <returns>A task representing the deletion operation.</returns>
        Task DeleteCompanyAsync(int id);

        /// <summary>
        /// Retrieves a list of all companies.
        /// </summary>
        /// <returns>A list of companies.</returns>
        Task<List<Company>> GetCompaniesAsync();
    }
}
