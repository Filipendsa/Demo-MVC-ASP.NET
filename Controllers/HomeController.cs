using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        [Route("pagina-inicial")]
        public IActionResult Index(string id, string categoria)
        {
            //var filme = new Filmin
            //{
            //    Titulo = "Oi",
            //    DateLancamento = DateTime.Now,
            //    Genero = null,
            //    Avaliacao = 10,
            //    Valor = 20000
            //};
            //return RedirectToAction("Privacy", filme);
            return View();
        }
        [Route("privacidade")]
        public IActionResult Privacy(Filmin filme)
        {
            if (ModelState.IsValid)
            {

            }

            foreach (var error in ModelState.Values.SelectMany(m=> m.Errors)){
                Console.WriteLine(error.ErrorMessage);
            }

            return View();

            //return Json("{'nome':'Filipe'}");
            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\arquivoTeste.txt");
            //var fileName = "paçoca.txt";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            //return Content("Anna Legal");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
