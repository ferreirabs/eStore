using eStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public class Frete : IFrete
    {
        public List<Frete> Listar()
        {
            List<Frete> fretes = new List<Frete>();
            //return VarianteDao.BuscarOnde<Variante>(x => x.produto_id != idProduto && x.codigo_variante == codigoVariante);
            return fretes;
        }


        public Frete BuscarPorId(int id)
        {
            return new Frete();
        }

        public int TotalFretes()
        {
            FreteDAO p = new FreteDAO();
            return p.NumeroFretes();
        }
    }
}