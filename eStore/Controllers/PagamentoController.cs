using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult EfetuarPagamento()
        {
            if(System.Web.HttpContext.Current.Session["nome_comprador"] == null)
            {
                return View("~/Views/Cadastro/MinhaConta.cshtml");
            }
            else if (System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] == null)
            {
                return View("~/Views/Home/Carrinho.cshtml");
                
            }
            
            return View("~/Views/Home/Pagamento.cshtml");
        }
    }
}