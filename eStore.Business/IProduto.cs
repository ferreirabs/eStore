using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStore.Entities;

namespace eStore.Business
{
    public interface IProduto
    {
        
        List<Produto> Listar();
        Produto BuscarPorId(int id);
        int TotalProdutos();
    }
}
