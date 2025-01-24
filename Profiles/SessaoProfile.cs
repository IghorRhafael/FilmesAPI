using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

/// <summary>
/// Profile de mapeamento para a entidade Sessao.
/// </summary>
public class SessaoProfile : Profile
{
    /// <summary>
    /// Configura os mapeamentos entre os DTOs e a entidade Sessao.
    /// </summary>
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        //CreateMap<UpdateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
