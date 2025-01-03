using Microsoft.AspNetCore.Mvc;
using ProdutoService.Core.Entities;
using ProdutoService.Core.Interfaces;

namespace ProdutoService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;
    private readonly UsuarioServiceClient _usuarioServiceClient;

    public ProdutoController(IProdutoService service, UsuarioServiceClient usuarioServiceClient)
    {
        _service = service;
        _usuarioServiceClient = usuarioServiceClient;
    }

    [HttpGet("usuario/{id}")]
    public async Task<IActionResult> GetDonoProduto(int id)
    {
        var userName = await _usuarioServiceClient.GetUsuarioByIdAsync(id);
        return Ok(new { ProductId = id, Owner = userName });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var produtos = await _service.GetAllAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var produto = await _service.GetByIdAsync(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Produto produto)
    {
        await _service.AddAsync(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Produto produto)
    {
        if (id != produto.Id) return BadRequest();
        await _service.UpdateAsync(produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}


