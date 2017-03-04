using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Entities
{
    public interface IProdutoDAO
    {
        IEnumerable<Produto> Listar();
        IEnumerable<Produto> ListarPorNome(string nome);
        IEnumerable<Produto> ListarPorCodigo(string codigo);
        bool Criar(Produto produto);
        bool Remover(Produto produto);
        bool Editar(Produto produto, int state);
        bool Salvar(Produto produto);
    }
}
