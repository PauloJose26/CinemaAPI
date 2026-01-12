using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using CinemaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    [HttpGet]
    public IActionResult ListarFilmes([FromServices] DAL<Filme> filmeDAL, [FromQuery] int skip = 0, [FromQuery] int take = 20) 
        => Ok(filmeDAL.Listar(skip, take).Select(filme => new ReadFilmeDto(filme)));

    [HttpGet("buscarPorNome/{titulo}")]
    public IActionResult BuscarFilmePorTitulo([FromServices] DAL<Filme> filmeDAL, string titulo) => 
        Ok(filmeDAL.FiltrarPor(filme => filme.Titulo.Contains(titulo, StringComparison.CurrentCultureIgnoreCase))
            .Select(filme => new ReadFilmeDto(filme)));

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId([FromServices] DAL<Filme> filmeDAL, int id)
    {
        var filmeReculperado = filmeDAL.BuscarPor(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        return Ok(new ReadFilmeDto(filmeReculperado));
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromServices] DAL<Filme> filmeDAL, [FromBody] CreateFilmeDto createFilmeDto)
    {
        var filme = createFilmeDto.ConverterParaFilme();
        filmeDAL.Adicionar(filme);

        return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme.Id }, new ReadFilmeDto(filme));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme([FromServices] DAL<Filme> filmeDAL, [FromBody] UpdateFilmeDto updateFilmeDto, int id)
    {
        var filmeReculperado = filmeDAL.BuscarPor(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        updateFilmeDto.AtualizarFilme(filmeReculperado);
        filmeDAL.Atualizar(filmeReculperado);

        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial([FromServices] DAL<Filme> filmeDAL, JsonPatchDocument<UpdateFilmeDto> patch, int id)
    {
        var filmeReculperado = filmeDAL.BuscarPor(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        var updateFilmeDto = UpdateFilmeDto.ConverterParaUpdateFilme(filmeReculperado);
        patch.ApplyTo(updateFilmeDto, ModelState);
        if (!TryValidateModel(updateFilmeDto))
            return ValidationProblem(ModelState);

        updateFilmeDto.AtualizarFilme(filmeReculperado);
        filmeDAL.Atualizar(filmeReculperado);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme([FromServices] DAL<Filme> filmeDAL, int id)
    {
        var filmeReculperado = filmeDAL.BuscarPor(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        filmeDAL.Deletar(filmeReculperado);

        return NoContent();
    }
}
