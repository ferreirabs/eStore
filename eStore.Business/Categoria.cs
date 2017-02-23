using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;

namespace eStore.Business
{
    public class Categoria : ICategoria
    {

        public bool Create(Entities.Categoria categoria)
        {
            try
            {
                CategoriaDAO c = new CategoriaDAO();
                return c.Create(categoria);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
            
        }

        public Entities.Categoria Find(int? id) {

            try
            {
                CategoriaDAO c = new CategoriaDAO();
                return c.Find(id);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }
        
        }
    }
}