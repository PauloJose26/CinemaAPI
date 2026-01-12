using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController:ControllerBase
{
    [HttpGet]
    public IActionResult ListarSessoes([FromServices] DAL<Sessao> sessaoDAL, [FromQuery] int skip = 0, [FromQuery] int take = 20)
        => Ok(sessaoDAL.Listar(skip, take).Select(sessao => new ReadSessaoDto(sessao)));

    [HttpGet("{id}")]
    public IActionResult BuscarSessaoPorId([FromServices] DAL<Sessao> sessaoDAL, int id)
    {
        var sessaoRecuperado = sessaoDAL.BuscarPor(sessao => sessao.Id.Equals(id));
        if (sessaoRecuperado is null)
            return NotFound("Sessão não encontrada");

        return Ok(sessaoRecuperado);
    }

    [HttpPost]
    public IActionResult CadastrarSessao([FromServices] DAL<Sessao> sessaoDAL, [FromServices] DAL<Filme> filmeDAL, [FromServices] DAL<Cinema> cinemaDAL, [FromBody] CreateSessaoDto createSessaoDto)
    {
        if (filmeDAL.BuscarPor(filme => filme.Id.Equals(createSessaoDto.FilmeId)) is null)
            return NotFound("Filme não encontrado");
        if(createSessaoDto.CinemaId is not null && cinemaDAL.BuscarPor(cinema => cinema.Id.Equals(createSessaoDto.CinemaId)) is null)
            return NotFound("Cinema não encontrado");

        var sessao = createSessaoDto.ConverterParaSessao();
        sessaoDAL.Adicionar(sessao);
        
        return CreatedAtAction(nameof(BuscarSessaoPorId), new { id = sessao.Id }, new ReadSessaoDto(sessao));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarSessao([FromServices] DAL<Sessao> sessaoDAL, int id)
    {
        var sessaoRecuperado = sessaoDAL.BuscarPor(sessao => sessao.Id.Equals(id));
        if (sessaoRecuperado is null)
            return NotFound("Sessão não encontrada");

        sessaoDAL.Deletar(sessaoRecuperado);

        return NoContent();
    }
}
