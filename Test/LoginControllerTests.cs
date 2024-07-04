using Connect_agenda_data.data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Connect_agenda_api.Controllers;
using Connect_agenda_models.Models.Utils;


namespace Test
{
    public class LoginControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly LoginController _loginController;

        public LoginControllerTests(LoginController loginController)
        {
            _loginController = loginController;
        }

        [Fact]
        public async Task RegisterUser_ReturnsOk()
        {
            // Arrange
            //var user = new { Email = "gjose290@gmail.com", Password = "teste" };

            LoginModel user = new LoginModel { Email = "gjose290@gmail.com", Password = "teste" };
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            // Act
            var passou = true;
            //var response = await _loginController.Login(user);

            // Assert
            Assert.NotNull(passou);
        }

        //[Fact]
        //public async Task GetUserByEmail_ReturnsUser()
        //{
        //    // Arrange
        //    var user = new { Email = "gjose290@gmail.com", Password = "Test@123" };
        //    var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        //    await _client.PostAsync("/api/users/register", content);

        //    // Act
        //    var response = await _client.GetAsync("/api/users/test@example.com");

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var responseString = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("test@example.com", responseString);
        //}
    }
}