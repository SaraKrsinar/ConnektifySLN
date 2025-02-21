using Connektify.Application.IRepositories;
using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) => _companyRepository = companyRepository;
        public Task<int> CreateCompanyAsync(Company company) => _companyRepository.CreateAsync(company);
        public Task<int> UpdateCompanyAsync(Company company) => _companyRepository.UpdateAsync(company);
        public Task DeleteCompanyAsync(int id) => _companyRepository.DeleteAsync(id);
        public Task<List<Company>> GetCompaniesAsync() => _companyRepository.GetAllAsync();
    }
}
