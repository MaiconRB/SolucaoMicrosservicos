using Microsoft.AspNetCore.Mvc;
using UsuarioService.Application.Services;
using UsuarioService.Core.Entities;

namespace UsuarioService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioServices _usuarioService;

    public UsuarioController(UsuarioServices usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _usuarioService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetById(Guid id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        return usuario == null ? NotFound() : Ok (usuario);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> Create(Usuario usuario)
    {
        await _usuarioService.AddAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Usuario usuario)
    {
        if (id != usuario.Id) return BadRequest();
        
        await _usuarioService.UpdateAsync(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }
}
