using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controller;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = [
        new("Guerra dos Mundos", "Ficção Científica", 116) { Id = 1 },
        new("Invocação do Mal", "Terror", 112) { Id = 2 },
        new("Avatar", "Aventura", 197) { Id = 3 }
    ];

    private static int count = 4;

    [HttpGet]
    public IActionResult ListarFilmes()
    {
        return Ok(filmes);
    }

    [HttpGet("buscarPorNome/{nome}")]
    public IActionResult BuscarFilmePorTitulo(string nome)
    {
        var filmeRecuperado = filmes.FirstOrDefault(f => f.Titulo.Contains(nome));
        if (filmeRecuperado is null)
            return NotFound();

        return Ok(filmeRecuperado);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId(int id)
    {
        var filmeRecuperado = filmes.FirstOrDefault(f => f.Id.Equals(id));
        if (filmeRecuperado is null)
            return NotFound();

        return Ok(filmeRecuperado);
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] Filme filme)
    {
        filme.Id = count++;
        filmes.Add(filme);
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult EditarFilme([FromBody] Filme filme, int id)
    {
        var filmeRecuperado = filmes.FirstOrDefault(f => f.Id.Equals(id));
        if (filmeRecuperado is null)
            return NotFound();

        filmeRecuperado.Titulo = filme.Titulo;
        filmeRecuperado.Genero = filme.Genero;
        filmeRecuperado.Duracao = filme.Duracao;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filmeRecuperado = filmes.FirstOrDefault(f => f.Id.Equals(id));
        if (filmeRecuperado is null)
            return NotFound();

        filmes.Remove(filmeRecuperado);
        return NoContent();
    }
}
