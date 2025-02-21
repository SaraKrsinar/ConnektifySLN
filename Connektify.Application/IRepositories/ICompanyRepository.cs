using Connektify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Application.IRepositories
{
    public interface ICompanyRepository
    {
        Task<int> CreateAsync(Company company);
        Task<int> UpdateAsync(Company company);
        Task DeleteAsync(int id);
        Task<List<Company>> GetAllAsync();
    }
}
