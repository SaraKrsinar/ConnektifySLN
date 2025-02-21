using Connektify.Controllers;
using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class CompaniesControllerTests
{
    private readonly Mock<ICompanyService> _companyServiceMock;
    private readonly CompaniesController _controller;

    public CompaniesControllerTests()
    {
        _companyServiceMock = new Mock<ICompanyService>();
        _controller = new CompaniesController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task GetCompanies_ReturnsOkResult_WithCompanies()
    {
        // Arrange
        var companies = new List<Company> { new Company { CompanyId = 1, CompanyName = "Company A" } };
        _companyServiceMock.Setup(service => service.GetCompaniesAsync()).ReturnsAsync(companies);

        // Act
        var result = await _controller.GetCompanies();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Company>>(okResult.Value);
        Assert.Equal(1, returnValue.Count);
    }

    [Fact]
    public async Task CreateCompany_ReturnsCreatedAtAction_WithCompanyId()
    {
        // Arrange
        var company = new Company { CompanyName = "Company A" };
        _companyServiceMock.Setup(service => service.CreateCompanyAsync(company)).ReturnsAsync(1);

        // Act
        var result = await _controller.CreateCompany(company);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal("GetCompanies", createdAtActionResult.ActionName);
        Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
    }

    [Fact]
    public async Task UpdateCompany_ReturnsOkResult_WithUpdatedCompanyId()
    {
        // Arrange
        var company = new Company { CompanyId = 1, CompanyName = "Company A" };
        _companyServiceMock.Setup(service => service.UpdateCompanyAsync(company)).ReturnsAsync(1);

        // Act
        var result = await _controller.UpdateCompany(1, company);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(1, okResult.Value);
    }

    [Fact]
    public async Task DeleteCompany_ReturnsNoContent()
    {
        // Arrange
        _companyServiceMock.Setup(service => service.DeleteCompanyAsync(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteCompany(1);

        // Assert
        Assert.IsType<NoContentResult>(result.ExecuteResult);
    }
}
