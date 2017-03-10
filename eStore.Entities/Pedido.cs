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

        
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public DateTime data_pedido { get; set; }
        public int status { get; set; }
        public DateTime data_alteracao { get; set; }
        public int id_comprador { get; set; }
        public IEnumerable<Produto> produtos { get; set;}
        //public MetodoPagamento pagamento { get; set; }

    }

    /*public class MetodoPagamento
    {
        public string cc_name { get; set; }
        public string cc_emissor { get; set; }
        public string cc_mes { get; set; }
        public string cc_ano { get; set; }
        public string cc_number { get; set; }
        public string cc_cvc { get; set; }

    }*/

}