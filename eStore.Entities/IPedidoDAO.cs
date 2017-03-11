using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface IPedidoDAO
    {
        int Quantidade();
        int QuantidadePorStatus(int status);
        int QuantidadePorComprador(Comprador comprador);
        //List<Pedido> Listar();
        List<Pedido> ListarPorStatus(int status);
        IEnumerable<Pedido> ListarPorComprador(int id);
        bool Editar(Pedido pedido, int state);
        bool Remover(Pedido pedido);
        IEnumerable<Pedido> Listar();
        bool Criar(Pedido pedido);
        Pedido Get(int id_pedido);
    }
}