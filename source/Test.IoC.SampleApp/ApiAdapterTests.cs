using IoC.SampleApp.OnlineService;
using IoC.SampleApp.OnlineService.WebClient;
using Moq;
using NUnit.Framework;

namespace Test.IoC.SampleApp
{
    public class ApiAdapterTests
    {
        private TestBase TestBase;

        [SetUp]
        public void Setup()
        {
            TestBase = new TestBase();
        }

        [TestCase(ApiStatus.Ok, "{ status: success }")]
        [TestCase(ApiStatus.ClientError, "")]
        public void Test__GetServiceStatus(ApiStatus expectedStatus, string url)
        {
            TestContext.WriteLine($"Executing test '{url}'.");

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