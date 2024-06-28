namespace Tests;

using AutoMapper;
using EsportsProfileWebApi.Web.Repository;
using EsportsProfileWebApi.Web.Orchestrators;
using Moq;
using NUnit.Framework;

[TestFixture]
public class DataOrchestratorTests
{
    private readonly Mock<IDataRepository> mockDataRepository;
    private readonly Mock<IMapper> mapper;
    private readonly DataOrchestrator _dataOrchestrator;

    //[SetUp]
    public DataOrchestratorTests()
    {
        mockDataRepository = new Mock<IDataRepository>();
        mapper = new Mock<IMapper>();
        _dataOrchestrator = new DataOrchestrator(mockDataRepository.Object,mapper.Object);
    }
}