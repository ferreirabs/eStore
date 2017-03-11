using eStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelEditPedidoManager
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

        public Entities.Pedido pedido { get; set; }
        public Entities.Comprador comprador { get; set; }

        public ModelEditPedidoManager()
        {
            pedido = new Entities.Pedido();
            comprador = new Entities.Comprador();
        }


    }
}