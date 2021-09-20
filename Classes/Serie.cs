using System;
//using ProjetoCadastro.Enum;

namespace ProjetoCadastro.Classes
{
    public class Serie:Midia
    {
        private int temporadas {get; set;}
        private bool ativo {get; set;}

        public Serie(int id, string nome, Genero genero, int ano, string descricao, int temporadas)
        {
            this.id = id;
            this.nome = nome;
            this.genero = genero;
            this.ano = ano;
            this.descricao = descricao;
            this.temporadas = temporadas;
            this.ativo = true;
        }

        public override string ToString()
        {
            return $"Nome: {this.nome}" + Environment.NewLine +
            $"Genero: {this.genero}" + Environment.NewLine +
            $"Ano: {this.ano}" + Environment.NewLine +
            $"Numero de Temporadas: {this.temporadas}" + Environment.NewLine +
            $"Descricao: {this.descricao}" + Environment.NewLine;
        }

    }
}