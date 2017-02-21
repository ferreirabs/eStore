using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Linq.SqlClient;
using System.Text;
using System.Data.Entity;
using eStore.Entities.Context;

namespace eStore.Entities
{
    public class FreteDAO : IFreteDAO
    {
        eStoreContext db = new eStoreContext();

        public List<Frete> Listar()
        {
            return db.Frete.ToList();
        }
        public int NumeroFretes()
        {
            return 0; //db.Frete.FirstOrDefault(item => item.codigo == "100").id;
            //return db.Produto.Count();
        }
    }
}