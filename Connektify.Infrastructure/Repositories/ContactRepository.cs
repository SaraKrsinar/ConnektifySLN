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
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact.ContactId; 
        }

        public async Task<int> UpdateAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact.ContactId;
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> GetWithCompanyAndCountryAsync()
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
        }

        public async Task<List<Contact>> FilterContactsAsync(int countryId, int companyId)
        {
            return await _context.Contacts
                .Where(c => c.CountryId == countryId && c.CompanyId == companyId)
                .ToListAsync();
        }
    }
}
