using eStore.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public class CompradorDAO : ICompradorDAO
    {

        eStoreContext db = new eStoreContext();

        public List<Comprador> Listar()
        {
            return db.Comprador.ToList();
        }

        public bool Create(Comprador comprador)
        {
            try
            {
                db.Comprador.Add(comprador);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        
        public Comprador Find(int? id)
        {
            try
            {
                return db.Comprador.Find(id);
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}