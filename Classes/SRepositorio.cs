using System;
using System.Collections.Generic;
using ProjetoCadastro.Interfaces;


namespace ProjetoCadastro.Classes
{
    public class SRepositorio:IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

         public void Inserir(Serie serie)
         {
             listaSerie.Add(serie);
         }
         public void Excluir(int id)
         {
             if(id<listaSerie.Count)
             {
                listaSerie.RemoveAt(id);
             }
         }
         public List<Serie> Lista()
         {
             return listaSerie;
         }
         public void Alterar(int id, Serie serie)
         {
             listaSerie[id] = serie;
         }
         public int Proximoid()
         {
             return listaSerie.Count;
         }
         public Serie retornarPorId(int id)
         {
             return listaSerie[id];
         }
    }
}