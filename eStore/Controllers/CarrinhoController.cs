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

        [HttpGet]
        public ActionResult MeuCarrinho()
        {
            int?[] ids_produtos = new int?[]{1,2,3};
            ModelView.ModelCarrinho carrinho = new ModelView.ModelCarrinho();
            carrinho = bcarrinho.Get(ids_produtos);
            return View("~/Views/Home/Carrinho.cshtml", carrinho);
        }
        
    }
}