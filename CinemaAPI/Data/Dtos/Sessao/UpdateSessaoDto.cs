using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class UpdateSessaoDto
{
    [Required]
    public int FilmeId { get; set; }

    public UpdateSessaoDto(int filmeId)
    {
        this.FilmeId = filmeId;
    }

    public static UpdateSessaoDto ConverterParaUpdateSessao(Sessao sessao) => new(sessao.FilmeId);

    public void AtualizarSessao(Sessao sessao)
    {
        this.FilmeId = sessao.FilmeId;
    }
}
