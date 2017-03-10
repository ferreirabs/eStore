using eStore.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public interface IPedido
    {
        IEnumerable<Entities.Pedido> Listar();
        IEnumerable<Entities.Pedido> ListarPorComprador(int id);
        bool Criar(Entities.Pedido pedido);
        Entities.Pedido Builder(decimal subtotal, decimal total, int id_comprador, IEnumerable<Entities.Produto> produtos);
        bool AlterarStatus(Entities.Pedido _pedido, int status);

        ModelPedidoManager Listar(int page, int pageSize);
        ModelPedidoManager ListarPorFiltro(string valor, string tipo);

        
    }
}