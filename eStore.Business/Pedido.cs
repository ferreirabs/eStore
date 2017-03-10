using eStore.Entities;
using eStore.ModelView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public class Pedido : IPedido
    {
        public DicionarioErros msgErro =  new DicionarioErros();

        public Pedido() {
            AutoMapperConfig.ConfigMappings();
        }

        public IEnumerable<Entities.Pedido> Listar()
        {

            try
            {
                PedidoDAO p = new PedidoDAO();
                return p.Listar();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public IEnumerable<Entities.Pedido> ListarPorComprador(int id)
        {
            try
            {
                PedidoDAO p = new PedidoDAO();
                return p.ListarPorComprador(id);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelPedidoManager Listar(int page, int pageSize)
        {
            try
            {
                ModelPedidoManager modelPedido = new ModelPedidoManager();
                PedidoDAO pedidoDAO = new PedidoDAO();
                var LPedidos = pedidoDAO.Listar();
                modelPedido.lista_pedidos = new PagedList<Entities.Pedido>(LPedidos, page, pageSize);
                modelPedido.total_pedidos = modelPedido.lista_pedidos.Count();
                modelPedido.total_amount_pedidos = GetTotalAmountPedidos(LPedidos);

                return modelPedido;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelPedidoManager ListarPorFiltro(string valor, string tipo)
        {
            try
            {
                ModelPedidoManager modelPedido = new ModelPedidoManager();
                PedidoDAO pedidoDAO = new PedidoDAO();

                var LPedidos = ListarPorTipo(valor, tipo, pedidoDAO);
                modelPedido.lista_pedidos = new PagedList<Entities.Pedido>(LPedidos, 1, 10);
                modelPedido.total_pedidos = modelPedido.lista_pedidos.Count();
                modelPedido.total_amount_pedidos = GetTotalAmountPedidos(LPedidos);

                return modelPedido;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        private IEnumerable<Entities.Pedido> ListarPorTipo(string valor, string tipo, PedidoDAO pedidoDAO)
        {
            switch (tipo)
            {
                case "comprador":
                    return pedidoDAO.ListarPorComprador(Int32.Parse(valor));
                default:
                    return pedidoDAO.ListarPorComprador(Int32.Parse(valor));
            }
        }


        public bool Criar(Entities.Pedido pedido)
        {
            try
            {
                PedidoDAO p = new PedidoDAO();
                return p.Criar(pedido);
                
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public Entities.Pedido Builder(decimal subtotal, decimal total, int id_comprador, IEnumerable<Entities.Produto> produtos)
        {
            try
            {
                Entities.Pedido _pedido = new Entities.Pedido();
                _pedido.subtotal = subtotal;
                _pedido.total = total;
                _pedido.data_pedido = DateTime.Now;
                _pedido.status = 1;
                _pedido.data_alteracao = DateTime.Now;
                _pedido.id_comprador = id_comprador;
                _pedido.produtos = produtos;
                //_pedido.pagamento = ;

                return _pedido;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool AlterarStatus(Entities.Pedido _pedido, int status)
        {
            try
            {
                PedidoDAO p = new PedidoDAO();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public decimal GetTotalAmountPedidos(IEnumerable<Entities.Pedido> pedidos)
        {
            decimal total = 0;
            foreach (var item in pedidos)
            {
                total += item.total;

            }
            return total;
        }
    }
}