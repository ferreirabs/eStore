using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStore.Entities;
using eStore.ModelView;

namespace eStore.Business
{
    public interface IProduto
    {

        bool Criar(Entities.Produto produto);
        bool Remover(Entities.Produto produto);
        bool Remover(int id);
        bool Editar(Entities.Produto produto, int state);
        bool Editar(ModelView.ModelProduto produto);
        ModelProduto Find(int? id);
        IEnumerable<Entities.Produto> Listar();
        ModelProduto Listar(int page, int pageSize);
        ModelProduto ListarPorFiltro(string valor, string tipo);
    }
}
