namespace Tests;

using AutoMapper;
using EsportsProfileWebApi.Web.Controllers;
using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Responses.User;
using Moq;
using NUnit.Framework;

[TestFixture]
public class UserControllerTests
{
    private readonly UserController _userController;
    private readonly Mock<IUserOrchestrator> mockUserOrchestrator;
    private readonly Mock<IMapper> mapper;

    public UserControllerTests()
    {
        mapper = new Mock<IMapper>();
        mockUserOrchestrator = new Mock<IUserOrchestrator>();
        _userController = new UserController(mockUserOrchestrator.Object, mapper.Object);
    }

    [Test]
    public void RegisterGivenValidData_ReturnsGetUserDataResponse()
    {
        // Arrange
        var request = new UserRegisterRequestDTO();
        mockUserOrchestrator.Setup(test => test.RegisterUser(It.IsAny<UserRegisterRequestModel>())).ReturnsAsync(new UserRegisterResponseModel());

        // Act
        var result = _userController.Register(request);

        // Assert
        Assert.IsNotNull(result);
        mockUserOrchestrator.Verify(verify => verify.RegisterUser(It.IsAny<UserRegisterRequestModel>()), Times.Once);    
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