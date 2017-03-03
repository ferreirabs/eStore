using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using eStore.ModelView;

namespace eStore.Business
{
    public class Categoria : ICategoria
    {

        public DicionarioErros msgErro =  new DicionarioErros();

        public Categoria() { }

        public bool Criar(Entities.Categoria categoria)
        {
            try
            {
                CategoriaDAO c = new CategoriaDAO();
                return c.Criar(categoria);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
            
        }

        public bool Remover(Entities.Categoria categoria)
        {
            try
            {
                CategoriaDAO c = new CategoriaDAO();
                return c.Remover(categoria);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }
        
        public bool Remover(int id)
        {
            try
            {
                CategoriaDAO c = new CategoriaDAO();
                var categoria = c.Find(id);
                if (categoria != null)
                {
                    return c.Remover(categoria);
                }
                return false;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public IEnumerable<Entities.Categoria> Listar()
        {

            try
            {
                CategoriaDAO c = new CategoriaDAO();
                return c.Listar();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelCategoria Listar(int filtro)
        {
            try
            {
                ModelCategoria modelCategoria = new ModelCategoria();
                CategoriaDAO categoriaDAO = new CategoriaDAO();

                var LCategorias = categoriaDAO.Listar();
                foreach (var item in LCategorias)
                {
                    modelCategoria.categorias.Add(item);
                }

                modelCategoria.total_categorias = modelCategoria.categorias.Count();
                return modelCategoria;
            
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelCategoria ListarPorFiltro(string valor, string tipo)
        {
            try
            {
                ModelCategoria modelCategoria = new ModelCategoria();
                CategoriaDAO categoriaDAO = new CategoriaDAO();

                var LCategorias = ListarPorTipo(valor, tipo, categoriaDAO);

                foreach (var item in LCategorias)
                {
                    modelCategoria.categorias.Add(item);
                }

                modelCategoria.total_categorias = modelCategoria.categorias.Count();
                return modelCategoria;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        private IEnumerable<Entities.Categoria> ListarPorTipo(string valor, string tipo, CategoriaDAO categoriaDAO)
        {
            switch (tipo)
            {
                case "nome":
                    return categoriaDAO.ListarPorNome(valor);
                case "codigo":
                    return categoriaDAO.ListarPorCodigo(valor);
                default:
                    return categoriaDAO.ListarPorNome("");
            }
        }

        public bool Editar(Entities.Categoria categoria, int state)
        {

            try
            {
                CategoriaDAO c = new CategoriaDAO();
                return c.Editar(categoria, state);
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