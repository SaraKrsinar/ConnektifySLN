using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connektify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            var countries = await _countryService.GetCountriesAsync();
            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCountry([FromBody] Country country)
        {
            var countryId = await _countryService.CreateCountryAsync(country);
            return CreatedAtAction(nameof(GetCountries), new { id = countryId }, countryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.CountryId)
                return BadRequest();

            var updatedCountryId = await _countryService.UpdateCountryAsync(country);
            return Ok(updatedCountryId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            await _countryService.DeleteCountryAsync(id);
            return NoContent();
        }

        [HttpGet("statistics/{countryId}")]
        public async Task<ActionResult<Dictionary<string, int>>> GetCompanyStatisticsByCountryId(int countryId)
        {
            var statistics = await _countryService.GetCompanyStatisticsByCountryIdAsync(countryId);
            return Ok(statistics);
        }
    }
}
