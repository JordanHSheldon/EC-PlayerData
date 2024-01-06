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
    public void GetAllDataAsync_ReturnsGetDataResponse()
    {
        // Arrange
        var request = new List<GetDataResponse>();
        mockDataOrchestrator.Setup(test => test.GetAllDataAsync()).ReturnsAsync(request);

        // Act
        var result = _dataController.GetAllDataAsync();

        // Assert
        Assert.IsNotNull(result);
        mockDataOrchestrator.Verify(verify => verify.GetAllDataAsync(), Times.Once);
    }
}