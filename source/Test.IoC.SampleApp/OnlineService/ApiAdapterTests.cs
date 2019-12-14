using IoC.SampleApp.OnlineService;
using IoC.SampleApp.OnlineService.WebClient;
using Moq;
using NUnit.Framework;

namespace Test.IoC.SampleApp.OnlineService
{
    public class ApiAdapterTests
    {
        // Advanced test setup using TestBase component
        private TestBase TestBase;

        [SetUp]
        public void Setup()
        {
            // Called before each TestCase
            TestBase = new TestBase();
        }

        [TestCase("{ status: success }", ApiStatus.Ok)]
        [TestCase("", ApiStatus.ClientError)]
        public void Test__ApiAdapter__GetServiceStatus(string returnedStatus, ApiStatus expectedStatus)
        {
            // Arrange
            var mockWebClient = new Mock<IWebClient>();
            mockWebClient.Setup(client => client.Request(It.IsAny<string>())).Returns(returnedStatus);
            TestBase.RegisterMockOf(mockWebClient);

            var apiAdapter = TestBase.Resolve<IApiAdapter>();

            // Act
            ApiStatus status = apiAdapter.GetServiceStatus();

            // Assert
            Assert.AreEqual(expectedStatus, status);
        }
    }
}