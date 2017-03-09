using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class CarrinhoController : Controller
    {

        private bool logado;
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        private eStore.Business.Comprador bcomprador = new eStore.Business.Comprador();
        private eStore.Business.Carrinho bcarrinho = new eStore.Business.Carrinho();

        [HttpGet]
        public ActionResult ListarProdutosPorDepartamento(int page = 1, int pageSize = 10)
        {
            var lprodutos = bproduto.Listar(page, pageSize);
            return View("~/Views/Manager/Produtos/List.cshtml", lprodutos);
        }


        [HttpGet]
        public ActionResult ListarProdutosVitrine()
        {
            var lprodutos = bproduto.Listar();
            return View("~/Views/Manager/Produtos/List.cshtml", lprodutos);
        }

        
        public ActionResult MeuCarrinho(int id_produto = 0)
        {
            List<int?> produtos_carrinho = new List<int?>();
            
            
            produtos_carrinho.Add(id_produto);
            

            if (System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] == null)
            {
                if (id_produto != 0)
                {
                    System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] = produtos_carrinho;
                }
            }
            else
            {

                produtos_carrinho = System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] as List<int?>;

                if (!produtos_carrinho.Contains(id_produto))
                {
                    produtos_carrinho.Add(id_produto);
                }


                System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] = produtos_carrinho;

            }
            

            ModelView.ModelCarrinho carrinho = new ModelView.ModelCarrinho();
            carrinho = bcarrinho.Get(produtos_carrinho);
            return View("~/Views/Home/Carrinho.cshtml", carrinho);
        }

        public ActionResult RemoverItem(int id_produto = 0)
        {
            List<int?> produtos_carrinho = new List<int?>();
            produtos_carrinho.Add(id_produto);
            if (System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] != null)
            {
                produtos_carrinho = System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] as List<int?>;
                if (produtos_carrinho.Contains(id_produto)){
                    produtos_carrinho.Remove(id_produto);
                }

                if(!produtos_carrinho.Any())
                    System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] = null;
                else
                    System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] = produtos_carrinho;
            
            }
            
            ModelView.ModelCarrinho carrinho = new ModelView.ModelCarrinho();
            carrinho = bcarrinho.Get(produtos_carrinho);
            return View("~/Views/Home/Carrinho.cshtml", carrinho);
        }

        public ActionResult LimparCarrinho(int id_produto = 0)
        {
            List<int?> produtos_carrinho = new List<int?>();
            produtos_carrinho.Add(id_produto);
            if (System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] != null)
            {
                System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] = null;
            }
            
            ModelView.ModelCarrinho carrinho = new ModelView.ModelCarrinho();
            carrinho = bcarrinho.Get(produtos_carrinho);
            return View("~/Views/Home/Carrinho.cshtml", carrinho);
        }

        
        
    }
}