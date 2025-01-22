using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

/// <summary>
/// Classe de perfil do AutoMapper para mapeamento de objetos relacionados a filmes.
/// </summary>
public class FilmeProfile : Profile
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="FilmeProfile"/>.
    /// Configura os mapeamentos entre os DTOs e o modelo de filme.
    /// </summary>
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
