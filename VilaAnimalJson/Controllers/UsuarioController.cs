using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VilaAnimalJson.Models;

namespace VilaAnimalJson.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Novo()
        {
            //RetornaaviewNovo
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Usuario usuario)
        {
            /*SealgumapropriedadenãoatendeavalidaçãodefinidanaclassePessoa
            *oModelState.IsValidseráFalse,entãoretornaráaViewdevolta
            *devolvendoosdadosdomodeloPessoa
            **/
            if (!ModelState.IsValid)
                return View(usuario);

            //SeestátudoOk,voltaparaaIndexdocontroller
            //return RedirectToAction("Index");
            return View();
        }
    }
}