using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedido
        public ActionResult MeusPedidos()
        {
            return View("~/Views/Home/Pedido.cshtml");
        }
    }
}