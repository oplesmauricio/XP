﻿using System;
namespace Romarinho.Domain.Model
{
    public class Ordem
    {
        public Ordem()
        {
        }

        public DateTime Data { get; set; }
        public string Assessor { get; set; }
        public string Conta { get; set; }
        public string Ativo { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public string QtdAparente { get; set; }
        public string QtdDisponivel { get; set; }
        public int QtdCancelada { get; set; }
        public int QtdExecutada { get; set; }
        public float Valor { get; set; }
        public float ValorDisponivel { get; set; }
        public float Objetivo { get; set; }
        public float ObjDispon { get; set; }
        public string Reducao { get; set; }
    }
}
