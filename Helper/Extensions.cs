using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Helper;

/// <summary>
/// Classe de extensões.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Obtém uma entidade pelo seu identificador.
    /// </summary>
    /// <typeparam name="T">O tipo da entidade.</typeparam>
    /// <param name="dbSet">O DbSet da entidade.</param>
    /// <param name="id">O identificador da entidade.</param>
    /// <returns>A entidade encontrada ou null se não for encontrada.</returns>
    public static T GetById<T>(this DbSet<T> dbSet, int id) where T : class => dbSet.Find(id);
}
