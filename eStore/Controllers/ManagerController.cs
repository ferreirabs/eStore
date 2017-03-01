using eStore.Entities;
using eStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eStore.Business;
using System.Collections;
using eStore.Entities.Context;
using System.Net;

namespace eStore.Controllers
{
    public class ManagerController : Controller
    {
        private bool logado;
        private eStore.Business.Produto produto = new eStore.Business.Produto();
        private eStore.Business.Categoria categoria = new eStore.Business.Categoria();
        private eStoreContext db = new eStoreContext();

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

        
        
        
        
        #region Categorias
        public ActionResult GerenciarCategorias() 
        {
            List<ModelCategoria> modelCategoria = new List<ModelCategoria>();
            var LCategorias = categoria.Listar();
            foreach (var item in LCategorias)
            {
                modelCategoria.Add(new ModelCategoria(item));
            }

            return View("~/Views/Manager/Categorias/List.cshtml", modelCategoria);
            
        }

        public ActionResult CriarCategoria()
        {
            return View("~/Views/Manager/Categorias/Create.cshtml");
        }

        // POST: ModelCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarCategoria([Bind(Include = "id,codigo,nome")] ModelCategoria modelCategoria)
        {
            if (ModelState.IsValid && modelCategoria.nome != null)
            {

                Entities.Categoria c = new Entities.Categoria();
                c.codigo = modelCategoria.codigo;
                c.nome = modelCategoria.nome;
                categoria.Create(c);

                return RedirectToAction("GerenciarCategorias");
            }
            else
            {
                ModelState.AddModelError("CustomError", "Campos obrigatórios inválidos!");
            }
            return View("~/Views/Manager/Categorias/Create.cshtml");
        }

        // GET: ModelCategorias/Delete/5
        public ActionResult DeleteCategoria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategoria modelCategoria = new ModelCategoria(db.Categoria.Find(id));
            if (modelCategoria == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Manager/Categorias/Delete.cshtml", modelCategoria);
        }

        // POST: ModelCategorias/Delete/5
        [HttpPost, ActionName("DeleteCategoria")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoriaConfirmed(int id)
        {
            Entities.Categoria categoria = db.Categoria.Find(id);
            db.Categoria.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("GerenciarCategorias");
        }

        #endregion Categorias

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}