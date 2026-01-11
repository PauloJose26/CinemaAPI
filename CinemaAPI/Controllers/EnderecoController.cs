using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    [HttpGet]
    public IActionResult ListarEndereco([FromServices] DAL<Endereco> enderecoDAL, [FromQuery] int skip = 0, [FromQuery] int take = 20)
        => Ok(enderecoDAL.Listar(skip, take).Select(endereco => new ReadEnderecoDto(endereco)));

    [HttpGet("{id}")]
    public IActionResult BuscarEnderecoPorId([FromServices] DAL<Endereco> enderecoDAL, int id)
    {
        var enderecoRecuperado = enderecoDAL.BuscarPor(endereco => endereco.Id.Equals(id));
        if (enderecoRecuperado is null)
            return NotFound("Endereço não encontrado");

        return Ok(new ReadEnderecoDto(enderecoRecuperado));
    }

    [HttpPost]
    public IActionResult CadastrarEndereco([FromServices] DAL<Endereco> enderecoDAL, [FromBody] CreateEnderecoDto createEnderecoDto)
    {
        var endereco = createEnderecoDto.ConverterParaEndereco();
        enderecoDAL.Adicionar(endereco);

        return CreatedAtAction(nameof(BuscarEnderecoPorId), new { id = endereco.Id }, new ReadEnderecoDto(endereco));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco([FromServices] DAL<Endereco> enderecoDAL, [FromBody] UpdateEnderecoDto updateEnderecoDto, int id)
    {
        var enderecoRecuperado = enderecoDAL.BuscarPor(endereco => endereco.Id.Equals(id));
        if (enderecoRecuperado is null)
            return NotFound("Endereço não encontrado");

        updateEnderecoDto.AtualizarEndereco(enderecoRecuperado);
        enderecoDAL.Atualizar(enderecoRecuperado);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco([FromServices] DAL<Endereco> enderecoDAL, int id)
    {
        var enderecoRecuperado = enderecoDAL.BuscarPor(endereco => endereco.Id.Equals(id));
        if (enderecoRecuperado is null)
            return NotFound("Endereço não encontrado");

        enderecoDAL.Deletar(enderecoRecuperado);

        return NoContent();
    }
}
