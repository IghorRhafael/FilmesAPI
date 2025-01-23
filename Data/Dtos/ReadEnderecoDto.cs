namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de informações de um endereço.
/// </summary>
public class ReadEnderecoDto
{    
    /// <summary>
    /// Logradouro do endereço.
    /// </summary>
    public string Logradouro { get; set; }

    /// <summary>
    /// Número do endereço.
    /// </summary>
    public int Numero { get; set; }

    /// <summary>
    /// Bairro do endereço.
    /// </summary>
    public string Bairro { get; set; }

    /// <summary>
    /// Cidade do endereço.
    /// </summary>
    public string Cidade { get; set; }

    /// <summary>
    /// Estado do endereço.
    /// </summary>
    public string Estado { get; set; }
}
