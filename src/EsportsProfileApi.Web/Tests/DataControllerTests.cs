namespace Tests;

using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.Web.Controllers;
using EsportsProfileWebApi.Web.Orchestrators;
using Moq;
using NUnit.Framework;

[TestFixture]
public class DataControllerTests
{
    private readonly Mock<IDataOrchestrator> mockDataOrchestrator;
    private readonly DataController _dataController;

    public DataControllerTests()
    {
        mockDataOrchestrator = new Mock<IDataOrchestrator>();
        _dataController = new DataController(mockDataOrchestrator.Object);
    }

    [Test]
    public void GetAllData_ReturnsGetDataResponse()
    {
        // Arrange
        var request = new List<GetDataResponse>();
        mockDataOrchestrator.Setup(test => test.GetAllData()).Returns(request);

        // Act
        var result = _dataController.GetAllData();

        // Assert
        Assert.IsNotNull(result);
        mockDataOrchestrator.Verify(verify => verify.GetAllData(), Times.Once);
    }

    [Test]
    public void GetDataByName_ReturnsGetDataResponse()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public void GetDataById_ReturnsGetDataResponse()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public void UpdateDataById_ReturnsGetDataResponse()
    {
        // Arrange

        // Act

        // Assert
    }

}