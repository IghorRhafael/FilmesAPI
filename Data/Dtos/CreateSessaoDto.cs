namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para criação de uma sessão.
/// </summary>
public class CreateSessaoDto
{
    /// <summary>
    /// Identificador do filme.
    /// </summary>
    public int FilmeId { get; set; }

    /// <summary>
    /// Identificador do cinema.
    /// </summary>
    public int CinemaId { get; set; }

    //public DateTime HorarioDeInicio { get; set; }
    //public DateTime HorarioDeEncerramento { get; set; }
    //public List<Venda> Vendas { get; set; }
}
