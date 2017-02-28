using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface ICategoriaDAO
    {
        IEnumerable<Categoria> Listar();
        bool Create(Categoria categoria);
    }
}