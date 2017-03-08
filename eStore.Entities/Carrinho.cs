using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    [Serializable]
    public class Carrinho
    {
        [Key]
        public int id { get; set; }

        public string codigo { get; set; }
        public string codigo_comprador { get; set; }
        public List<Produto> produtos { get; set; }
        public Frete FretePagamento { get; set; }
        public Frete FreteEntrega { get; set; }

    }
}