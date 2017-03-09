using eStore.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public interface ICarrinho
    {
        bool Criar(Entities.Carrinho carrinho);
        bool Remover(Entities.Carrinho carrinho);
        bool Remover(int id);
        bool Editar(Entities.Carrinho carrinho, int state);
        bool Editar(ModelView.ModelCarrinho carrinho);
        ModelCarrinho Find(int? id);
        IEnumerable<Entities.Carrinho> Listar();
        ModelCarrinho Listar(int page, int pageSize);
        ModelCarrinho ListarPorFiltro(string valor, string tipo);
        ModelCarrinho Get(List<int?> codigos_produtos);
    }
}