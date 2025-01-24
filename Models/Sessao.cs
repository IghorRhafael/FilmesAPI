using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

/// <summary>
/// Representa uma sessão de filme.
/// </summary>
public class Sessao
{
    /// <summary>
    /// Identificador do filme associado à sessão.
    /// </summary>
    public int? FilmeId { get; set; }

    /// <summary>
    /// Filme associado à sessão.
    /// </summary>
    public virtual Filme? Filme { get; set; }

    /// <summary>
    /// Identificador do cinema onde a sessão será exibida.
    /// </summary>
    public int? CinemaId { get; set; }

    /// <summary>
    /// Cinema onde a sessão será exibida.
    /// </summary>
    public virtual Cinema? Cinema { get; set; }

    //public DateTime HorarioDeInicio { get; set; }
    //public DateTime HorarioDeEncerramento { get; set; }
    //public List<Venda> Vendas { get; set; }
}
