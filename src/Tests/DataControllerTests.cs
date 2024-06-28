namespace Tests;

using AutoMapper;
using EsportsProfileWebApi.Web.Controllers;
using EsportsProfileWebApi.Web.Controllers.DTOs.Data;
using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using Moq;
using NUnit.Framework;

[TestFixture]
public class DataControllerTests
{
    private readonly Mock<IDataOrchestrator> mockDataOrchestrator;
    private readonly DataController _dataController;
    private readonly Mock<IMapper> _mapper;

    public DataControllerTests()
    {
        mockDataOrchestrator = new Mock<IDataOrchestrator>();
        _mapper = new Mock<IMapper>();
        _dataController = new DataController(mockDataOrchestrator.Object, _mapper.Object);
    }

    [Test]
    public void GetPaginatedUsersAsync_ValidRequest_ReturnsGetDataResponse()
    {
        // Arrange
        var response = new List<GetPaginatedUsersResponseModel>();
        mockDataOrchestrator.Setup(test => test.GetPaginatedUsersAsync(It.IsAny<GetPaginatedUsersRequestModel>())).ReturnsAsync(response);

        // Act
        var result = _dataController.GetPaginatedUsersAsync(new GetPaginatedUsersRequestDTO());

        // Assert
        Assert.IsNotNull(result);
        mockDataOrchestrator.Verify(verify => verify.GetPaginatedUsersAsync(It.IsAny<GetPaginatedUsersRequestModel>()), Times.Once);
    }

    [Test]
    public void GetDataByUserName_ReturnsGetDataResponse()
    {
        // Arrange
        var request = new GetDataRequestDTO();
        mockDataOrchestrator.Setup(test => test.GetData(It.IsAny<GetDataRequestModel>())).ReturnsAsync(new GetDataResponseModel());

        // Act
        var result = _dataController.GetDataByUserName(request);

        // Assert
        Assert.IsNotNull(result);
        mockDataOrchestrator.Verify(verify => verify.GetData(It.IsAny<GetDataRequestModel>()), Times.Once);
    }
}