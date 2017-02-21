using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public class Pedido
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "O id deve ser numérico")]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O subtotal do pedido é obrigatório")]
        public decimal subtotal { get; set; }

        [Required(ErrorMessage = "O total do pedido é obrigatório")]
        public decimal total { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória")]
        public DateTime data_pedido { get; set; }

        public int status { get; set; }

        public DateTime data_alteracao { get; set; }

        //[Required(ErrorMessage = "O código do comprador é obrigatório")]
        //public Comprador comprador { get; set; }

        //[Required(ErrorMessage = "O código do método de pagamento é obrigatório")]
        //public MetodoPagamento metodo_pagamento { get; set; }

        //[Required(ErrorMessage = "O código do transportadora é obrigatório")]
        //public Transportadora transportadora { get; set; }
    }
}