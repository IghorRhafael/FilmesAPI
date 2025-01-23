using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Helper;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a cinemas.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor do CinemaController.
    /// </summary>
    /// <param name="context">context de cinemas.</param>
    /// <param name="mapper">Mapper para conversão de objetos.</param>
    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria um novo cinema.
    /// </summary>
    /// <param name="cinemaDto">Dados para criação do cinema.</param>
    /// <returns>Resultado da criação do cinema.</returns>
    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        try
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            //return CreatedAtAction(nameof(GetCinemaById), new { id = cinema.Id }, cinema);
            return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinemaDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retorna uma lista de cinemas com paginação
    /// </summary>
    /// <param name="skip">Número de cinemas a pular</param>
    /// <param name="take">Número de cinemas a retornar</param>
    /// <returns>Lista de cinemas</returns>
    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetCinemas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        //retorna a lista de cinemas dentro de um intervalo para paginação
        var cinemas = _context.Cinemas
                        .Include(c => c.Endereco) // Certifique-se de incluir a propriedade de navegação
                        .Skip(skip)
                        .Take(take)
                        .ToList();

        return _mapper.Map<List<ReadCinemaDto>>(cinemas);

    }

    /// <summary>
    /// Obtém um cinema pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador do cinema.</param>
    /// <returns>Dados do cinema encontrado.</returns>
    [HttpGet("{id}", Name = "GetCinemaById")]
    public IActionResult GetCinemaById(int id)
    {
        Cinema cinema = _context.Cinemas.GetById(id);
        if (cinema is not null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound("Cinema não encontrado.");
    }

    /// <summary>
    /// Atualiza as informações de um cinema existente.
    /// </summary>
    /// <param name="id">Identificador do cinema.</param>
    /// <param name="updateCinemaDto">Dados para atualização do cinema.</param>
    /// <returns>Resultado da atualização.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
    {
        Cinema cinema = _context.Cinemas.GetById(id);
        if (cinema is null)
        {
            return NotFound("Cinema não encontrado.");
        }
        _mapper.Map(updateCinemaDto, cinema);
        //_context.Update(cinema);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Exclui um cinema pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador do cinema.</param>
    /// <returns>Resultado da exclusão.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        Cinema cinema = _context.Cinemas.GetById(id);
        if (cinema is null)
        {
            return NotFound("Cinema não encontrado.");
        }
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
