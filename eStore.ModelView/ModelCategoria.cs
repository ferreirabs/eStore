using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;

namespace eStore.ModelView
{
    [Serializable]
    public class ModelCategoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public int total_produtos { get; set; }
        public List<Categoria> categorias { get; set; }

        public ModelCategoria() {

            categorias = new List<Categoria>();

        }

        /*public ModelCategoria(Categoria categoria)
        {
            this.id = categoria.id;
            this.codigo = categoria.codigo;
            this.nome = categoria.nome;
        }*/
    }
}