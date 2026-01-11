using CinemaAPI.Models;


namespace CinemaAPI.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public ReadEnderecoDto Endereco { get; set; }

    public ReadCinemaDto(Cinema cinema)
    {
        this.Id = cinema.Id;
        this.Nome = cinema.Nome;
        this.Endereco = new(cinema.Endereco);
    }
}
