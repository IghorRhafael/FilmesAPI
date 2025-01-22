using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Guarda um filme
    /// </summary>
    /// <param name="filmeDto"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();//Guarda valores na base de dados
        return CreatedAtAction(nameof(GetFilmeByID), new { id = filme.Id }, filme);//retorna o filme criado e o caminho para consulta (Headers / Location)
    }

    /// <summary>
    /// Retorna lista de todos os filmes com paginação
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Filme> GetFilme([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        //retorna a lista de filmes dentro de um intervalo para paginação
        return _context.Filmes.Skip(skip).Take(take);
    }

    /// <summary>
    /// Consulta filme por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetFilmeByID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        return filme == null ? NotFound() : Ok(filme);//caso filme não exista retorna 404
    }

    /// <summary>
    /// Atualiza todos os campos do filme
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filmeDto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>filme.Id == id);
        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza somente o campo enviado
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patch"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult UpdateFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        //valida que os dados passado corresponde a estrutura Dto
        if(!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }
}
