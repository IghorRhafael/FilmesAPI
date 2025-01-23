using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

/// <summary>
/// Representa um Endereço com suas propriedades.
/// </summary>
public class Endereco
{
    /// <summary>
    /// Identificador único do endereço.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// Logradouro do endereço.
    /// </summary>
    [Required(ErrorMessage = "O logradouro do endereço é obrigatório.")]
    public required string Logradouro { get; set; }
    /// <summary>
    /// Número do endereço.
    /// </summary>
    [Required(ErrorMessage = "O número do endereço é obrigatório.")]
    public required string Numero { get; set; }

    /// <summary>
    /// Complemento do endereço.
    /// </summary>
    public virtual Cinema Cinema { get; set; }
}
