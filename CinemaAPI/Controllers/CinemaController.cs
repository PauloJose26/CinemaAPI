using CinemaAPI.Data;
using CinemaAPI.Data.Dtos;
using CinemaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    [HttpGet]
    public IActionResult ListarCinemas([FromServices] DAL<Cinema> cinemaDAL, [FromQuery] int skip = 0, [FromQuery] int take = 20){
        return Ok(cinemaDAL.Listar(skip, take).Select(cinema => new ReadCinemaDto(cinema)));
    }
    
    [HttpGet("{id}")]
    public IActionResult BuscarCinemaPorId([FromServices] DAL<Cinema> cinemaDAL, int id)
    {
        var cinemaRecuperado = cinemaDAL.BuscarPor(cinema => cinema.Id.Equals(id));
        if (cinemaRecuperado is null)
            return NotFound("Cinema não encontrado");

        return Ok(new ReadCinemaDto(cinemaRecuperado));
    }

    [HttpPost]
    public IActionResult CadastrarCinema([FromServices] DAL<Cinema> cinemaDAL, [FromBody] CreateCinemaDto createCinemaDto)
    {
        var cinema = createCinemaDto.ConverterParaCinema();
        cinemaDAL.Adicionar(cinema);

        return CreatedAtAction(nameof(BuscarCinemaPorId), new { id = cinema.Id }, new ReadCinemaDto(cinema));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCinema([FromServices] DAL<Cinema> cinemaDAL, [FromBody] UpdateCinemaDto updateCinemaDto, int id)
    {
        var cinemaRecuperado = cinemaDAL.BuscarPor(cinema => cinema.Id.Equals(id));
        if (cinemaRecuperado is null)
            return NotFound("Cinema não encontrado");

        updateCinemaDto.AtualizarCinema(cinemaRecuperado);
        cinemaDAL.Atualizar(cinemaRecuperado);

        return NoContent();
    }
    /*
    [HttpPatch("{id}")]
    public IActionResult AtualizarCinemaPatch([FromServices] DAL<Cinema> cinemaDAL, JsonPatchDocument<UpdateCinemaDto> patch, int id)
    {
        var cinemaRecuperado = cinemaDAL.BuscarPor(filme => filme.Id.Equals(id));
        if (cinemaRecuperado is null)
            return NotFound("Cinema não encontrado");

        var updateCinemaDto = UpdateCinemaDto.ConverterParaUpdateCinema(cinemaRecuperado);
        patch.ApplyTo(updateCinemaDto, ModelState);
        if (!TryValidateModel(updateCinemaDto))
            return ValidationProblem(ModelState);

        updateCinemaDto.AtualizarCinema(cinemaRecuperado);
        cinemaDAL.Atualizar(cinemaRecuperado);

        return NoContent();
    }
    */
    [HttpDelete("{id}")]
    public IActionResult DeletarCinema([FromServices] DAL<Cinema> cinemaDAL, int id)
    {
        var cinemaRecuperado = cinemaDAL.BuscarPor(cinema => cinema.Id.Equals(id));
        if (cinemaRecuperado is null)
            return NotFound("Cinema não encontrado");

        cinemaDAL.Deletar(cinemaRecuperado);

        return NoContent();
    }
}
