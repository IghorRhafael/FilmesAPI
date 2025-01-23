using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para cria��o de um endere�o.
/// </summary>
public class CreateEnderecoDto
{
    /// <summary>
    /// Logradouro do endere�o.
    /// </summary>
    [Required(ErrorMessage = "O campo Logradouro � obrigat�rio")]
    public required string Logradouro { get; set; }

    /// <summary>
    /// N�mero do endere�o.
    /// </summary>
    [Required(ErrorMessage = "O campo N�mero � obrigat�rio")]
    public required int Numero { get; set; }

}
