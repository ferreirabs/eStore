﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {

        private bool logado;
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        private eStore.Business.Comprador bcomprador = new eStore.Business.Comprador();
        
        /*public ActionResult Index()
        {
            return View();
        }*/

        public ActionResult Index()
        {
            ModelView.ModelVitrine modelVitrine = new ModelView.ModelVitrine();
            modelVitrine.categorias = bcategoria.Listar();
            modelVitrine.produtos = bproduto.Listar();
            return View(modelVitrine);
        }

        public ActionResult ExibirProduto(int? id)
        {
            ModelView.ModelVitrine modelVitrine = new ModelView.ModelVitrine();
            modelVitrine.produtos = bproduto.Listar();

            ModelView.ModelProdutoLoja modelProdutoLoja = new ModelView.ModelProdutoLoja();
            modelProdutoLoja.produto = modelVitrine.produtos.FirstOrDefault(p => p.id == id);
            modelProdutoLoja.categorias = bcategoria.Listar();
            return View("~/Views/Home/Produto.cshtml", modelProdutoLoja);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int seed = new Random().Next(1,1000);
            string hash_carrinho =  "Carrinho" + (seed.ToString());
            Session["carrinho"] = hash_carrinho.GetHashCode();
            
        }
        


    }
}