using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connektify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompanies()
        {
            var companies = await _companyService.GetCompaniesAsync();
            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCompany([FromBody] Company company)
        {
            var companyId = await _companyService.CreateCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompanies), new { id = companyId }, companyId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateCompany(int id, [FromBody] Company company)
        {
            if (id != company.CompanyId)
                return BadRequest();

            var updatedCompanyId = await _companyService.UpdateCompanyAsync(company);
            return Ok(updatedCompanyId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
