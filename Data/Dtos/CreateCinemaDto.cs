using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para criação de um cinema.
/// </summary>
public class CreateCinemaDto
{
    /// <summary>
    /// Nome do cinema.
    /// </summary>
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public required string Nome { get; set; }

    /// <summary>
    /// Identificador do endereço do cinema.
    /// </summary>
    public int EnderecoId { get; set; }
}
