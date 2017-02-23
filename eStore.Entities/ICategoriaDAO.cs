using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface ICategoriaDAO
    {
        List<Categoria> Listar();
        bool Create(Categoria categoria);
    }
}