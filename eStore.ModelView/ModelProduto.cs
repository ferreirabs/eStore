using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace eStore.ModelView
{
    public class ModelProduto
    {
        
        public int Id { get; set; }

        [Display(Name = "Código:", Description = "Identificador do Produto.")]
        public string Codigo { get; set; }
        [Display(Name = "Nome:", Description = "Nome do Produto.")]
        public string Nome { get; set; }
        [Display(Name = "Preço:", Description = "Preço do Produto.")]
        public decimal Preco { get; set; }
        [Display(Name = "Ordem:", Description = "Ordem de exibição.")]
        public int Ordem { get; set; }
        [Display(Name = "Bloqueado:", Description = "Status do produto.")]
        public bool Bloqueado { get; set; }
        [Display(Name = "Estoque:", Description = "Estoque do produto.")]
        public int Estoque { get; set; }
        [Display(Name = "Descricao:", Description = "Descricao do produto.")]
        public string Descricao { get; set; }

        
        
        public int total_produtos { get; set; }
        
        public List<Categoria> Categorias { get; set; }

        public PagedList<Produto> lista_produtos { get; set; }

        public ModelProduto() {
            lista_produtos = new PagedList<Produto>(null,1,1);
        }

        public ModelProduto(Produto produto)
        {
            this.Id         = produto.id;
            this.Codigo     = produto.codigo;
            this.Nome       = produto.nome;
            this.Ordem      = produto.ordem;
            this.Preco      = produto.preco;
            this.Bloqueado  = produto.bloqueado;
            this.Estoque    = produto.estoque;
            this.Descricao  = produto.descricao;
            lista_produtos  = new PagedList<Produto>(null, 1, 1);
        }

    }
}
