using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioService.Core.Entities;
using UsuarioService.Infrastructure.Data;

namespace UsuarioService.Tests
{
    public class UsuarioIntegrationTests
    {
        [Fact]
        public void AddUser_SavesToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<UsuarioDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            using var context = new UsuarioDbContext(options);
            context.Usuarios.Add(new Usuario { Nome = "Test User", Email = "test@example.com" });
            context.SaveChanges();

            // Act
            var user = context.Usuarios.FirstOrDefault(u => u.Email == "test@example.com");

            // Assert
            Assert.NotNull(user);
            Assert.Equal("Test User", user.Nome);
        }
    }
}
