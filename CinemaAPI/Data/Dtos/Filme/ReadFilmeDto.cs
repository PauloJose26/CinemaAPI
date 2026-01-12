using CinemaAPI.Models;


namespace CinemaAPI.Data.Dtos;

public class ReadFilmeDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }

    public ReadFilmeDto(Filme filme)
    {
        this.Id = filme.Id;
        this.Titulo = filme.Titulo;
        this.Genero = filme.Genero;
        this.Duracao = filme.Duracao;
    }
}
