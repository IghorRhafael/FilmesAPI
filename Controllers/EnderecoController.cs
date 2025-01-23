using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Helper;

namespace FilmesAPI.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a endereços.
/// </summary>
[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="EnderecoController"/>.
    /// </summary>
    /// <param name="context">Contexto do banco de dados.</param>
    /// <param name="mapper">Mapper para conversão de objetos.</param>
    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria um novo endereço.
    /// </summary>
    /// <param name="enderecoDto">Dados do endereço a ser criado.</param>
    /// <returns>Resposta HTTP indicando o resultado da operação.</returns>
    [HttpPost]
    public IActionResult AddEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        var endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Add(endereco);
        _context.SaveChanges();
        var enderecoReadDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return CreatedAtAction(nameof(GetEnderecoById), new { endereco.Id }, enderecoReadDto);
    }

    /// <summary>
    /// Obtém um endereço pelo ID.
    /// </summary>
    /// <param name="id">ID do endereço.</param>
    /// <returns>Resposta HTTP com os dados do endereço.</returns>
    [HttpGet("{id}", Name = "GetById")]
    public IActionResult GetEnderecoById(int id)
    {
        var endereco = _context.Enderecos.GetById(id);
        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }
        var enderecoReadDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoReadDto);
    }

    /// <summary>
    /// Atualiza um endereço existente.
    /// </summary>
    /// <param name="id">ID do endereço a ser atualizado.</param>
    /// <param name="enderecoDto">Novos dados do endereço.</param>
    /// <returns>Resposta HTTP indicando o resultado da operação.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.GetById(id);
        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Exclui um endereço pelo ID.
    /// </summary>
    /// <param name="id">ID do endereço a ser excluído.</param>
    /// <returns>Resposta HTTP indicando o resultado da operação.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteEndereco(int id)
    {
        var endereco = _context.Enderecos.GetById(id);
        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
