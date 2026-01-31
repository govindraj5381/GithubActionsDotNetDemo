using NUnit.Framework;
using GithubActionsDemo.Controllers;

namespace GithubActionsDemo.Test
{
    public class WeatherForecastControllerTest
    {
        private HttpClient? _client;
        WeatherForecastController? obj;

        [SetUp]
        public void SetUp()
        {
             obj = new WeatherForecastController();

            //_factory = new CustomWebApplicationFactory<Program>();
            //_client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
        }

        [Test]
        public void GetWeatherForecast_ReturnsFiveItems()
        {

            IEnumerable<WeatherForecast> items = obj.Get();
            Assert.IsNotNull(items);
            Assert.AreEqual(5, items!.Count());
        }

        [Test]
        public void GetHourlyForecast_Returns24Items()
        {
            var items = obj.GetHourly();
            Assert.IsNotNull(items);
            Assert.AreEqual(24, items!.Count());
        }

        [Test]
        public async Task GetSummaries_ReturnsSummaries()
        {
            var items = obj.GetSummaries();
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(items!);
        }
    }
}
