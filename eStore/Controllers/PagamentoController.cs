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
            return View("~/Views/Home/Pagamento.cshtml");
        }
    }
}