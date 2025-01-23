using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Helper;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

/// <summary>
/// Controller filme
/// </summary>
[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Guarda um filme
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();//Guarda valores na base de dados
        return CreatedAtAction(nameof(GetFilmeByID), new { id = filme.Id }, filme);//retorna o filme criado e o caminho para consulta (Headers / Location)
    }

    /// <summary>
    /// Retorna uma lista de filmes com paginação
    /// </summary>
    /// <param name="skip">Número de filmes a pular</param>
    /// <param name="take">Número de filmes a retornar</param>
    /// <returns>Lista de filmes</returns>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetFilme([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        //retorna a lista de filmes dentro de um intervalo para paginação
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um filme pelo ID
    /// </summary>
    /// <param name="id">ID do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso o filme seja encontrado</response>
    /// <response code="404">Caso o filme não seja encontrado</response>
    [HttpGet("{id}")]
    public IActionResult GetFilmeByID(int id)
    {
        var filme = _context.Filmes.GetById(id);
        if (filme is not null)
        {
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }
        return NotFound();

    }

    /// <summary>
    /// Atualiza um filme pelo ID
    /// </summary>
    /// <param name="id">ID do filme</param>
    /// <param name="filmeDto">Objeto com os campos necessários para atualização de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Caso o filme não seja encontrado</response>
    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.GetById(id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza parcialmente um filme pelo ID
    /// </summary>
    /// <param name="id">ID do filme</param>
    /// <param name="patch">Objeto com os campos a serem atualizados</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Caso o filme não seja encontrado</response>
    [HttpPatch("{id}")]
    public IActionResult UpdateFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.GetById(id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        //valida que os dados passado corresponde a estrutura Dto
        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um filme pelo ID
    /// </summary>
    /// <param name="id">ID do filme a ser deletado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a deleção seja feita com sucesso</response>
    /// <response code="404">Caso o filme não seja encontrado</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme = _context.Filmes.GetById(id);
        if (filme == null) return NotFound();

        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
