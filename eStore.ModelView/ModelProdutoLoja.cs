using eStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelProdutoLoja
    {
        public Produto produto { get; set; }

        public ModelProdutoLoja() 
        {
            produto = new Produto();
        }

    }
}