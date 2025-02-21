using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.IRepositories
{
    public interface IContactRepository
    {
        Task<int> CreateAsync(Contact contact);
        Task<int> UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<List<Contact>> GetAllAsync();
        Task<List<Contact>> GetWithCompanyAndCountryAsync();
        Task<List<Contact>> FilterContactsAsync(int countryId, int companyId);
    }
}
