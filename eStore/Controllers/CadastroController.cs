using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class CadastroController : Controller
    {
        public ActionResult MeuCadastro()
        {
            return View("MeuCadastro");
        }
    }
}