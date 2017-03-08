using eStore.Entities.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public class CarrinhoDAO : ICarrinhoDAO
    {
        eStoreContext db = new eStoreContext();

        public IEnumerable<Carrinho> Listar()
        {
            return db.Carrinho.ToList();
        }

        public IEnumerable<Carrinho> ListarPorCodigo(string codigo)
        {
            return db.Carrinho.Where(c => c.codigo.Contains(codigo)).ToList();
        }

        public bool Criar(Carrinho carrinho)
        {
            try
            {
                db.Carrinho.Add(carrinho);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Remover(Carrinho carrinho)
        {
            try
            {
                db.Carrinho.Remove(carrinho);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Editar(Carrinho carrinho, int state)
        {
            try
            {
                db.Entry(carrinho).State = (EntityState)state;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Salvar(Carrinho carrinho)
        {
            try
            {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Carrinho Find(int? id)
        {
            try
            {
                return db.Carrinho.FirstOrDefault(c => c.id == id);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}