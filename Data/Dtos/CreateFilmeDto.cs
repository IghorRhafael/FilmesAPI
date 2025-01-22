using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para criação de um filme.
/// </summary>
public class CreateFilmeDto
{
    /// <summary>
    /// Título do filme.
    /// </summary>
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public required string Titulo { get; set; }

    /// <summary>
    /// Gênero do filme.
    /// </summary>
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public required string Genero { get; set; }

    /// <summary>
    /// Duração do filme em minutos.
    /// </summary>
    [Required(ErrorMessage = "A duração do filme é obrigatório")]
    [Range(60, 600, ErrorMessage = "Duração do filme deve ter entre 60 e 600 minutos")]
    public int Duracao { get; set; }
}
