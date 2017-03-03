using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface ICategoriaDAO
    {
        IEnumerable<Categoria> Listar();
        bool Criar(Categoria categoria);
        bool Remover(Categoria categoria);
        bool Editar(Categoria categoria, int state);
    }
}