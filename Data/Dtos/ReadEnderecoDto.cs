namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de informações de um endereço.
/// </summary>
public class ReadEnderecoDto
{    
    /// <summary>
    /// Logradouro do endereço.
    /// </summary>
    public required string Logradouro { get; set; }

    /// <summary>
    /// Número do endereço.
    /// </summary>
    public int Numero { get; set; }

}
