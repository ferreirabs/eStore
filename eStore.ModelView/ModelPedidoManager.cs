using eStore.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelPedidoManager
    {
        [Display(Name = "Código:")]
        public int Id { get; set; }
        
        [Display(Name = "SubTotal:")]
        public decimal Subtotal { get; set; }
        [Display(Name = "Total:")]
        public decimal Total { get; set; }
        [Display(Name = "Data do Pedido:")]
        public DateTime Data_pedido { get; set; }
        [Display(Name = "Status:")]
        public int Status { get; set; }
        [Display(Name = "Data de Alteração:")]
        public DateTime Data_alteracao { get; set; }

        public int total_pedidos { get; set; }

        public decimal total_amount_pedidos { get; set; }

        public PagedList<Pedido> lista_pedidos { get; set; }

        public ModelPedidoManager() {
            lista_pedidos = new PagedList<Pedido>(null, 1, 1);
        }

        public ModelPedidoManager(Pedido pedido)
        {
            this.Id = pedido.id;
            this.Subtotal = pedido.subtotal;
            this.Data_pedido = pedido.data_pedido;
            this.Status = pedido.status;
            this.Data_alteracao = pedido.data_alteracao;
            this.total_amount_pedidos = 0;
            lista_pedidos = new PagedList<Pedido>(null, 1, 1);
        }
    }
}