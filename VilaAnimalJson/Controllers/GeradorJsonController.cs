using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace VilaAnimalJson.Controllers
{
    public class GeradorJsonController : Controller
    {
        // GET: GeradorJson
        public ActionResult Index()
        {
            WebClient web = new WebClient();
            string request = web.DownloadString("http://localhost:49491");
            //return Content(request);
            return View(request);
        }
        public ActionResult Post(FormCollection form)
        {
            var cliente = form["cliente"];
            string dados = JsonConvert.SerializeObject(cliente);
            return Content(cliente);
        }
        public JsonResult getJson()
        {
            int quantidade = 10;
            /*var resultado = new
            {
                nome = "Jao",
                pontos = 3
            };*/
            List<Object> resultado = new List<object>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(new { Nome = "Nome " + i.ToString("000") });
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}