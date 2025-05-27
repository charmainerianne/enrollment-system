using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EnrollmentSystem.Tests
{
    public class EndToEndTest : IClassFixture<WebApplicationFactory<EnrollmentSystem.Startup>>
    {
        private readonly HttpClient _client;

        public EndToEndTest(WebApplicationFactory<EnrollmentSystem.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_Student_And_Access_Dashboard()
        {
            // Arrange
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("userId", "student1"),
                new KeyValuePair<string, string>("password", "password123"),
                new KeyValuePair<string, string>("userType", "Student")
            });

            // Act
            var response = await _client.PostAsync("/Account/Login", loginData);
            response.EnsureSuccessStatusCode();

            var dashboardResponse = await _client.GetAsync("/Student/Dashboard");
            dashboardResponse.EnsureSuccessStatusCode();

            var content = await dashboardResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("Student Dashboard", content);
        }

        [Fact]
        public async Task Login_Admin_And_Access_Dashboard()
        {
            // Arrange
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("userId", "admin1"),
                new KeyValuePair<string, string>("password", "adminpass"),
                new KeyValuePair<string, string>("userType", "Admin")
            });

            // Act
            var response = await _client.PostAsync("/Account/Login", loginData);
            response.EnsureSuccessStatusCode();

            var dashboardResponse = await _client.GetAsync("/Admin/Dashboard");
            dashboardResponse.EnsureSuccessStatusCode();

            var content = await dashboardResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("Admin Dashboard", content);
        }
    }
}
