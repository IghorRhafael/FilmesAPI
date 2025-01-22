using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
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

    [HttpPost]
    public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();//Guarda valores na base de dados
        return CreatedAtAction(nameof(GetFilmeByID), new { id = filme.Id }, filme);//retorna o filme criado e o caminho para consulta (Headers / Location)
    }

    [HttpGet]
    public IEnumerable<Filme> GetFilme([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        //retorna a lista de filmes dentro de um intervalo para paginação
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmeByID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        return filme == null ? NotFound() : Ok(filme);//caso filme não exista retorna 404
    }
}
