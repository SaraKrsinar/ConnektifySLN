using Connektify.Controllers;
using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class ContactsControllerTests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly ContactsController _controller;

    public ContactsControllerTests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _controller = new ContactsController(_contactServiceMock.Object);
    }

    [Fact]
    public async Task GetContacts_ReturnsOkResult_WithContacts()
    {
        // Arrange
        var contacts = new List<Contact> { new Contact { ContactId = 1, ContactName = "John" } };
        _contactServiceMock.Setup(service => service.GetContactsAsync()).ReturnsAsync(contacts);

        // Act
        var result = await _controller.GetContacts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Contact>>(okResult.Value);
        Assert.Equal(1, returnValue.Count);
    }

    [Fact]
    public async Task CreateContact_ReturnsCreatedAtAction_WithContactId()
    {
        // Arrange
        var contact = new Contact { ContactName = "John" };
        _contactServiceMock.Setup(service => service.CreateContactAsync(contact)).ReturnsAsync(1);

        // Act
        var result = await _controller.CreateContact(contact);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal("GetContacts", createdAtActionResult.ActionName);
        Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
    }

    [Fact]
    public async Task UpdateContact_ReturnsOkResult_WithUpdatedContactId()
    {
        // Arrange
        var contact = new Contact { ContactId = 1, ContactName = "John" };
        _contactServiceMock.Setup(service => service.UpdateContactAsync(contact)).ReturnsAsync(1);

        // Act
        var result = await _controller.UpdateContact(1, contact);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(1, okResult.Value);
    }

    [Fact]
    public async Task DeleteContact_ReturnsNoContent()
    {
        // Arrange
        _contactServiceMock.Setup(service => service.DeleteContactAsync(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteContact(1);

        // Assert
        Assert.IsType<NoContentResult>(result.ExecuteResult);
    }

    [Fact]
    public async Task FilterContacts_ReturnsOkResult_WithFilteredContacts()
    {
        // Arrange
        var filteredContacts = new List<Contact> { new Contact { ContactId = 1, ContactName = "John" } };
        _contactServiceMock.Setup(service => service.FilterContactsAsync(1, 1)).ReturnsAsync(filteredContacts);

        // Act
        var result = await _controller.FilterContacts(1, 1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Contact>>(okResult.Value);
        Assert.Equal(1, returnValue.Count);
    }
}
