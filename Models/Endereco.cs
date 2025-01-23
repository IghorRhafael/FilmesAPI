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
    public required string Complemento { get; set; }
    /// <summary>
    /// Bairro do endereço.
    /// </summary>
    [Required(ErrorMessage = "O bairro do endereço é obrigatório.")]
    public required string Bairro { get; set; }
    /// <summary>
    /// Cidade do endereço.
    /// </summary>
    [Required(ErrorMessage = "A cidade do endereço é obrigatória.")]
    public required string Cidade { get; set; }
    /// <summary>
    /// Estado do endereço.
    /// </summary>
    [Required(ErrorMessage = "O estado do endereço é obrigatório.")]
    public required string Estado { get; set; }
    /// <summary>
    /// CEP do endereço.
    /// </summary>
    [Required(ErrorMessage = "O CEP do endereço é obrigatório.")]
    public required string Cep { get; set; }
}
