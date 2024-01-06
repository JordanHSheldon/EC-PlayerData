namespace Tests;

using EsportsProfileWebApi.Web.Controllers;
using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Requests.User;
using EsportsProfileWebApi.Web.Responses.User;
using Moq;
using NUnit.Framework;

[TestFixture]
public class UserControllerTests
{
    private readonly UserController _userController;
    private readonly Mock<IUserOrchestrator> mockUserOrchestrator;

    public UserControllerTests()
    {
        mockUserOrchestrator = new Mock<IUserOrchestrator>();
        _userController = new UserController(mockUserOrchestrator.Object);
    }

    [Test]
    public void RegisterGivenValidData_ReturnsGetUserDataResponse()
    {
        // Arrange
        var request = new RegisterRequest();
        var response = new GetUserDataResponse();
        mockUserOrchestrator.Setup(test => test.RegisterUser(request)).ReturnsAsync(response);

        // Act
        var result = _userController.Register(request);

        // Assert
        Assert.IsNotNull(result);
        mockUserOrchestrator.Verify(verify => verify.RegisterUser(request), Times.Once);    
    }

    [Test]
    public void LoginGiven_LoginRequestReturns()
    {
        //// Arrange
        //var request = new LoginRequest();
        //var response = new LoginResponse();
        //mockUserOrchestrator.Setup(test => test.LoginUser(request)).ReturnsAsync(response);

        //// Act
        //var result = _userController.Login(request);

        //// Assert
        //Assert.IsNotNull(result);
        //mockUserOrchestrator.Verify(verify => verify.LoginUser(request), Times.Once);
    }

}