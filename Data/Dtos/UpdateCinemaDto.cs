using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para atualização de informações de um cinema.
/// </summary>
public class UpdateCinemaDto
{
    /// <summary>
    /// Nome do cinema.
    /// </summary>
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public required string Nome { get; set; }
}
