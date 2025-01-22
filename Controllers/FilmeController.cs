using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AddFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(GetFilmeByID), new { id = filme.Id}, filme);//retorna o filme criado e o caminho para consulta (Headers / Location)
    }

    [HttpGet]
    public IEnumerable<Filme> GetFilme([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        //retorna a lista de filmes dentro de um intervalo para paginação
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmeByID(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        return filme == null ? NotFound() : Ok(filme);//caso filme não exista retorna 404
    }
}
