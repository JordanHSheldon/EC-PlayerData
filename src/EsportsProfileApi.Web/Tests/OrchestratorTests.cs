namespace Tests
{
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using EsportsProfileWebApi.DOMAIN;
    using EsportsProfileWebApi.INFRASTRUCTURE;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class OrchestratorTests
    {
        private readonly Mock<IDataRepository> mockDataRepository;
        private readonly DataOrchestrator _dataOrchestrator;

        //[SetUp]
        public OrchestratorTests()
        {
            mockDataRepository = new Mock<IDataRepository>();
            _dataOrchestrator = new DataOrchestrator(mockDataRepository.Object);
        }

        [Test]
        public void GetDataGivenGetDataRequestDTOReturnsGetDataResponseDTO()
        {
            //Arrange
            var request = new GetDataRequestDTO();
            var response = new GetDataResponse();
            mockDataRepository.Setup(test => test.GetData(It.IsAny<GetDataRequestDTO>())).Returns(response);
            
            //Act
            var result = _dataOrchestrator.GetData(request);
            
            //Assert
            Assert.AreEqual(response, result);
        }
    }
}