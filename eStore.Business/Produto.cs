using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using System.Data.Entity;
using AutoMapper;
using eStore.ModelView;
using PagedList;

namespace eStore.Business
{
    public class Produto : IProduto
    {
        public DicionarioErros msgErro =  new DicionarioErros();

        public Produto() {
            AutoMapperConfig.ConfigMappings();
        }

        public bool Criar(Entities.Produto produto)
        {
            try
            {
                ProdutoDAO c = new ProdutoDAO();
                return c.Criar(produto);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
            
        }

        public bool Criar(ModelView.ModelProduto produto)
        {
            try
            {
                ProdutoDAO c = new ProdutoDAO();
                var _produto = Mapper.Map<Entities.Produto>(produto);
                
                if (_produto.nome.Equals(null))
                    return false;
                
                return c.Criar(_produto);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public bool Remover(Entities.Produto produto)
        {
            try
            {
                ProdutoDAO c = new ProdutoDAO();
                return c.Remover(produto);
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
                ProdutoDAO c = new ProdutoDAO();
                var produto = c.Find(id);
                if (produto != null)
                {
                    return c.Remover(produto);
                }
                return false;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public IEnumerable<Entities.Produto> Listar()
        {

            try
            {
                ProdutoDAO c = new ProdutoDAO();
                return c.Listar();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelProduto Listar(int page, int pageSize)
        {
            try
            {
                ModelProduto modelProduto = new ModelProduto();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                var LProdutos = produtoDAO.Listar();
                modelProduto.lista_produtos = new PagedList<Entities.Produto>(LProdutos, page, pageSize);
                modelProduto.total_produtos = modelProduto.lista_produtos.Count();
                
                return modelProduto;
            
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelProduto ListarPorFiltro(string valor, string tipo)
        {
            try
            {
                ModelProduto modelproduto = new ModelProduto();
                ProdutoDAO produtoDAO = new ProdutoDAO();

                var Lprodutos = ListarPorTipo(valor, tipo, produtoDAO);
                modelproduto.lista_produtos = new PagedList<Entities.Produto>(Lprodutos, 1, 10);
                modelproduto.total_produtos = modelproduto.lista_produtos.Count();
                
                return modelproduto;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        private IEnumerable<Entities.Produto> ListarPorTipo(string valor, string tipo, ProdutoDAO produtoDAO)
        {
            switch (tipo)
            {
                case "nome":
                    return produtoDAO.ListarPorNome(valor);
                case "codigo":
                    return produtoDAO.ListarPorCodigo(valor);
                default:
                    return produtoDAO.ListarPorNome("");
            }
        }

        public bool Editar(Entities.Produto produto, int state)
        {

            try
            {
                ProdutoDAO c = new ProdutoDAO();
                return c.Editar(produto, state);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
        
        }

        public bool Editar(ModelView.ModelProduto produto)
        {

            try
            {
                ProdutoDAO c = new ProdutoDAO();
                var _produto = Mapper.Map<Entities.Produto>(produto);
                return c.Salvar(_produto);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }
        
        public ModelProduto Find(int? id)
        {
            try
            {
                ProdutoDAO produtoDAO = new ProdutoDAO();
                var produto = produtoDAO.Find(id);
                List<Entities.Produto> lproduto = new List<Entities.Produto>();
                lproduto.Add(produto);

                ModelProduto modelproduto = new ModelProduto(lproduto.FirstOrDefault());
                modelproduto.lista_produtos = new PagedList<Entities.Produto>(lproduto, 1, 10);
                modelproduto.total_produtos = modelproduto.lista_produtos.Count();
                return modelproduto;
            
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }
    }
}