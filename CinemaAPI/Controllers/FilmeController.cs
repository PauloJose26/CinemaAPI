using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controller;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly CinemaContext _context;

    public FilmeController(CinemaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ListarFilmes()
    {
        return Ok(_context.Filmes.ToList());
    }

    [HttpGet("buscarPorNome/{titulo}")]
    public IActionResult BuscarFilmePorTitulo(string titulo)
    {
        var filmeReculperado = _context.Filmes.FirstOrDefault(filme => filme.Titulo.ToLower().Contains(titulo.ToLower()));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        return Ok(filmeReculperado);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId(int id)
    {
        var filmeReculperado = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        return Ok(filmeReculperado);
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] CreateFilmeDto createFilmeDto)
    {
        var filme = createFilmeDto.ConverterFilme();
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpPut("{id}")]
    public IActionResult EditarFilme([FromBody] UpdateFilmeDto filmeRequest, int id)
    {
        var filmeReculperado = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        filmeRequest.AtualizarFilme(filmeReculperado);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filmeReculperado = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filmeReculperado is null)
            return NotFound("Filme não encontrado");

        _context.Filmes.Remove(filmeReculperado);
        _context.SaveChanges();

        return NoContent();
    }
}
