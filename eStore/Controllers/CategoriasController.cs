using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStore.Entities.Context;
using System.Net;
using eStore.Model;
using System.Data.Entity;

namespace eStore.Controllers.Manager
{
    public class CategoriasController : Controller
    {
        private eStoreContext db = new eStoreContext();

        private eStore.Business.Categoria categoria = new eStore.Business.Categoria();

        // GET: ModelCategorias
        public ActionResult Index()
        {
            return View(db.Categoria.ToList());
        }

        // GET: ModelCategorias/Details/5
        public ActionResult Details(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var modelCategoria = new ModelCategoria(categoria.Find(id));
            if (modelCategoria == null)
            {
                return HttpNotFound();
            }*/
            //~/Views/Guestbook/Index.cshtml
            return View("~/Views/Manager/Categorias/Create.cshtml");
        }

        // GET: ModelCategorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nome")] ModelCategoria modelCategoria)
        {
            if (ModelState.IsValid)
            {

                Entities.Categoria c = new Entities.Categoria();
                c.codigo = modelCategoria.codigo;
                c.nome = modelCategoria.nome;
                categoria.Create(c);

                return RedirectToAction("Index");
            }

            return View(modelCategoria);
        }

        // GET: ModelCategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategoria modelCategoria = (ModelCategoria)db.Categoria.Find(id);
            if (modelCategoria == null)
            {
                return HttpNotFound();
            }
            return View(modelCategoria);
        }

        // POST: ModelCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nome")] ModelCategoria modelCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelCategoria);
        }

        // GET: ModelCategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategoria modelCategoria = (ModelCategoria)db.Categoria.Find(id);
            if (modelCategoria == null)
            {
                return HttpNotFound();
            }
            return View(modelCategoria);
        }

        // POST: ModelCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelCategoria modelCategoria = (ModelCategoria)db.Categoria.Find(id);
            db.Categoria.Remove(modelCategoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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