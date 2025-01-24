using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

/// <summary>
/// Contexto do banco de dados para a aplicação de filmes.
/// </summary>
public class FilmeContext : DbContext
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="FilmeContext"/>.
    /// </summary>
    /// <param name="opts">Opções para o contexto do banco de dados.</param>
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {

    }

    /// <summary>
    /// Conjunto de dados que representa os filmes no banco de dados.
    /// </summary>
    public DbSet<Filme> Filmes { get; set; }
    
    /// <summary>
    /// Conjunto de dados que representa os cinemas no banco de dados.
    /// </summary>
    public DbSet<Cinema> Cinemas { get; set; }

    /// <summary>
    /// Conjunto de dados que representa os endereços no banco de dados.
    /// </summary>
    public DbSet<Endereco> Enderecos { get; set; }

    /// <summary>
    /// Conjunto de dados que representa as sessões no banco de dados.
    /// </summary>
    public DbSet<Sessao> Sessoes { get; set; }
}
