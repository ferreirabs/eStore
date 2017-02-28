using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Linq.SqlClient;
using System.Text;
using System.Data.Entity;
using eStore.Entities.Context;

namespace eStore.Entities
{
    public class PedidoDAO : IPedidoDAO
    {
        eStoreContext db = new eStoreContext();

        public int QuantidadePedidos()
        {
            int total = 0;
            total = db.Pedido.Count<Pedido>();
            return total;
        }

        public List<Pedido> ListarPedidos()
        {
            return db.Pedido.ToList<Pedido>();
        }

        public List<Pedido> ListarPedidosStatus(int status)
        {
            var query = from p in db.Pedido where p.status == status select p;
            return query.ToList<Pedido>();
        }
    }
}