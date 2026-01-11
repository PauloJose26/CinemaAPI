using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Data.Dtos;

public class UpdateEnderecoDto
{
    [Required(ErrorMessage = "O campo logradouro de Endereço é obrigatório")]
    public string Logradouro { get; set; }

    public int? Numero { get; set; }

    public UpdateEnderecoDto(string  logradouro, int? numero)
    {
        this.Logradouro = logradouro;
        this.Numero = numero;
    }

    public static UpdateEnderecoDto ConverterParaUpdateEndereco(Endereco endereco) => new(endereco.Logradouro, endereco.Numero);

    public void AtualizarEndereco(Endereco endereco)
    {
        endereco.Logradouro = this.Logradouro;
        endereco.Numero = (this.Numero is not null) ? this.Numero: endereco.Numero;
    }
}
