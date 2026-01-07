namespace CinemaAPI.Models;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }

    public Filme(string titulo, string genero, int duracao)
    {
        this.Titulo = titulo;
        this.Genero = genero;
        this.Duracao = duracao;
    }
}
