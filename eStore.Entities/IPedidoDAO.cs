using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public interface IPedidoDAO
    {
        int QuantidadePedidos();
        public List<Pedido> ListarPedidos();
        public List<Pedido> ListarPedidosStatus(int status);
    }
}