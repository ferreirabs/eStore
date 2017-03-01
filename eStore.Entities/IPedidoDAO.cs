using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface IPedidoDAO
    {
        int QuantidadePedidos();
        List<Pedido> ListarPedidos();
        List<Pedido> ListarPedidosStatus(int status);
    }
}