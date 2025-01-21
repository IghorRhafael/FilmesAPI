using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AddFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);//adiciona filme
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero); 
        Console.WriteLine(filme.Duracao);
    }
}
