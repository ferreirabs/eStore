using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int seed = new Random().Next(1,1000);
            string hash_carrinho =  "Carrinho" + (seed.ToString());
            Session["carrinho"] = hash_carrinho.GetHashCode();
            
        }
    }
}