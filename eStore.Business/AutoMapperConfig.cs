using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace eStore.Business
{
    public static class AutoMapperConfig
    {

        public static void ConfigMappings()
        {

            Mapper.CreateMap<Entities.Categoria, ModelView.ModelCategoria>()
               .ReverseMap();

            Mapper.CreateMap<Entities.Produto, ModelView.ModelProduto>()
               .ReverseMap();
            
            Mapper.CreateMap<Entities.Comprador, ModelView.ModelCompradores>()
               .ReverseMap();

            Mapper.CreateMap<Entities.Carrinho, ModelView.ModelCarrinho>()
              .ReverseMap();
        }
    }
}
