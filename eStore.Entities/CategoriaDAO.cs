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
    public class CategoriaDAO : ICategoriaDAO
    {
        eStoreContext db = new eStoreContext();

        public List<Categoria> Listar()
        {
            return db.Categoria.ToList();
        }

        public bool Create(Categoria categoria) 
        {
            try
            {
                db.Categoria.Add(categoria);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
            
        }

        public Categoria Find(int? id)
        {
            try
            {
                return db.Categoria.Find(id);
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}