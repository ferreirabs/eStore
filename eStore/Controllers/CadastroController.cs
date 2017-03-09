using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class CadastroController : Controller
    {
        private eStore.Business.Comprador bcomprador = new eStore.Business.Comprador();
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        
        public ActionResult MinhaConta()
        {
            return View("~/Views/Cadastro/MinhaConta.cshtml");
        }


        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            //Criar Sessão
            var comprador = bcomprador.Logar(email, senha);
            if(comprador != null)
                System.Web.HttpContext.Current.Session["nome_comprador"] = comprador.nome;

            ModelView.ModelVitrine modelVitrine = new ModelView.ModelVitrine();
            modelVitrine.categorias = bcategoria.Listar();
            modelVitrine.produtos = bproduto.Listar();

            return View("~/Views/Home/Index.cshtml", modelVitrine);
        }

        
        public ActionResult Logout()
        {
            
            System.Web.HttpContext.Current.Session["nome_comprador"] = null;

            ModelView.ModelVitrine modelVitrine = new ModelView.ModelVitrine();
            modelVitrine.categorias = bcategoria.Listar();
            modelVitrine.produtos = bproduto.Listar();

            return View("~/Views/Home/Index.cshtml", modelVitrine);
        }

        [HttpPost]
        public ActionResult Cadastrar(string nome, string sobrenome, string email, string sexo, string senha, string conf_senha)
        {

            if (senha != conf_senha)
            {
                ModelState.AddModelError("ErroSenha", "Senhas Diferentes!");
                return RedirectToAction("MinhaConta");
            }

            var novo_comprador = bcomprador.Builder(nome, sobrenome, email, sexo, senha, conf_senha);
            if (novo_comprador != null)
            {
                if (!bcomprador.Criar(novo_comprador))
                {
                    ModelState.AddModelError("ErroEmail", "Comprador já existe!");
                    return RedirectToAction("MinhaConta");
                }
                
            }

            var result = new CadastroController().Login(email, senha);

            return View("~/Views/Cadastro/MinhaConta.cshtml");
           
        }
    }
}