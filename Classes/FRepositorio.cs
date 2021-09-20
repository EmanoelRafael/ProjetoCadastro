using System;
using System.Collections.Generic;
using ProjetoCadastro.Interfaces;

namespace ProjetoCadastro.Classes
{
    public class FRepositorio:IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();

         public void Inserir(Filme filme)
         {
             listaFilme.Add(filme);
         }
         public void Excluir(int id)
         {
            listaFilme.RemoveAt(id);
         }
         public List<Filme> Lista()
         {
             return listaFilme;
         }
         public void Alterar(int id, Filme filme)
         {
             listaFilme[id] = filme;
         }
         public int Proximoid()
         {
             return listaFilme.Count;
         }

         public Filme retornarPorId(int id)
         {
             return listaFilme[id];
         }
    }
}