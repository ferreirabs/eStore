using eStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelDashBoardManager
    {
        public ModelCategoria categorias { get; set; }
        public ModelProduto produtos { get; set; }
        public ModelCompradores compradores { get; set; }
        public ModelPedidoManager pedidos { get; set; }

        public ModelDashBoardManager() 
        {
            categorias = new ModelCategoria();
            produtos = new ModelProduto();
            compradores = new ModelCompradores();
            pedidos = new ModelPedidoManager();
        
        }

    }
}