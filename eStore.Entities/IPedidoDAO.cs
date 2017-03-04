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
        List<Pedido> Listar();
        List<Pedido> ListarPorStatus(int status);
        List<Pedido> ListarPorComprador(Comprador comprador);
        bool Criar(Pedido pedido);
        bool Editar(Pedido pedido, int state);
        bool Remover(Pedido pedido);
    }
}