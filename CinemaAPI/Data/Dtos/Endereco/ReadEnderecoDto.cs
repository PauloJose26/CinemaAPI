using CinemaAPI.Models;


namespace CinemaAPI.Data.Dtos;

public class ReadEnderecoDto
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int? Numero { get; set; }

    public ReadEnderecoDto(Endereco endereco)
    {
        this.Id = endereco.Id;
        this.Logradouro = endereco.Logradouro;
        this.Numero = endereco.Numero;
    }
}
