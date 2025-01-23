using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para atualiza��o de informa��es de um endere�o.
/// </summary>
public class UpdateEnderecoDto
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
