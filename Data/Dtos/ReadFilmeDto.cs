using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de informações de um filme.
/// </summary>
public class ReadFilmeDto
{
    /// <summary>
    /// Título do filme.
    /// </summary>
    public required string Titulo { get; set; }

    /// <summary>
    /// Gênero do filme.
    /// </summary>
    public required string Genero { get; set; }

    /// <summary>
    /// Duração do filme em minutos.
    /// </summary>
    public int Duracao { get; set; }

    /// <summary>
    /// Data e hora da consulta.
    /// </summary>
    public DateTime DataConsulta { get; set; } = DateTime.Now;

    /// <summary>
    /// Sessões do filme.
    /// </summary>
    public ICollection<ReadSessaoDto>? Sessoes { get; set; }
}
