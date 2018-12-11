using Microsoft.AspNetCore.Mvc;

namespace Senai.Projetos.Comentarios_Check_Point.Controllers
{
    public class SystemController : Controller
    {
        [HttpGet]
        public ActionResult Planos()
        {
            return View();
        }
    }
}