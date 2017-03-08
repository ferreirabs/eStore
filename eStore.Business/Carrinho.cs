using AutoMapper;
using eStore.Entities;
using eStore.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public class Carrinho : ICarrinho
    {
        public DicionarioErros msgErro =  new DicionarioErros();

        public Carrinho() {
            AutoMapperConfig.ConfigMappings();
        }

        public bool Criar(Entities.Carrinho carrinho)
        {
            try
            {
                CarrinhoDAO c = new CarrinhoDAO();
                return c.Criar(carrinho);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
            
        }

        public bool Criar(ModelView.ModelCarrinho carrinho)
        {
            try
            {
                CarrinhoDAO c = new CarrinhoDAO();
                var _carrinho = Mapper.Map<Entities.Carrinho>(carrinho);
                
                return c.Criar(_carrinho);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public bool Remover(Entities.Carrinho carrinho)
        {
            try
            {
                CarrinhoDAO c = new CarrinhoDAO();
                return c.Remover(carrinho);
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
                CarrinhoDAO c = new CarrinhoDAO();
                var carrinho = c.Find(id);
                if (carrinho != null)
                {
                    return c.Remover(carrinho);
                }
                return false;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public IEnumerable<Entities.Carrinho> Listar()
        {

            try
            {
                CarrinhoDAO c = new CarrinhoDAO();
                return c.Listar();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelCarrinho Listar(int page, int pageSize)
        {
            try
            {
                ModelCarrinho modelCarrinho = new ModelCarrinho();
                CarrinhoDAO carrinhoDAO = new CarrinhoDAO();
                var LCarrinhos = carrinhoDAO.Listar();
                //modelCarrinho.lista_carrinhos = new PagedList<Entities.Carrinho>(LCarrinhos, page, pageSize);
                //modelCarrinho.total_produtos = modelCarrinho.lista_carrinhos.Count();
                
                return modelCarrinho;
            
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelCarrinho ListarPorFiltro(string valor, string tipo)
        {
            try
            {
                ModelCarrinho modelcarrinho = new ModelCarrinho();
                CarrinhoDAO carrinhoDAO = new CarrinhoDAO();

                //var Lcarrinhos = ListarPorTipo(valor, tipo, carrinhoDAO);
                //modelcarrinho.lista_carrinhos = new PagedList<Entities.Carrinho>(Lcarrinhos, 1, 10);
                //modelcarrinho.total_carrinhos = modelcarrinho.lista_carrinhos.Count();
                
                return modelcarrinho;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        /*private IEnumerable<Entities.Carrinho> ListarPorTipo(string valor, string tipo, CarrinhoDAO carrinhoDAO)
        {
            switch (tipo)
            {
                case "nome":
                    return carrinhoDAO.ListarPorNome(valor);
                case "codigo":
                    return carrinhoDAO.ListarPorCodigo(valor);
                default:
                    return carrinhoDAO.ListarPorNome("");
            }
        }*/

        public bool Editar(Entities.Carrinho carrinho, int state)
        {

            try
            {
                CarrinhoDAO c = new CarrinhoDAO();
                return c.Editar(carrinho, state);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
        
        }

        public bool Editar(ModelView.ModelCarrinho carrinho)
        {

            try
            {
                CarrinhoDAO c = new CarrinhoDAO();
                var _carrinho = Mapper.Map<Entities.Carrinho>(carrinho);
                return c.Salvar(_carrinho);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }
        
        public ModelCarrinho Find(int? id)
        {
            try
            {
                CarrinhoDAO carrinhoDAO = new CarrinhoDAO();
                var carrinho = carrinhoDAO.Find(id);
                List<Entities.Carrinho> lcarrinho = new List<Entities.Carrinho>();
                lcarrinho.Add(carrinho);

                ModelCarrinho modelcarrinho = new ModelCarrinho(lcarrinho.FirstOrDefault());
                //modelcarrinho.lista_carrinhos = new PagedList<Entities.Carrinho>(lcarrinho, 1, 10);
                //modelcarrinho.total_carrinhos = modelcarrinho.lista_carrinhos.Count();
                return modelcarrinho;
            
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelCarrinho Get(int?[] codigos_produtos)
        {
            try
            {
                CarrinhoDAO carrinhoDAO = new CarrinhoDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                List<Entities.Produto> lprodutos_carrinhos = new List<Entities.Produto>();
                foreach (var codigo in codigos_produtos)
                {
                    var item = produtoDAO.Find(codigo);
                    if(item != null)
                        lprodutos_carrinhos.Add(item);

                }
                
                ModelCarrinho modelcarrinho = new ModelCarrinho();
                modelcarrinho.lista_produtos = lprodutos_carrinhos;
                modelcarrinho.preco_carrinho = GetTotalPrecoProdutos(modelcarrinho.lista_produtos);
                modelcarrinho.total_produtos = modelcarrinho.lista_produtos.Count();

                return modelcarrinho;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }


        }

        public int GetTotalPrecoProdutos(IEnumerable<Entities.Produto> produtos)
        {
            int total = 0;
            foreach (var item in produtos)
            {
                total += (int)item.preco;
            }

            return total;
        }

    }
}