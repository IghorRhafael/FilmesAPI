using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Helper;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;

/// <summary>
/// Controlador responsável pelas operações relacionadas às sessões.
/// </summary>
[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="SessaoController"/>.
    /// </summary>
    /// <param name="context">Contexto do banco de dados.</param>
    /// <param name="mapper">Mapper para conversão de objetos.</param>
    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma nova sessão.
    /// </summary>
    /// <param name="sessaoDto">Objeto DTO contendo os dados da sessão a ser criada.</param>
    /// <returns>Resposta HTTP indicando o resultado da operação.</returns>
    [HttpPost]
    public IActionResult AddSessao(CreateSessaoDto sessaoDto)
    {
        var sessaoModel = _mapper.Map<Sessao>(sessaoDto);
        _context.Sessoes.Add(sessaoModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSessaoById), new { filmeID = sessaoModel.FilmeId, cinemaId = sessaoModel.CinemaId  }, sessaoModel);
    }

    /// <summary>
    /// Obtém uma lista de sessões com paginação.
    /// </summary>
    /// <param name="skip">Número de sessões a serem ignoradas.</param>
    /// <param name="take">Número de sessões a serem retornadas.</param>
    /// <returns>Lista de sessões dentro do intervalo especificado.</returns>
    public IEnumerable<ReadSessaoDto> GetSessao([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var sessoes = _context.Sessoes
                        .Skip(skip)
                        .Take(take)
                        .ToList();

        return _mapper.Map<List<ReadSessaoDto>>(sessoes);
    }

    /// <summary>
    /// Obtém uma sessão pelo seu identificador.
    /// </summary>
    /// <param name="filmeId">Identificador do filme.</param>
    /// <param name="cinemaId">Identificador do cinema.</param>
    /// <returns>Objeto DTO contendo os dados da sessão encontrada.</returns>
    [HttpGet("{filmeId}/{cinemaId}", Name = "GetSessaoById")]
    public ActionResult<ReadSessaoDto> GetSessaoById(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
        if (sessao == null)
        {
            return NotFound("Sessão não encontrada.");
        }
        var readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(readSessaoDto);
    }
}
