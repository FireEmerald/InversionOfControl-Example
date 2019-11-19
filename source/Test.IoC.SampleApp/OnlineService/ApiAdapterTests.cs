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

        [TestCase(ApiStatus.Ok, "{ status: success }")]
        [TestCase(ApiStatus.ClientError, "")]
        public void Test__ApiAdapter__GetServiceStatus(ApiStatus expectedStatus, string url)
        {
            // Arrange
            var mockWebClient = new Mock<IWebClient>();
            mockWebClient.Setup(x => x.Request(It.IsAny<string>())).Returns(url);
            TestBase.RegisterMockOf(mockWebClient);

            var apiAdapter = TestBase.Resolve<IApiAdapter>();

            // Act
            ApiStatus status = apiAdapter.GetServiceStatus();

            // Assert
            Assert.AreEqual(expectedStatus, status);
        }
    }
}