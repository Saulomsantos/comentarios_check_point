using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Projetos.Comentarios_Check_Point.Models;
using Senai.Projetos.Comentarios_Check_Point.Repositorios;

namespace Senai.Projetos.Comentarios_Check_Point.Controllers
{
    public class ComentarioController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("idUsuario")))
            {
                return RedirectToAction("Login","Usuario");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form)
        {
            ComentarioModel comentario = new ComentarioModel();
            
            comentario.Texto = form["comentario"];

            comentario.Usuario = new UsuarioModel();

            comentario.Usuario.ID = int.Parse(HttpContext.Session.GetString("idUsuario"));
            comentario.Usuario.Nome = HttpContext.Session.GetString("nomeUsuario");

            ComentarioRepositorio comentarioRepositorio = new ComentarioRepositorio();

            comentarioRepositorio.Cadastrar(comentario);

            ViewBag.Mensagem = "Comentário cadastrado!";

            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            // Caso seja administrador, lista os comentários para validação
            if (string.Equals(HttpContext.Session.GetString("tipoUsuario"), "Administrador"))
            {
                ComentarioRepositorio comentarioRepositorio = new ComentarioRepositorio();

                ViewData["Comentarios"] = comentarioRepositorio.Listar();
                
                return View();
            }

            // Caso não seja administrador, redireciona para a página de login
            else
            {
                return RedirectToAction("Login","Usuario");
            }
        }

        [HttpGet]
        public IActionResult Aprovar(int id)
        {
            if (id == 0)
            {
                TempData["Mensagem"] = "Informe um comentário para editar";
                return RedirectToAction("Listar");
            }

            ComentarioRepositorio comentarioRepositorio = new ComentarioRepositorio();
            ComentarioModel comentario = comentarioRepositorio.BuscarPorId(id);

            if (comentario == null)
            {
                TempData["Mensagem"] = "Comentário não encontrado";
                return RedirectToAction("Listar");
            }

            comentarioRepositorio.Aprovar(comentario);

            TempData["Mensagem"] = $"Comentário {comentario.ID} do usuário {comentario.Usuario.Nome} aprovado";

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Reprovar(int id)
        {
            if (id == 0)
            {
                TempData["Mensagem"] = "Informe um comentário para editar";
                return RedirectToAction("Listar");
            }

            ComentarioRepositorio comentarioRepositorio = new ComentarioRepositorio();
            ComentarioModel comentario = comentarioRepositorio.BuscarPorId(id);

            if (comentario == null)
            {
                TempData["Mensagem"] = "Comentário não encontrado";
                return RedirectToAction("Listar");
            }

            comentarioRepositorio.Reprovar(comentario);

            TempData["Mensagem"] = $"Comentário {comentario.ID} do usuário {comentario.Usuario.Nome} reprovado";

            return RedirectToAction("Listar");
        }
    }
}