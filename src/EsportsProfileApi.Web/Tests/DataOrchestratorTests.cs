namespace Tests;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Orchestrators;
using Moq;
using NUnit.Framework;

[TestFixture]
public class DataOrchestratorTests
{
    private readonly Mock<IDataRepository> mockDataRepository;
    private readonly DataOrchestrator _dataOrchestrator;

    //[SetUp]
    public DataOrchestratorTests()
    {
        mockDataRepository = new Mock<IDataRepository>();
        _dataOrchestrator = new DataOrchestrator(mockDataRepository.Object);
    }

    [Test]
    public void GetDataGivenGetDataRequestReturnsGetDataResponse()
    {
        //Arrange
        var request = new GetDataRequest();
        var response = new GetDataResponse();
        mockDataRepository.Setup(test => test.GetData(It.IsAny<GetDataRequest>())).Returns(response);
        
        //Act
        var result = _dataOrchestrator.GetData(request);
        
        //Assert
        Assert.AreEqual(response, result);
    }

    [Test]
    public void GetAllDataGiven_ReturnsGetDataResponse()
    {
        //Arrange
        var response = new List<GetDataResponse>();
        mockDataRepository.Setup(test => test.GetAllData()).Returns(response);

        //Act
        var result = _dataOrchestrator.GetAllData();
        
        //Assert
        Assert.AreEqual(response, result);
    }

    [Test]
    public void UpdateData_GivenUpdateDataRequest_ReturnsBool()
    {
        //Arrange
        var request = new UpdateDataRequest();
        bool response = false;
        mockDataRepository.Setup(test => test.UpdateData(It.IsAny<UpdateDataRequest>())).Returns(response);

        //Act
        var result = _dataOrchestrator.UpdateData(request);

        //Assert
        Assert.AreEqual(response, result);
    }
}