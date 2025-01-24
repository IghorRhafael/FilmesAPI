using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

/// <summary>
/// Classe de perfil do AutoMapper para mapeamento de objetos relacionados a Cinema.
/// </summary>
public class CinemaProfile : Profile
{
    /// <summary>
    /// Configura os mapeamentos entre os DTOs e o modelo Cinema.
    /// </summary>
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));

    }
}
