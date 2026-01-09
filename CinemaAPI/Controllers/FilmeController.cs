using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controller;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    [HttpGet]
    public IActionResult ListarFilmes([FromServices] FilmeDAL filmeDAL, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return Ok(filmeDAL.ListarFilmes(skip, take));
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
    
    [HttpPatch("{id}")]
    public IActionResult EditarFilmeParcial([FromServices] FilmeDAL filmeDAL, JsonPatchDocument<UpdateFilmeDto> patch, int id)
    {
        var filmeReculperado = filmeDAL.BuscarFilmePorId(id);
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        var filmeUpdate = UpdateFilmeDto.ConverterParaUpdateFilme(filmeReculperado);
        patch.ApplyTo(filmeUpdate, ModelState);
        if (!TryValidateModel(filmeUpdate))
            return ValidationProblem(ModelState);

        filmeUpdate.AtualizarFilme(filmeReculperado);
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
