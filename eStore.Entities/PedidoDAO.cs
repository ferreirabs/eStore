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
            total = db.Pedido.FirstOrDefault(p => p.id.Equals(1)).id;
            return total;
        }
    }
}