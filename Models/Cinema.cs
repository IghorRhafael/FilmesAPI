using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

/// <summary>
/// Representa um cinema.
/// </summary>
public class Cinema
{
    /// <summary>
    /// Identificador único do cinema.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Nome do cinema.
    /// </summary>
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public required string Nome { get; set; }
}
