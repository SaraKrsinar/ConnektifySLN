using Connektify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connektify.Application.IServices;
using Connektify.Application.IRepositories;

namespace Connektify.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository) => _contactRepository = contactRepository;
        public Task<int> CreateContactAsync(Contact contact) => _contactRepository.CreateAsync(contact);
        public Task<int> UpdateContactAsync(Contact contact) => _contactRepository.UpdateAsync(contact);
        public Task DeleteContactAsync(int id) => _contactRepository.DeleteAsync(id);
        public Task<List<Contact>> GetContactsAsync() => _contactRepository.GetAllAsync();
        public Task<List<Contact>> GetContactsWithCompanyAndCountryAsync() => _contactRepository.GetWithCompanyAndCountryAsync();
        public Task<List<Contact>> FilterContactsAsync(int countryId, int companyId) => _contactRepository.FilterContactsAsync(countryId, companyId);
    }
}
