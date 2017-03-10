using eStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelPedidoLoja
    {
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
        
        public int Id_comprador { get; set; }
        
        public Comprador comprador { get; set; }
        
        public IEnumerable<Produto> produtos { get; set; }


        
        public ModelPedidoLoja() {
            //produtos = new IEnumerable<Produto>();
        }

        public ModelPedidoLoja(Pedido pedido)
        {
            this.Id = pedido.id;
            this.Subtotal = pedido.subtotal;
            this.Data_pedido       = pedido.data_pedido;
            this.Status      = pedido.status;
            this.Data_alteracao      = pedido.data_alteracao;
            this.Id_comprador  = pedido.id_comprador;
            this.produtos    = pedido.produtos;
            this.comprador = new Comprador();
        }

    }
}