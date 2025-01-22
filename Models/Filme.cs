﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public required string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public required string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatório")]
    [Range(60,600, ErrorMessage = "Duração do filme deve ter entre 60 e 600 minutos")]
    public int Duracao { get; set; }
    
}
