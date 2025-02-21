using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.IServices
{
    public interface IContactService
    {
        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="contact">The contact to create.</param>
        /// <returns>The ID of the created contact.</returns>
        Task<int> CreateContactAsync(Contact contact);

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <param name="contact">The contact to update.</param>
        /// <returns>The ID of the updated contact.</returns>
        Task<int> UpdateContactAsync(Contact contact);

        /// <summary>
        /// Deletes a contact by ID.
        /// </summary>
        /// <param name="id">The ID of the contact to delete.</param>
        /// <returns>A task representing the deletion operation.</returns>
        Task DeleteContactAsync(int id);

        /// <summary>
        /// Retrieves a list of all contacts.
        /// </summary>
        /// <returns>A list of contacts.</returns>
        Task<List<Contact>> GetContactsAsync();

        /// <summary>
        /// Retrieves contacts with their associated companies and countries.
        /// </summary>
        /// <returns>A list of contacts with company and country data.</returns>
        Task<List<Contact>> GetContactsWithCompanyAndCountryAsync();

        /// <summary>
        /// Filters contacts by country and company IDs.
        /// </summary>
        /// <param name="countryId">The country ID to filter by.</param>
        /// <param name="companyId">The company ID to filter by.</param>
        /// <returns>A list of contacts filtered by the specified criteria.</returns>
        Task<List<Contact>> FilterContactsAsync(int countryId, int companyId);
    }
}

