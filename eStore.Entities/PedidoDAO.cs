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
    public class PedidoDAO : IPedidoDAO
    {
        eStoreContext db = new eStoreContext();

        public IEnumerable<Pedido> Listar()
        {
            return db.Pedido.ToList();
        }
        
        public IEnumerable<Pedido> ListarPorComprador(int _id_comprador)
        {
            return db.Pedido.Where(p => p.id_comprador == _id_comprador).ToList();
        }
        

        public int Quantidade()
        {
            int total = 0;
            total = db.Pedido.Count<Pedido>();
            return total;
        }

        public int QuantidadePorStatus(int status)
        {
            try
            {
                return (from p in db.Pedido where p.status == status select p).Count();
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int QuantidadePorComprador(Comprador comprador)
        {
            try
            {
                return 1;//(from p in db.Pedido where p.comprador == comprador select p).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /*public List<Pedido> Listar()
        {
            return db.Pedido.ToList<Pedido>();
        }*/

        public List<Pedido> ListarPorStatus(int status)
        {
            var query = from p in db.Pedido where p.status == status select p;
            return query.ToList<Pedido>();
        }

        /*public List<Pedido> ListarPorComprador(Comprador comprador)
        {
            var query = from p in db.Pedido where p.comprador == comprador select p;
            return query.ToList<Pedido>();
        }*/

        public bool Criar(Pedido pedido)
        {
            try
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool Editar(Pedido pedido, int state)
        {
            try
            {
                db.Entry(pedido).State = (EntityState)state;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remover(Pedido pedido)
        {
            try
            {
                db.Pedido.Remove(pedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        
    
    }
}