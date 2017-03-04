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

        public IEnumerable<Categoria> Listar()
        {
            return db.Categoria.ToList();
        }

        public IEnumerable<Categoria> ListarPorNome(string nome)
        {
            return db.Categoria.Where(c => c.nome.Contains(nome)).ToList();
        }

        public IEnumerable<Categoria> ListarPorCodigo(string codigo)
        {
            return db.Categoria.Where(c => c.codigo.Contains(codigo)).ToList();
        }

        public bool Criar(Categoria categoria) 
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

        public bool Remover(Categoria categoria)
        {
            try
            {
                db.Categoria.Remove(categoria);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Editar(Categoria categoria, int state)
        {
            try
            {
                db.Entry(categoria).State = (EntityState)state;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Salvar(Categoria categoria)
        {
            try
            {
                db.Entry(categoria).State = EntityState.Modified;
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
                return db.Categoria.FirstOrDefault(c => c.id == id);
            }
            catch (Exception)
            {

                return null;
            }
        }
       
    }
}