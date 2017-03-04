using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace eStore.ModelView
{
    [Serializable]
    public class ModelCategoria
    {
        public int Id { get; set; }
        [Display(Name = "Código:", Description = "Identificador da categoria.")]
        public string Codigo { get; set; }
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }
        [Display(Name = "Bloqueado?")]
        public bool Bloqueado { get; set; }
        public int total_categorias { get; set; }
        
        public PagedList<Categoria> lista_categorias { get; set; }

        public ModelCategoria() {
            lista_categorias = new PagedList<Categoria>(null,1,1);
        }

        public ModelCategoria(Categoria categoria)
        {
            this.Id = categoria.id;
            this.Codigo = categoria.codigo;
            this.Nome = categoria.nome;
            this.Descricao = categoria.descricao;
            this.Bloqueado = categoria.bloqueado;
            lista_categorias = new PagedList<Categoria>(null, 1, 1);
        }

    }
    
}