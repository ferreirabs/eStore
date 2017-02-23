using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;

namespace eStore.Business
{
    public interface ICategoria
    {
        bool Create(Entities.Categoria categoria);
        Entities.Categoria Find(int? id);
    }
}