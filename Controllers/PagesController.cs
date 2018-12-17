using Microsoft.AspNetCore.Mvc;

namespace Senai.Projetos.Comentarios_Check_Point.Controllers
{
    public class PagesController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Carfel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Planos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ajuda()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contato()
        {
            return View();
        }
    }
}