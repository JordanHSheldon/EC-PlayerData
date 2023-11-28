namespace Tests;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Controllers;
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

}