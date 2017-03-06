using eStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelVitrine
    {
        public IEnumerable<Categoria> categorias { get; set; }
        public IEnumerable<Produto> produtos { get; set; }

        public ModelVitrine() 
        {
            categorias = new List<Categoria>();
            produtos = new List<Produto>();
        
        }
    }
}