namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de informa��es de um endere�o.
/// </summary>
public class ReadEnderecoDto
{    
    /// <summary>
    /// Logradouro do endere�o.
    /// </summary>
    public required string Logradouro { get; set; }

    /// <summary>
    /// N�mero do endere�o.
    /// </summary>
    public int Numero { get; set; }

}
