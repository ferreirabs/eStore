using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using PagedList;

namespace eStore.ModelView
{
    [Serializable]
    public class ModelCategoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public int total_categorias { get; set; }
        public List<Categoria> categorias { get; set; }
        public PagedList<Categoria> categoriasPaged { get; set; }

        public ModelCategoria() {

            categorias = new List<Categoria>();

        }
    }
}