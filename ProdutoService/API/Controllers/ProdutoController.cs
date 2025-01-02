using Microsoft.AspNetCore.Mvc;
using ProdutoService.Core.Entities;
using ProdutoService.Core.Interfaces;

namespace ProdutoService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
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


