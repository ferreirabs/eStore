using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Categoria()
        {
            return View("Categoria");
        }


        public ActionResult ListarProdutos()
        {

            return View("ListarProdutos");

        }
    }
}