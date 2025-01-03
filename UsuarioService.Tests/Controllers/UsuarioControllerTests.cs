using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioService.API.Controllers;
using UsuarioService.Application.Services;
using UsuarioService.Core.Interfaces;

namespace UsuarioService.Tests.Controllers
{
    public class UsuarioControllerTests
    {
        [Fact]
        public void GetUser_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var mockUsuarioService = new Mock<IUsuarioService>();
            var mockTokenService = new Mock<TokenServices>();
            var controller = new UsuarioController(mockUsuarioService.Object, mockTokenService.Object);

            var userId = 1;
            var expectedName = "João Silva";

            // Simular o método do TokenService (mock)
            mockTokenService.Setup(service => service.GenerateToken(It.IsAny<string>(), It.IsAny<string>()))
                            .Returns("mockToken");

            // Act
            var result = controller.Login(new UsuarioController.LoginRequest { Email = "email@test.com", Senha = "password" }) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
