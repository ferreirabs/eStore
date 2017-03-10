using eStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelPagamento
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public decimal preco_carrinho { get; set; }

        public int total_produtos { get; set; }

        public decimal total_frete { get; set; }

        public decimal total { get; set; }

        public IEnumerable<Produto> lista_produtos { get; set; }

        public string cc_name { get; set; }
        public string cc_emissor { get; set; }
        public string cc_mes  { get; set; }
        public string cc_ano  { get; set; }
        public string cc_number  { get; set; }
        public string cc_cvc { get; set; }
        
        public ModelPagamento() {
            lista_produtos = new List<Produto>();
        }

        public ModelPagamento(Carrinho carrinho)
        {
            this.Id = carrinho.id;
            this.Codigo = carrinho.codigo;
            this.preco_carrinho = 0;
            this.total_produtos = 0;
            this.total_frete = 0;
            lista_produtos  = new List<Produto>();
        }
    }
}