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
    public class ProdutoDAO : IProdutoDAO
    {
        eStoreContext db = new eStoreContext();

        public IEnumerable<Produto> Listar()
        {
            return db.Produto.ToList();
        }

        public IEnumerable<Produto> ListarPorNome(string nome)
        {
            return db.Produto.Where(c => c.nome.Contains(nome)).ToList();
        }

        public IEnumerable<Produto> ListarPorCodigo(string codigo)
        {
            return db.Produto.Where(c => c.codigo.Contains(codigo)).ToList();
        }

        public bool Criar(Produto produto)
        {
            try
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Remover(Produto produto)
        {
            try
            {
                db.Produto.Remove(produto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Editar(Produto produto, int state)
        {
            try
            {
                db.Entry(produto).State = (EntityState)state;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Salvar(Produto produto)
        {
            try
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Produto Find(int? id)
        {
            try
            {
                return db.Produto.FirstOrDefault(c => c.id == id);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}