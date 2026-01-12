using CinemaAPI.Models;


namespace CinemaAPI.Data.Dtos;

public class ReadSessaoDto
{
    public int Id { get; set; }
    public ReadFilmeDto Filme { get; set; }
    public ReadCinemaDto Cinema { get; set; }

    public ReadSessaoDto(Sessao sessao)
    {
        this.Id = sessao.Id;
        this.Filme = new(sessao.Filme);
        this.Cinema = new(sessao.Cinema);
    }
}
