﻿namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de sessão.
/// </summary>
public class ReadSessaoDto
{

    /// <summary>
    /// Filme relacionado a sessao
    /// </summary>
    public int? FilmeId { get; set; }

    /// <summary>
    /// Cinema relacionado a sessao
    /// </summary>
    public int? CinemaId { get; set; }

    // /// <summary>
    // /// Horário de início da sessão.
    // /// </summary>
    // public DateTime HorarioDeInicio { get; set; }

    // /// <summary>
    // /// Horário de encerramento da sessão.
    // /// </summary>
    // public DateTime HorarioDeEncerramento { get; set; }

    // /// <summary>
    // /// Lista de vendas associadas à sessão.
    // /// </summary>
    // public List<Venda> Vendas { get; set; }
}
