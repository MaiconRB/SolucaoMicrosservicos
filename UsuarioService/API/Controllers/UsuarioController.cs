using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UsuarioService.Application.Services;
using UsuarioService.Core.Entities;
using UsuarioService.Core.Interfaces;

namespace UsuarioService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly TokenServices _tokenService;

    public UsuarioController(IUsuarioService usuarioService, TokenServices tokenServices)
    {
        _usuarioService = usuarioService;
        _tokenService = tokenServices;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Simulação de autenticação
        if (request.Email == "admin@example.com" && request.Senha == "MinhaSenhaSuperUltraSecreta12345")
        {
            var token = _tokenService.GenerateToken("1", request.Email);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _usuarioService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetById(Guid id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        return usuario == null ? NotFound() : Ok (usuario);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Usuario>> Create(Usuario usuario)
    {
        await _usuarioService.AddAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Usuario usuario)
    {
        if (id != usuario.Id) return BadRequest();
        
        await _usuarioService.UpdateAsync(usuario);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
