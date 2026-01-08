using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controller;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    [HttpGet]
    public IActionResult ListarFilmes([FromServices] FilmeDAL filmeDAL)
    {
        return Ok(filmeDAL.ListarFilmes());
    }

    [HttpGet("buscarPorNome/{titulo}")]
    public IActionResult BuscarFilmePorTitulo([FromServices] FilmeDAL filmeDAL, string titulo)
    {
        return Ok(filmeDAL.BuscarFilmesPorTitulo(titulo));
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId([FromServices] FilmeDAL filmeDAL, int id)
    {
        var filmeReculperado = filmeDAL.BuscarFilmePorId(id);
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        return Ok(filmeReculperado);
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromServices] FilmeDAL filmeDAL, [FromBody] CreateFilmeDto createFilmeDto)
    {
        var filme = createFilmeDto.ConverterFilme();
        filmeDAL.AdicionarFilme(filme);

        return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpPut("{id}")]
    public IActionResult EditarFilme([FromServices] FilmeDAL filmeDAL, [FromBody] UpdateFilmeDto updateFilmeDto, int id)
    {
        var filmeReculperado = filmeDAL.BuscarFilmePorId(id);
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        updateFilmeDto.AtualizarFilme(filmeReculperado);
        filmeDAL.AtualizarFilme(filmeReculperado);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme([FromServices] FilmeDAL filmeDAL, int id)
    {
        var filmeReculperado = filmeDAL.BuscarFilmePorId(id);
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        filmeDAL.DeletarFilme(filmeReculperado);

        return NoContent();
    }
}
