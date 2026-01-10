using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class CreateEnderecoDto
{
    [Required(ErrorMessage = "O campo logradouro de Endereço é obrigatório")]
    public string Logradouro { get; set; }

    public int? Numero { get; set; }

    public Endereco ConverterParaEndereco() => new(this.Logradouro, this.Numero);
}
