using eStore.Entities;
using eStore.Model;
using eStore.ModelView;
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
using PagedList;

namespace eStore.Controllers
{
    public class ManagerController : Controller
    {
        private bool logado;
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        private eStore.Business.Comprador bcomprador = new eStore.Business.Comprador();
        private eStore.Business.Pedido bpedido = new eStore.Business.Pedido();
        //private eStoreContext db = new eStoreContext();

        #region login
        // GET: Manager
        public ActionResult Index()
        {
            ModelView.ModelDashBoardManager dashboard = new ModelView.ModelDashBoardManager();
            dashboard.categorias = bcategoria.Listar(1, 10);
            dashboard.produtos = bproduto.Listar(1,10);
            dashboard.compradores = bcomprador.Listar(1,10);
            dashboard.pedidos = bpedido.Listar(1, 10);
            if (true)
            {
                return View(dashboard);
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
                    //ModelState.AddModelError("CustomError", bproduto.TotalProdutos().ToString());
                }
            }

            return View(model);
        }

        #endregion login

        #region compradores

            [HttpPost]
            public ActionResult ListarCompradorPorFiltro(string filtro_valor, string filtro_tipo)
            {
                var lcompradores = bcomprador.ListarPorFiltro(filtro_valor, filtro_tipo);
                return View("~/Views/Manager/Compradores/List.cshtml", lcompradores);
            }

            [HttpGet]
            public ActionResult GerenciarCompradores(int page = 1, int pageSize = 10)
            {
                var lcompradores = bcomprador.Listar(page, pageSize);
                return View("~/Views/Manager/Compradores/List.cshtml", lcompradores);
            }

            public ActionResult EditComprador(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ModelView.ModelCompradores comprador = bcomprador.Find(id);
                if (comprador == null)
                {
                    return HttpNotFound();
                }
                return View("~/Views/Manager/Compradores/Edit.cshtml", comprador);
            }
                        
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult EditComprador(ModelView.ModelCompradores model_comprador)
            {
                if (ModelState.IsValid)
                {
                    if (!bcomprador.Editar(model_comprador))
                    {
                        ModelState.AddModelError("CustomError", bproduto.msgErro.Get("EXECUTAR_ACAO"));
                        return View("~/Views/Manager/Compradores/Edit.cshtml", model_comprador);
                    }
                }
                return RedirectToAction("GerenciarCompradores");

            }

        #endregion compradores

        #region pedidos
            [HttpPost]
            public ActionResult ListarPedidosPorFiltro(string filtro_valor, string filtro_tipo)
            {
                var lpedidos = bpedido.ListarPorFiltro(filtro_valor, filtro_tipo);
                return View("~/Views/Manager/Pedidos/List.cshtml", lpedidos);
            }

            [HttpGet]
            public ActionResult GerenciarPedidos(int page = 1, int pageSize = 10)
            {
                var lpedidos = bpedido.Listar(page, pageSize);
                return View("~/Views/Manager/Pedidos/List.cshtml", lpedidos);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult EditPedido(ModelView.ModelPedidoManager model_pedido)
            {
                if (ModelState.IsValid)
                {
                    /*if (!bpedido.Editar(model_pedido))
                    {
                        ModelState.AddModelError("CustomError", bproduto.msgErro.Get("EXECUTAR_ACAO"));
                        return View("~/Views/Manager/Compradores/Edit.cshtml", model_pedido);
                    }*/
                }
                return RedirectToAction("GerenciarPedidos");

            }    

        #endregion


        #region produtos
            [HttpPost]
        public ActionResult ListarProdutoPorFiltro(string filtro_valor, string filtro_tipo)
        {
            var lprodutos = bproduto.ListarPorFiltro(filtro_valor, filtro_tipo);
            return View("~/Views/Manager/Produtos/List.cshtml", lprodutos);
        }

        [HttpGet]
        public ActionResult GerenciarProdutos(int page = 1, int pageSize = 10)
        {
            var lprodutos = bproduto.Listar(page, pageSize);
            return View("~/Views/Manager/Produtos/List.cshtml", lprodutos);
        }

        public ActionResult CriarProduto()
        {
            return View("~/Views/Manager/Produtos/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarProduto([Bind(Include = "id,codigo,nome,preco,ordem,bloqueado,descricao")] ModelView.ModelProduto produto)
        {
            if (ModelState.IsValid)
            {
                bproduto.Criar(produto);
                return RedirectToAction("GerenciarProdutos");
            }
            else
            {
                ModelState.AddModelError("CustomError", bproduto.msgErro.Get("CAMPOS_OBRIGATORIOS"));
            }
            return View("~/Views/Manager/Produtos/Create.cshtml");
        }

        public ActionResult DeleteProduto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = bproduto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Manager/Produtos/Delete.cshtml", produto);
        }

        [HttpPost, ActionName("DeleteProduto")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProdutoConfirmed(int id)
        {
            if (!bproduto.Remover(id))
            {
                ModelState.AddModelError("CustomError", bproduto.msgErro.Get("EXECUTAR_ACAO"));
            }

            return RedirectToAction("GerenciarProdutos");
        }

        public ActionResult EditProduto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelView.ModelProduto produto = bproduto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Manager/Produtos/Edit.cshtml", produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduto([Bind(Include = "id,codigo,nome,preco,ordem,bloqueado,descricao")] ModelView.ModelProduto model_produto)
        {
            if (ModelState.IsValid)
            {
                if (!bproduto.Editar(model_produto))
                {
                    ModelState.AddModelError("CustomError", bproduto.msgErro.Get("EXECUTAR_ACAO"));
                    return View("~/Views/Manager/Produtos/Edit.cshtml", model_produto);
                }
            }
            return RedirectToAction("GerenciarProdutos");

        }

        #endregion produtos
        
        #region Categorias
        [HttpPost]
        public ActionResult ListarCategoriaPorFiltro(string filtro_valor, string filtro_tipo)
        {
            var lcategorias = bcategoria.ListarPorFiltro(filtro_valor, filtro_tipo);
            return View("~/Views/Manager/Categorias/List.cshtml", lcategorias);
        }

        [HttpGet]
        public ActionResult GerenciarCategorias(int page = 1, int pageSize = 10)
        {
            var lcategorias = bcategoria.Listar(page, pageSize);
            return View("~/Views/Manager/Categorias/List.cshtml", lcategorias);
        }

        public ActionResult CriarCategoria()
        {
            return View("~/Views/Manager/Categorias/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarCategoria([Bind(Include = "id,codigo,nome,descricao,bloqueado")] ModelView.ModelCategoria categoria)
        {
            if (ModelState.IsValid)
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

        public ActionResult EditCategoria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelView.ModelCategoria categoria = bcategoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Manager/Categorias/Edit.cshtml", categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategoria([Bind(Include = "id,codigo,nome,descricao,bloqueado")] ModelView.ModelCategoria model_categoria)
        {
            if (ModelState.IsValid)
            {
                if (!bcategoria.Editar(model_categoria))
                {
                    ModelState.AddModelError("CustomError", bcategoria.msgErro.Get("EXECUTAR_ACAO"));
                    return View("~/Views/Manager/Categorias/Edit.cshtml", model_categoria);
                }
            }
            return RedirectToAction("GerenciarCategorias");

        }


        #endregion Categorias


    }
}