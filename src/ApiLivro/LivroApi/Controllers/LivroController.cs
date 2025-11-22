using LivroApi.Dto.Request;
using LivroApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LivroController(ILivroServices livroServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterLivros()
    {
        var livros = await livroServices.ObterTodosLivros();
        if (livros is null)
            return NotFound();

        return Ok(livros);
    }


    [HttpPost]
    public async Task<IActionResult> CriarLivro([FromBody] LivroRequestDto livroDto)
    {
        var livroCriado = await livroServices.Criar(livroDto);
        if (livroCriado is null)
            return BadRequest();

        return CreatedAtAction(nameof(ObterLivros), new { id = livroCriado.Id }, livroCriado);
    }
}
