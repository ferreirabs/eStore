//using eStore.Entities;
using eStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eStore.Business;

namespace eStore.Controllers
{
    public class ManagerController : Controller
    {
        private bool logado;
        private eStore.Business.Produto produto = new eStore.Business.Produto();

        // GET: Manager
        public ActionResult Index()
        {
            
            //logado = (bool)System.Web.HttpContext.Current.Session.Keys.["logado"];
            if (true)
            {
                return View();
            }
            else {
                return View("LogIn");
            }
        }

        public ActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(ModelLojista model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.Nome.Equals("bruno") && model.Senha.Equals("teste"))
                {

                    //FormsAuthentication.SetAuthCookie(model.Nome, null);
                    System.Web.HttpContext.Current.Session["logado"] = true;
                    if (returnUrl != null)
                    {
                        logado = true;
                        //return Redirect(returnUrl);
                        return RedirectToAction("Index", "Manager");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                }
                else
                {
                    ModelState.AddModelError("CustomError", produto.TotalProdutos().ToString());
                }
            }

            return View(model);
        }

        public ActionResult GerenciarProdutos()
        {
            return View("GerenciarProdutos");
        }
    }
}