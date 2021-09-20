using System;
using System.Collections.Generic;

namespace ProjetoCadastro.Interfaces
{
    public interface IRepositorio<T>
    {
         public void Inserir(T objeto);
         public void Excluir(int id);
         public List<T> Lista();
         public void Alterar(int id, T objeto);
    }
}