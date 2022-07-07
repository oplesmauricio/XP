using System;
namespace Romarinho.Domain.Model
{
    public class Ordem
    {
        public Ordem()
        {
        }

        public int      Id              { get; set; }
        public DateTime Data            { get; set; }
        public string   Assessor        { get; set; }
        public string   Conta           { get; set; }
        public string   Ativo           { get; set; }
        public string   Tipo            { get; set; }
        public int      Quantidade      { get; set; }
        public int      QtdAparente     { get; set; }
        public int      QtdDisponivel   { get; set; }
        public int      QtdCancelada    { get; set; }
        public int      QtdExecutada    { get; set; }
        public float    Valor           { get; set; }
        public float    ValorDisponivel { get; set; }
        public float    Objetivo        { get; set; }
        public float    ObjDispon       { get; set; }
        public string   Reducao         { get; set; }
        public int      IdUsuario       { get; set; }
    }
}

//", Data           " +
//", Assessor       " +
//", Conta          " +
//", Ativo          " +
//", Tipo           " +
//", Quantidade     " +
//", QtdAparente    " +
//", QtdDisponivel  " +
//", QtdCancelada   " +
//", QtdExecutada   " +
//", Valor          " +
//", ValorDisponivel" +
//", Objetivo       " +
//", ObjDispon      " +
//", Reducao        " +

//CREATE TABLE IF NOT EXISTS Ordem (
//Id                 int AUTO_INCREMENT PRIMARY KEY     ,
//Data               Datetime                           ,
//Assessor           Varchar(50) NOT NULL,
//Conta              Varchar(50) NOT NULL,
//Ativo              Varchar(50) NOT NULL,
//Tipo               Varchar(50) NOT NULL,
//Quantidade         int                                ,
//QtdAparente        int                                ,
//QtdDisponivel      int                                ,
//QtdCancelada       int                                ,
//QtdExecutada       int                                ,
//Valor              float                                ,
//ValorDisponivel    float                                ,
//Objetivo           Varchar(50) NOT NULL,
//ObjDispon          Varchar(50) NOT NULL,
//Reducao            Varchar(50) NOT NULL
//);