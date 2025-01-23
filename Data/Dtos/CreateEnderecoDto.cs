using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para criação de um endereço.
/// </summary>
public class CreateEnderecoDto
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

    /// <summary>
    /// Bairro do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Bairro é obrigatório")]
    public required string Bairro { get; set; }

    /// <summary>
    /// Cidade do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Cidade é obrigatório")]
    public required string Cidade { get; set; }

    /// <summary>
    /// Estado do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Estado é obrigatório")]
    public required string Estado { get; set; }
}
