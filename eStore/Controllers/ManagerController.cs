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
using System.Data.Entity;

namespace eStore.Controllers
{
    public class ManagerController : Controller
    {
        private bool logado;
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        private eStoreContext db = new eStoreContext();

        #region produtos
        // GET: Manager
        public ActionResult Index()
        {

            //logado = (bool)System.Web.HttpContext.Current.Session.Keys.["logado"];
            if (true)
            {
                return View();
            }
            else
            {
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
                    ModelState.AddModelError("CustomError", bproduto.TotalProdutos().ToString());
                }
            }

            return View(model);
        }

        public ActionResult GerenciarProdutos()
        {
            return View("GerenciarProdutos");
        }

        #endregion produtos



        #region Categorias
        public ActionResult GerenciarCategorias()
        {
            var lcategorias = bcategoria.Listar();
            return View("~/Views/Manager/Categorias/List.cshtml", lcategorias);
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
        public ActionResult CriarCategoria([Bind(Include = "id,codigo,nome,descricao,bloqueado")] Entities.Categoria categoria)
        {
            if (ModelState.IsValid && categoria.nome != null)
            {
                bcategoria.Criar(categoria);
                return RedirectToAction("GerenciarCategorias");
            }
            else
            {
                ModelState.AddModelError("CustomError", bcategoria.msgErro.Get("CAMPOS_OBRIGATORIOS"));
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
            var categoria = bcategoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Manager/Categorias/Delete.cshtml", categoria);
        }

        // POST: ModelCategorias/Delete/5
        [HttpPost, ActionName("DeleteCategoria")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoriaConfirmed(int id)
        {
            if (!bcategoria.Remover(id))
            {
                ModelState.AddModelError("CustomError", bcategoria.msgErro.Get("EXECUTAR_ACAO"));
            }

            return RedirectToAction("GerenciarCategorias");
        }

        // GET: GerenciarCategorias/EditCategoria/5
        public ActionResult EditCategoria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = bcategoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Manager/Categorias/Edit.cshtml", categoria);
        }

        // POST: GerenciarCategorias/EditCategoria/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategoria([Bind(Include = "id,codigo,nome,descricao,bloqueado")] Entities.Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (!bcategoria.Editar(categoria, (int)EntityState.Modified))
                {
                    ModelState.AddModelError("CustomError", bcategoria.msgErro.Get("EXECUTAR_ACAO"));
                    return View("~/Views/Manager/Categorias/Edit.cshtml", categoria);
                }
            }
            return RedirectToAction("GerenciarCategorias");

        }


        #endregion Categorias


    }
}