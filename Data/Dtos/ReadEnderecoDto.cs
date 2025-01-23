namespace FilmesAPI.Data.Dtos;

/// <summary>
/// DTO para leitura de informa��es de um endere�o.
/// </summary>
public class ReadEnderecoDto
{    
    /// <summary>
    /// Logradouro do endere�o.
    /// </summary>
    public string Logradouro { get; set; }

    /// <summary>
    /// N�mero do endere�o.
    /// </summary>
    public int Numero { get; set; }

    /// <summary>
    /// Bairro do endere�o.
    /// </summary>
    public string Bairro { get; set; }

    /// <summary>
    /// Cidade do endere�o.
    /// </summary>
    public string Cidade { get; set; }

    /// <summary>
    /// Estado do endere�o.
    /// </summary>
    public string Estado { get; set; }
}
