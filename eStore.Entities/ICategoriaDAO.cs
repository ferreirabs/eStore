using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface ICategoriaDAO
    {
        IEnumerable<Categoria> Listar();
        IEnumerable<Categoria> ListarPorNome(string nome);
        IEnumerable<Categoria> ListarPorCodigo(string codigo);
        bool Criar(Categoria categoria);
        bool Remover(Categoria categoria);
        bool Editar(Categoria categoria, int state);
        bool Salvar(Categoria categoria);
        
    }
}