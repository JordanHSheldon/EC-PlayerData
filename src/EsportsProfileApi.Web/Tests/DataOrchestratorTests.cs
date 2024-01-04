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
}