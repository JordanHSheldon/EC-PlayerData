namespace Tests;

using EsportsProfileWebApi.Web.Controllers;
using Moq;
using NUnit.Framework;

[TestFixture]
public class UserControllerTests
{
    //private readonly Mock<IUserOrchestrator> mockUserOrchestrator;
    private readonly UserController _userController;

    //[SetUp]
    public UserControllerTests()
    {
        //mockUserOrchestrator = new Mock<IUserOrchestrator>();
        _userController = new UserController();
    }

    [Test]
    public void LoginGiven_LoginRequestReturns()
    {
        ////Arrange
        //var request = new GetDataRequest();
        //var response = new GetDataResponse();
        ////Act
        //var result = _userController.;

        ////Assert
        //Assert.AreEqual(response, 1);
    }

}