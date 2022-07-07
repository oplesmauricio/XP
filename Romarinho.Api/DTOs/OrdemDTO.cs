using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Romarinho.Api.DTOs
{
    public class OrdemDTO
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("data")]
        public DateTime? Data { get; set; }

        [JsonPropertyName("assessor")]
        public string? Assessor { get; set; }

        [JsonPropertyName("conta")]
        public string? Conta { get; set; }

        [JsonPropertyName("ativo")]
        public string? Ativo { get; set; }

        [JsonPropertyName("tipo")]
        public string? Tipo { get; set; }

        [Required]
        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("qtdAparente")]
        public int? QtdAparente { get; set; }

        [JsonPropertyName("qtdDisponivel")]
        public int? QtdDisponivel { get; set; }

        [JsonPropertyName("qtdCancelada")]
        public int? QtdCancelada { get; set; }

        [JsonPropertyName("qtdExecutada")]
        public int? QtdExecutada { get; set; }

        [Required]
        [JsonPropertyName("valor")]
        public float Valor { get; set; }

        [JsonPropertyName("valorDisponivel")]
        public float? ValorDisponivel { get; set; }

        [JsonPropertyName("objetivo")]
        public float? Objetivo { get; set; }

        [JsonPropertyName("objDispon")]
        public float? ObjDispon { get; set; }

        [JsonPropertyName("reducao")]
        public string? Reducao { get; set; }
    }
}

