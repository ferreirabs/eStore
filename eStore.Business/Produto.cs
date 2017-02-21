using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using System.Data.Entity;

namespace eStore.Business
{
    public class Produto : IProduto
    {
        public List<Produto> Listar() {

            List<Produto> produtos = new List<Produto>();
            //return VarianteDao.BuscarOnde<Variante>(x => x.produto_id != idProduto && x.codigo_variante == codigoVariante);
            return produtos;

        }


        public Produto BuscarPorId(int id) {

            return new Produto();
        
        }

        public int TotalProdutos() {
            
            ProdutoDAO p = new ProdutoDAO();
            return p.NumeroProdutos();
        }
    }
}