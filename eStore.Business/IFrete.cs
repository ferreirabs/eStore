using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public interface IFrete
    {
        List<Frete> Listar();
        Frete BuscarPorId(int id);
        int TotalFretes();
    }
}