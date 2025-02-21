using Connektify.Controllers;
using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class CountriesControllerTests
{
    private readonly Mock<ICountryService> _countryServiceMock;
    private readonly CountriesController _controller;

    public CountriesControllerTests()
    {
        _countryServiceMock = new Mock<ICountryService>();
        _controller = new CountriesController(_countryServiceMock.Object);
    }

    [Fact]
    public async Task GetCountries_ReturnsOkResult_WithCountries()
    {
        // Arrange
        var countries = new List<Country> { new Country { CountryId = 1, CountryName = "Country A" } };
        _countryServiceMock.Setup(service => service.GetCountriesAsync()).ReturnsAsync(countries);

        // Act
        var result = await _controller.GetCountries();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Country>>(okResult.Value);
        Assert.Equal(1, returnValue.Count);
    }

    [Fact]
    public async Task CreateCountry_ReturnsCreatedAtAction_WithCountryId()
    {
        // Arrange
        var country = new Country { CountryName = "Country A" };
        _countryServiceMock.Setup(service => service.CreateCountryAsync(country)).ReturnsAsync(1);

        // Act
        var result = await _controller.CreateCountry(country);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal("GetCountries", createdAtActionResult.ActionName);
        Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
    }

    [Fact]
    public async Task UpdateCountry_ReturnsOkResult_WithUpdatedCountryId()
    {
        // Arrange
        var country = new Country { CountryId = 1, CountryName = "Country A" };
        _countryServiceMock.Setup(service => service.UpdateCountryAsync(country)).ReturnsAsync(1);

        // Act
        var result = await _controller.UpdateCountry(1, country);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(1, okResult.Value);
    }

    [Fact]
    public async Task DeleteCountry_ReturnsNoContent()
    {
        // Arrange
        _countryServiceMock.Setup(service => service.DeleteCountryAsync(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteCountry(1);

        // Assert
        Assert.IsType<NoContentResult>(result.ExecuteResult);
    }

    [Fact]
    public async Task GetCompanyStatisticsByCountryId_ReturnsOkResult_WithStatistics()
    {
        // Arrange
        var statistics = new Dictionary<string, int> { { "Company A", 5 } };
        _countryServiceMock.Setup(service => service.GetCompanyStatisticsByCountryIdAsync(1)).ReturnsAsync(statistics);

        // Act
        var result = await _controller.GetCompanyStatisticsByCountryId(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Dictionary<string, int>>(okResult.Value);
        Assert.Equal(1, returnValue.Count);
    }
}
