using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;


namespace FilmesAPI.Profiles;

/// <summary>
/// Profile de mapeamento para Endereco.
/// </summary>
public class EnderecoProfile : Profile
{
    /// <summary>
    /// Configura os mapeamentos entre os DTOs e o modelo Endereco.
    /// </summary>
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
    }
}
