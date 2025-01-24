namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de informações de um cinema.
/// </summary>
public class ReadCinemaDto
{
    /// <summary>
    /// Identificador único do cinema.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do cinema.
    /// </summary>
    public required string Nome { get; set; }

    /// <summary>
    /// Endereço do cinema.
    /// </summary>
    public required ReadEnderecoDto Endereco { get; set; }

    /// <summary>
    /// Sessões do cinema.
    /// </summary>
    public ICollection<ReadSessaoDto>? Sessoes { get; set; }
}
