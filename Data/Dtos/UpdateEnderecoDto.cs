using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para atualização de informações de um endereço.
/// </summary>
public class UpdateEnderecoDto
{
    /// <summary>
    /// Logradouro do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
    public required string Logradouro { get; set; }

    /// <summary>
    /// Número do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Número é obrigatório")]
    public required int Numero { get; set; }

}
