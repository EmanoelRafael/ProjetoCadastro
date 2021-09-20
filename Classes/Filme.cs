using System;
//using ProjetoCadastro.Enum;

namespace ProjetoCadastro.Classes
{
    public class Filme: Midia
    {
        private int duracao {get; set;}
        private bool ativo {get; set;}

        public Filme(int id, string nome, Genero genero, int ano, string descricao, int duracao)
        {
            this.id = id;
            this.nome = nome;
            this.genero = genero;
            this.ano = ano;
            this.descricao = descricao;
            this.duracao = duracao;
            this.ativo = true;
        }

        public override string ToString()
        {
            return $"Nome: {this.nome}" + Environment.NewLine +
            $"Genero: {this.genero}" + Environment.NewLine +
            $"Ano: {this.ano}" + Environment.NewLine +
            $"Duracao(em m): {this.duracao}" + Environment.NewLine +
            $"Descricao: {this.descricao}" + Environment.NewLine;
        }

    }
}