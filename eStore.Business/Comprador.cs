using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;

namespace eStore.Business
{
    public class Comprador : IComprador
    {
        public bool Create(Entities.Comprador comprador)
        {
            try
            {
                CompradorDAO c = new CompradorDAO();
                return c.Create(comprador);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public Entities.Comprador Find(int? id)
        {

            try
            {
                CompradorDAO c = new CompradorDAO();
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