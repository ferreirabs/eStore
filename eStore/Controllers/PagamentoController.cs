using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class PagamentoController : Controller
    {
        private bool logado;
        private eStore.Business.Produto bproduto = new eStore.Business.Produto();
        private eStore.Business.Categoria bcategoria = new eStore.Business.Categoria();
        private eStore.Business.Comprador bcomprador = new eStore.Business.Comprador();
        private eStore.Business.Carrinho bcarrinho = new eStore.Business.Carrinho();
        private eStore.Business.Pedido bpedido = new eStore.Business.Pedido();
        
        // GET: Pagamento
        public ActionResult EfetuarPagamento()
        {
            if(System.Web.HttpContext.Current.Session["nome_comprador"] == null)
            {
                return View("~/Views/Cadastro/MinhaConta.cshtml");
            }
            else if (System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] == null)
            {
                return View("~/Views/Home/Carrinho.cshtml");
                
            }

            List<int?> produtos_carrinho = new List<int?>();
            produtos_carrinho = System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] as List<int?>;

            ModelView.ModelCarrinho carrinho = new ModelView.ModelCarrinho();
            carrinho = bcarrinho.Get(produtos_carrinho);

            ModelView.ModelPagamento pagamento = new ModelView.ModelPagamento();
            pagamento.lista_produtos = carrinho.lista_produtos;
            pagamento.preco_carrinho = carrinho.preco_carrinho;
            pagamento.total = carrinho.total;

            return View("~/Views/Home/Pagamento.cshtml", pagamento);
        }

        [HttpPost]
        public ActionResult FecharCompra(ModelView.ModelPagamento _pagamento)
        {
            List<int?> produtos_carrinho = new List<int?>();
            produtos_carrinho = System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] as List<int?>;

            ModelView.ModelCarrinho carrinho = new ModelView.ModelCarrinho();
            carrinho = bcarrinho.Get(produtos_carrinho);

            ModelView.ModelPagamento pagamento = new ModelView.ModelPagamento();
            pagamento.lista_produtos = carrinho.lista_produtos;
            pagamento.preco_carrinho = carrinho.preco_carrinho;
            pagamento.total = carrinho.total;
            var nome_comprador = System.Web.HttpContext.Current.Session["nome_comprador"];
            int id_comprador = Convert.ToInt32(System.Web.HttpContext.Current.Session["id_comprador"]);

            var novo_pedido = bpedido.Builder(pagamento.preco_carrinho, pagamento.total, id_comprador, carrinho.lista_produtos);
            if (novo_pedido != null)
            {
                if (!bpedido.Criar(novo_pedido))
                {
                    ModelState.AddModelError("ErroPagamento", "Ocorreu um erro ao finalizar a compra por favor tente novamente");
                    return View("~/Views/Home/Pagamento.cshtml", pagamento);
                }
                else
                {
                    System.Web.HttpContext.Current.Session["ids_produtos_carrinho"] = null;
                    
                    var pedidos = bpedido.ListarPorComprador(id_comprador);
                    ModelView.ModelPedidoLoja modelPedidoLoja = new ModelView.ModelPedidoLoja(pedidos.LastOrDefault());
                    modelPedidoLoja.comprador = bcomprador.Get(id_comprador);
                    return View("~/Views/Cadastro/MeusPedidos.cshtml", modelPedidoLoja);
                }
            }

            return View("~/Views/Home/Index.cshtml");
            

            
        }
        

    }
}