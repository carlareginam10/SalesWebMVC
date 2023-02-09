using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Salles Web MVC App from C# Course.";
            ViewData["email"] = "carlareginam10@gmail.com";
            ViewData["name"] = "Carla Regina Mendes";
            return View();
        }

        public IActionResult Contact()
        {
           
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()            {

            //chave e valor - o sistema vai procurar uma view c=hamada About e colocar essa msg dentro da tag ["Message"]
            ViewData["Message"] = "2 - estando o uso de chave e valor - essa msg foi escrita dentro do HomeController, mas a montagem dela em tela se deu por meio da view about";
            ViewData["xuxu"] = "3 - coloquei XUXU no lugar de Message pra testar";
            ViewData["NOTES"] = "1 - QUANDO COLOCA @{} NA VIEW QUER DIZER QUE POSSO COLOCAR QUALQUER CODIDO C# DENTRO DAS CHAVES";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
