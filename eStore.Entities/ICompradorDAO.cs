using System;
namespace eStore.Entities
{
    public interface ICompradorDAO
    {
        bool Create(Comprador comprador);
        System.Collections.Generic.List<Comprador> Listar();
    }
}
