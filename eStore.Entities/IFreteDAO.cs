using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface IFreteDAO
    {
        int NumeroFretes();
        List<Frete> Listar();
    }
}