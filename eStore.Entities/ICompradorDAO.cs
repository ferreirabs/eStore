using System;
using System.Collections.Generic;
namespace eStore.Entities
{
    public interface ICompradorDAO
    {
        bool Create(Comprador comprador);
        List<Comprador> Listar();
    }
}
