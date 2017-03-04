using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using eStore.ModelView;
using PagedList;
using AutoMapper;

namespace eStore.Business
{
    public class Categoria : ICategoria
    {

        public DicionarioErros msgErro =  new DicionarioErros();

        public Categoria() {
            AutoMapperConfig.ConfigMappings();
        }

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

        public bool Criar(ModelView.ModelCategoria categoria)
        {
            try
            {
                CategoriaDAO c = new CategoriaDAO();
                var _categoria = Mapper.Map<Entities.Categoria>(categoria);
                
                if (_categoria.nome.Equals(null))
                    return false;
                
                return c.Criar(_categoria);
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

        public ModelCategoria Listar(int page, int pageSize)
        {
            try
            {
                ModelCategoria modelCategoria = new ModelCategoria();
                CategoriaDAO categoriaDAO = new CategoriaDAO();
                var LCategorias = categoriaDAO.Listar();
                modelCategoria.lista_categorias = new PagedList<Entities.Categoria>(LCategorias, page, pageSize);
                modelCategoria.total_categorias = modelCategoria.lista_categorias.Count();
                
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
                modelCategoria.lista_categorias = new PagedList<Entities.Categoria>(LCategorias, 1, 10);
                modelCategoria.total_categorias = modelCategoria.lista_categorias.Count();
                
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

        public bool Editar(ModelView.ModelCategoria categoria)
        {

            try
            {
                CategoriaDAO c = new CategoriaDAO();
                var _categoria = Mapper.Map<Entities.Categoria>(categoria);
                return c.Salvar(_categoria);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }
        
        public ModelCategoria Find(int? id)
        {
            try
            {
                CategoriaDAO categoriaDAO = new CategoriaDAO();
                var categoria = categoriaDAO.Find(id);
                List<Entities.Categoria> lcategoria = new List<Entities.Categoria>();
                lcategoria.Add(categoria);

                ModelCategoria modelCategoria = new ModelCategoria(lcategoria.FirstOrDefault());
                modelCategoria.lista_categorias = new PagedList<Entities.Categoria>(lcategoria, 1, 10);
                modelCategoria.total_categorias = modelCategoria.lista_categorias.Count();
                return modelCategoria;
            
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }
        
    }
}