using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempoSimples.Model
{
    public class PrevisaoClima
    {
        public int Id { get; set; }

        [DisplayName("Clima")]
        [Required(ErrorMessage = "Clima é um campo obrigatório")]
        [StringLength(15, ErrorMessage = "O campo clima deve ter no máximo 200 caracteres")]
        public string Clima { get; set;}

        [DisplayName("Temperatura Mínima")]
        [Required(ErrorMessage = "Temperatura Mínima é um campo obrigatório")]
        public decimal TemperaturaMinima { get; set; }

        [DisplayName("Temperatura Máxima")]
        [Required(ErrorMessage = "Temperatura Máxima é um campo obrigatório")]
        public decimal TemperaturaMaxima { get; set; }

        [DisplayName("Data da Previsão")]
        [Required(ErrorMessage = "Data da Previsão é um campo obrigatório")]
        public DateTime DataPrevisao { get; set; }

        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

    }

    public class EnumClima
    {
        public static string Ensoladado = "Ensolarado";
        public static string Nublado = "Nublado";
        public static string Nevoeiro = "Nevoeiro";
        public static string Chuvoso = "Chuvoso";
        public static string ParcialmanteNublado = "Parcialmente Nublado";
    }
}