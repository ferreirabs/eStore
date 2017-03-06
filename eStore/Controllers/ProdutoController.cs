using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public partial class ProdutoController : Controller
    {

        private bool logado;
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        private eStore.Business.Comprador bcomprador = new eStore.Business.Comprador();

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

    }
}